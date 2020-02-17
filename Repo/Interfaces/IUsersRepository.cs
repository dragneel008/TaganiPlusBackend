namespace Repo.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities.Entities;

    public interface IUsersRepository
    {
        Task<ICollection<Users>> GetAll();
        Task<Users> Get(Guid id);

        Task<Users> GetByEmail(string email);

        Task Insert(Users entity);
        Task Update(Users entity);
        Task Delete(Users entity);
        Task Remove(Users entity);
        Task SaveChanges();
    }
}
