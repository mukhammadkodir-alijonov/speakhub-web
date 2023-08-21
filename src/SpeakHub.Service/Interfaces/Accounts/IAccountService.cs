using SpeakHub.Service.Dtos.Accounts;
using SpeakHub.Service.Dtos.Admins;

namespace SpeakHub.Service.Interfaces.Accounts
{
    public interface IAccountService
    {
        public Task<bool> AdminRegisterAsync(AdminRegisterDto adminRegisterDto);
        public Task<string> LoginAsync(AccountLoginDto accountLoginDto);
    }
}
