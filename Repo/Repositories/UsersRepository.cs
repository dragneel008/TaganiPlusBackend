﻿namespace Repo.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities.Entities;
    using Microsoft.EntityFrameworkCore;
    using Repo.Interfaces;

    public class UsersRepository : IUsersRepository
    {
        private readonly TaganiContext context;

        public UsersRepository(TaganiContext context)
        {
            this.context = context;
        }

        public Task Delete(Users entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Users> Get(Guid id)
        {
            return await this.context.Users.FindAsync(id);
        }

        public async Task<ICollection<Users>> GetAll()
        {
            return await this.context.Users.ToListAsync();
        }

        public async Task<Users> GetByUsername(string username)
        {
            var usersList = await this.GetAll();
            var user = usersList.ToList().FirstOrDefault(user => user.Username == username);

            return user;
        }

        public Task Insert(Users entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(Users entity)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Users entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
