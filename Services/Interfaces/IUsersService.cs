namespace Services.Interfaces
{
    using System.Threading.Tasks;
    using Entities.Entities;

    public interface IUsersService
    {
        Task<Users> GetUserByEmail(Users user);
    }
}
