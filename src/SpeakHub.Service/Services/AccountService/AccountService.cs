using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Admins;
using SpeakHub.Domain.Entities.Users;
using SpeakHub.Domain.Enums;
using SpeakHub.Service.Common.Exceptions;
using SpeakHub.Service.Common.Helpers;
using SpeakHub.Service.Common.Security;
using SpeakHub.Service.Dtos.Accounts;
using SpeakHub.Service.Dtos.Admins;
using SpeakHub.Service.Dtos.Common;
using SpeakHub.Service.Dtos.Users;
using SpeakHub.Service.Interfaces.Accounts;
using SpeakHub.Service.Interfaces.Common;
using System.Net;
using System.Net.Mail;

namespace SpeakHub.Service.Services.AccountService;
public class AccountService : IAccountService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUnitOfWork _repository;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public AccountService(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper,IMemoryCache memoryCache,IEmailService emailService)
    {
        this._memoryCache = memoryCache;
        this._repository = unitOfWork;
        this._authService = authService;
        this._mapper = mapper;
        this._emailService = emailService;
    }

    public async Task<bool> AdminRegisterAsync(AdminRegisterDto adminRegisterDto)
    {
        var emailcheck = await _repository.Admins.FirstOrDefault(x => x.Email == adminRegisterDto.Email);
        if (emailcheck is not null)
            throw new StatusCodeException(HttpStatusCode.Conflict, "Email alredy exist");

        var phoneNumberCheck = await _repository.Admins.FirstOrDefault(x => x.PhoneNumber == adminRegisterDto.PhoneNumber);
        if (phoneNumberCheck is not null)
            throw new AlreadyExistingException(nameof(adminRegisterDto.PhoneNumber), "This phone number is already registered.");

        var hashresult = PasswordHasher.Hash(adminRegisterDto.Password);
        var admin = _mapper.Map<Admin>(adminRegisterDto);
        admin.AdminRole = Role.Admin;
        admin.PasswordHash = hashresult.Hash;
        admin.Salt = hashresult.Salt;
        admin.CreatedAt = TimeHelper.GetCurrentServerTime();
        admin.LastUpdatedAt = TimeHelper.GetCurrentServerTime();
        _repository.Admins.Add(admin);
        var result = await _repository.SaveChangesAsync();
        return result > 0;
    }

    public async Task<string> LoginAsync(AccountLoginDto accountLoginDto)
    {
        var admin = await _repository.Admins.FirstOrDefault(x => x.PhoneNumber == accountLoginDto.PhoneNumber);
        if (admin is null)
        {
            var user = await _repository.Users.FirstOrDefault(x => x.PhoneNumber == accountLoginDto.PhoneNumber);
            if (user is null) throw new NotFoundException(nameof(accountLoginDto.PhoneNumber), "No user with this phone number is found!");
            else
            {
                var hasherResult = PasswordHasher.Verify(accountLoginDto.Password, user.Salt, user.PasswordHash);
                if (hasherResult)
                {
                    string token = _authService.GenerateToken(user, "user");
                    return token;
                }
                else throw new NotFoundException(nameof(accountLoginDto.Password), "Incorrect password!");
            }
        }
        else
        {
            var hasherResult = PasswordHasher.Verify(accountLoginDto.Password, admin.Salt, admin.PasswordHash);
            if (hasherResult)
            {
                string token = "";
                if (admin.PhoneNumber != null)
                {
                    token = _authService.GenerateToken(admin, "admin");
                    return token;
                }
                token = _authService.GenerateToken(admin, "admin");
                return token;
            }
            else throw new NotFoundException(nameof(accountLoginDto.Password), "Incorrect password!");
        }

    }

    public async Task<bool> DeleteByPasswordAsync(UserDeleteDto userDeleteDto)
    {
        var user = await _repository.Users.FindByIdAsync(HttpContextHelper.UserId);
        if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");

        var res = PasswordHasher.Verify(userDeleteDto.Password, user.Salt, user.PasswordHash);
        if (res == false) throw new StatusCodeException(HttpStatusCode.NotFound, "Password is incorrect!");

        return true;
    }
    
    public async Task<bool> PasswordUpdateAsync(PasswordUpdateDto passwordUpdateDto)
    {
        var user = await _repository.Users.FindByIdAsync(HttpContextHelper.UserId);
        if (user is not null)
        {
            var result = PasswordHasher.Verify(passwordUpdateDto.OldPassword, user.Salt, user.PasswordHash);
            if (result)
            {
                if (passwordUpdateDto.NewPassword == passwordUpdateDto.VerifyPassword)
                {
                    var hash = PasswordHasher.Hash(passwordUpdateDto.VerifyPassword);
                    user.Salt = hash.Salt;
                    user.PasswordHash = hash.Hash;
                    _repository.Users.Update(user.Id, user);
                    var res = await _repository.SaveChangesAsync();
                    return res > 0;
                }
                else throw new StatusCodeException(HttpStatusCode.BadRequest, "new password and verify password must be match");
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "Invalid Password");
        }
        else throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
    }

    public async Task<bool> RegisterAsync(AccountRegisterDto registerDto)
    {
        var emailcheck = await _repository.Users.FirstOrDefault(x => x.Email == registerDto.Email);
        if (emailcheck is not null)
            throw new StatusCodeException(HttpStatusCode.Conflict, "Email alredy exist");

        var phoneNumberCheck = await _repository.Users.FirstOrDefault(x => x.PhoneNumber == registerDto.PhoneNumber);
        if (phoneNumberCheck is not null)
            throw new StatusCodeException(HttpStatusCode.Conflict, "Phone number alredy exist");

        var hasherResult = PasswordHasher.Hash(registerDto.Password);
        var user = _mapper.Map<User>(registerDto);
        user.PasswordHash = hasherResult.Hash;
        user.Salt = hasherResult.Salt;
        user.Status = StatusType.Active;
        user.UserRole = Role.User;
        user.CreatedAt = TimeHelper.GetCurrentServerTime();
        user.LastUpdatedAt = TimeHelper.GetCurrentServerTime();
        _repository.Users.Add(user);
        var databaseResult = await _repository.SaveChangesAsync();
        return databaseResult > 0;
    }

    public async Task SendCodeAsync(SendToEmailDto sendToEmail)
    {
        var user = await _repository.Users.FindByIdAsync(HttpContextHelper.UserId);
        if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");

        if (user.Email != sendToEmail.Email) throw new StatusCodeException(HttpStatusCode.BadRequest, "This email does not belong to you!");

        int code = new Random().Next(100000, 999999);
        _memoryCache.Set(sendToEmail.Email, code, TimeSpan.FromMinutes(10));

        var message = new EmailMessage()
        {
            To = sendToEmail.Email,
            Subject = "Verification code",
            Body = code.ToString()
        };

        await _emailService.SendAsync(message);
    }

    public async Task<bool> VerifyPasswordAsync(UserResetPasswordDto userResetPassword)
    {
        var user = await _repository.Users.GetByEmailAsync(userResetPassword.Email);
        if (user == null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");

        if (user.Email != userResetPassword.Email) throw new StatusCodeException(HttpStatusCode.BadRequest, "This email does not belong to you!");

        if (_memoryCache.TryGetValue(userResetPassword.Email, out int expectedCode) is false)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is expired");

        if (expectedCode != userResetPassword.Code)
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is wrong");

        var newPassword = PasswordHasher.Hash(userResetPassword.Password);

        user.PasswordHash = newPassword.Hash;
        user.Salt = newPassword.Salt;

        _repository.Users.Update(user.Id, user);

        var res = await _repository.SaveChangesAsync();

        return res > 0;
    }
}
