namespace Repo.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities.Entities;
    using Microsoft.EntityFrameworkCore;
    using Repo.Interfaces;

    public class BarangaysRepository : IRepository<Barangays>
    {
        private readonly TaganiPlusContext context;

        public BarangaysRepository(TaganiPlusContext context)
        {
            this.context = context;
        }

        public Task Delete(Barangays entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Barangays> Get(Barangays entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Barangays>> GetAll()
        {
            return await this.context.Barangays.ToListAsync();
        }

        public Task<Barangays> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Barangays entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(Barangays entity)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Barangays entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
