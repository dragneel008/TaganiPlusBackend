using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Repo.Interfaces;

namespace Repo.Repositories
{
    public class MunicipalitiesRepository : IRepository<Municipalities>
    {
        private readonly TaganiPlusContext context;

        public MunicipalitiesRepository(TaganiPlusContext context)
        {
            this.context = context;
        }
        public Task Delete(Municipalities entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Municipalities> Get(Municipalities entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Municipalities>> GetAll()
        {
            return await this.context.Municipalities.ToListAsync();
        }

        public Task<Municipalities> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Municipalities entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(Municipalities entity)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Municipalities entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
