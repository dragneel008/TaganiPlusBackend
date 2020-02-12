namespace Services.Interfaces
{
    using System.Threading.Tasks;
    using Entities.Entities;

    public interface IUsersService
    {
        Task<Users> GetUser(Users user);

        Task<Users> GetUserByUsername(Users user);
    }
}
