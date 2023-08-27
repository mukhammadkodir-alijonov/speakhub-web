using SpeakHub.Service.Common.Utils;
using SpeakHub.Service.Dtos.Users;
using SpeakHub.Service.ViewModels.UserViewModels;

namespace SpeakHub.Service.Interfaces.Users
{
    public interface IUserService
    {
        public Task<PagedList<UserViewModel>> GetAllAysnc(PaginationParams @params);
        public Task<PagedList<UserViewModel>> GetAllUsernameAysnc(PaginationParams @params);

        public Task<UserViewModel> GetAsync(int id);

        public Task<bool> UpdateAsync(int id, UserUpdateDto entity);

        public Task<bool> DeleteAsync(int id);

        public Task<UserViewModel> GetEmailAsync(string email);
    }
}
