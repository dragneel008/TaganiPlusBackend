using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;
using Repo.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<Users> usersRepository;

        public UsersService(IRepository<Users> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<Users> GetUserByEmail(Users user)
        {
            var userList = await this.usersRepository.GetAll();
            var result = userList.ToList().FirstOrDefault(x => x.Email == user.Email);
            return result;
        }
    }
}
