using SpeakHub.Domain.Entities;

namespace SpeakHub.Service.Interfaces.Common;
public interface IAuthService
{
    public string GenerateToken(Human human, string role);

}
