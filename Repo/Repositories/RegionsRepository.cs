using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Interfaces;

namespace Repo.Repositories
{
    public class RegionsRepository : IRepository<Regions>
    {
        private readonly TaganiPlusContext context;

        public RegionsRepository(TaganiPlusContext context)
        {
            this.context = context;
        }

        public Task Delete(Regions entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Regions> Get(Regions entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Regions>> GetAll()
        {
            return await this.context.Regions.ToListAsync();
        }

        public Task<Regions> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Regions entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(Regions entity)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Regions entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
