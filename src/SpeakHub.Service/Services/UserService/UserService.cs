﻿using AutoMapper;
using RegistanFerghanaLC.Service.Common.Exceptions;
using RegistanFerghanaLC.Service.Common.Helpers;
using RegistanFerghanaLC.Service.Common.Utils;
using RegistanFerghanaLC.Service.Interfaces.Common;
using SpeakHub.DataAccess.DbContexts;
using SpeakHub.DataAccess.Interfaces.Common;
using SpeakHub.Domain.Entities.Users;
using SpeakHub.Service.Common.Helpers;
using SpeakHub.Service.Dtos.Users;
using SpeakHub.Service.Interfaces.Users;
using SpeakHub.Service.ViewModels.UserViewModels;
using System.Net;

namespace SpeakHub.Service.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;
        private readonly AppDbContext _appDbContext;
        public UserService(IMapper imapper, AppDbContext appDbContext, IUnitOfWork unitOfWork, IImageService imageService)
        {
            this._mapper = imapper;
            this._unitOfWork = unitOfWork;
            this._imageService = imageService;
            this._appDbContext = appDbContext;
        }

        public async Task<PagedList<UserViewModel>> GetAllAysnc(PaginationParams @params)
        {
            var query = _unitOfWork.Users.GetAll().OrderBy(x => x.Id)
                .Select(x => _mapper.Map<UserViewModel>(x));
            return await PagedList<UserViewModel>.ToPagedListAsync(query, @params);

        }
        public async Task<UserViewModel> GetAsync(int id)
        {
            var temp = await _unitOfWork.Users.FindByIdAsync(id);
            if (temp is not null)
                return _mapper.Map<UserViewModel>(temp);
            else throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var temp = await _unitOfWork.Users.FindByIdAsync(id);
            if (temp is not null)
            {
                _unitOfWork.Users.Delete(id);
                var res = await _unitOfWork.SaveChangesAsync();
                return res > 0;
            }
            else throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "User not found");
        }
        public async Task<UserViewModel> GetEmailAsync(string email)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(email.Trim());
            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
            var userView = _mapper.Map<UserViewModel>(user);
            return userView;
        }
        public async Task<bool> UpdateAsync(int id, UserUpdateDto entity)
        {
            if (id == HttpContextHelper.UserId || HttpContextHelper.UserRole != "User")
            {
                var temp = await _appDbContext.Users.FindAsync(id);
                _unitOfWork.Users.TrackingDeteched(temp!);
                if (entity is not null)
                {
                    var res = _mapper.Map<User>(entity);
                    res.Id = HttpContextHelper.UserId;
                    res.PasswordHash = temp!.PasswordHash;
                    res.Salt = temp.Salt;
                    res.Email = temp.Email;
                    res.FirstName = string.IsNullOrWhiteSpace(entity.FirstName) ? temp.FirstName : entity.FirstName;
                    res.LastName = string.IsNullOrWhiteSpace(entity.LastName) ? temp.LastName : entity.LastName;
                    res.PhoneNumber = string.IsNullOrWhiteSpace(entity.PhoneNumber) ? temp.PhoneNumber : entity.PhoneNumber;
                    if (entity.Image is not null)
                    {
                        await _imageService.DeleteImageAsync(temp.Image!);
                        temp.Image = await _imageService.SaveImageAsync(entity.Image);
                    }
                    res.CreatedAt = temp.CreatedAt;
                    res.LastUpdatedAt = TimeHelper.GetCurrentServerTime();
                    _appDbContext.Users.Update(res);
                    var result = await _appDbContext.SaveChangesAsync();
                    return result > 0;
                }
                else throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "Not allowed");
        }
    }
}
