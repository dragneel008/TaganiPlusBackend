namespace Repo.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities.Entities;
    using Microsoft.EntityFrameworkCore;
    using Repo.Interfaces;

    public class UsersRepository : IRepository<Users>
    {
        private readonly TaganiPlusContext context;

        public UsersRepository(TaganiPlusContext context)
        {
            this.context = context;
        }

        public Task Delete(Users entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> Get(Users entity)
        {
            return await this.context.Users.FindAsync(entity);
        }

        public async Task<ICollection<Users>> GetAll()
        {
            return await this.context.Users.ToListAsync();
        }

        public Task<Users> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
