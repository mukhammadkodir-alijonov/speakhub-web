using SpeakHub.Service.Dtos.Accounts;
using SpeakHub.Service.Dtos.Admins;
using SpeakHub.Service.Dtos.Users;

namespace SpeakHub.Service.Interfaces.Accounts
{
    public interface IAccountService
    {
        public Task<bool> AdminRegisterAsync(AdminRegisterDto adminRegisterDto);
        public Task<bool> PasswordUpdateAsync(PasswordUpdateDto passwordUpdateDto);
        public Task<bool> RegisterAsync(AccountRegisterDto registerDto);
        public Task<string> LoginAsync(AccountLoginDto accountLoginDto);
        public Task SendCodeAsync(SendToEmailDto sendToEmail);
        public Task<bool> VerifyPasswordAsync(UserResetPasswordDto userResetPassword);
        public Task<bool> DeleteByPasswordAsync(UserDeleteDto userDeleteDto);
    }
}
