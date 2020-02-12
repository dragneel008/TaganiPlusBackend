using System.Threading.Tasks;
using Entities.Entities;
using Repo.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<Users> GetUser(Users user)
        {
            return await this.usersRepository.Get(user.Id);
        }

        public async Task<Users> GetUserByUsername(Users user)
        {
            return await this.usersRepository.GetByUsername(user.Username);
        }
    }
}
