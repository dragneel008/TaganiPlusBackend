using System.Threading.Tasks;
using Entities.Entities;
using Entities.WebRequests;

namespace Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJSONWebToken(Users userInfo);

        Task<Users> AuthenticateUser(Users login);
    }
}
