using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Entities;
using Repo.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class PhilippineRegionService : IPhilippineRegionService
    {
        private readonly IRepository<Regions> regionsRepository;
        private readonly IRepository<Provinces> provincesRepository;
        private readonly IRepository<Municipalities> municipalitiesRepository;
        private readonly IRepository<Barangays> barangaysRepository;
        private readonly IMapper mapper;

        public PhilippineRegionService
            (
                IRepository<Regions> regionsRepository,
                IRepository<Provinces> provincesRepository,
                IRepository<Municipalities> municipalitiesRepository,
                IRepository<Barangays> barangaysRepository,
                IMapper mapper
            )
        {
            this.regionsRepository = regionsRepository;
            this.provincesRepository = provincesRepository;
            this.municipalitiesRepository = municipalitiesRepository;
            this.barangaysRepository = barangaysRepository;
            this.mapper = mapper;
        }

        public async Task<ICollection<Barangays>> GetBarangaysAsync()
        {
            var result = await this.barangaysRepository.GetAll();

            return result;
        }

        public async Task<ICollection<Municipalities>> GetMunicipalitiesAsync()
        {
            var result = await this.municipalitiesRepository.GetAll();

            return result;
        }

        public async Task<ICollection<Provinces>> GetProvincesAsync()
        {
            var result = await this.provincesRepository.GetAll();

            return result;
        }

        public async Task<ICollection<Regions>> GetRegionsAsync()
        {
            var result = await this.regionsRepository.GetAll();

            return result;
        }
    }
}
