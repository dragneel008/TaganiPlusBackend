using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Interfaces;

namespace Repo.Repositories
{
    public class ProvincesRepository : IRepository<Provinces>
    {
        private readonly TaganiPlusContext context;

        public ProvincesRepository(TaganiPlusContext context)
        {
            this.context = context;
        }

        public Task Delete(Provinces entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Provinces> Get(Provinces entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Provinces>> GetAll()
        {
            return await this.context.Provinces.ToListAsync();
        }

        public Task<Provinces> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Provinces entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(Provinces entity)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Provinces entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
