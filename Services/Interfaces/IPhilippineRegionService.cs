namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities.Entities;

    public interface IPhilippineRegionService
    {
        Task<ICollection<Regions>> GetRegionsAsync();

        Task<ICollection<Provinces>> GetProvincesAsync();

        Task<ICollection<Municipalities>> GetMunicipalitiesAsync();

        Task<ICollection<Barangays>> GetBarangaysAsync();
    }
}
