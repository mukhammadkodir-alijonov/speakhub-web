using RegistanFerghanaLC.Service.Dtos.Admins;
using RegistanFerghanaLC.Service.ViewModels.AdminViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Interfaces.Admins
{
    public interface IAdminService
    {
        public Task<AdminViewModel> GetByPhoneNumberAsync(string phoneNumber);
        public Task<List<AdminViewModel>> GetAllAsync(string search);
        public Task<List<AdminViewModel>> GetAllAsync();
        public Task<AdminViewModel> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(int id, AdminUpdateDto adminUpdateDto);
        public Task<bool> UpdateImageAsync(int id, IFormFile from);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> DeleteImageAsync(int adminId);
        public Task<bool> UpdatePasswordAsync(int id, PasswordUpdateDto dto);
    }
}
