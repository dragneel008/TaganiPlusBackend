namespace TaganiPlus.AutoMapperProfiles
{
    using AutoMapper;
    using Entities.DTOs.WebResponses;
    using Entities.Entities;
    using Entities.WebResponses;

    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            this.CreateMap<Users, LoginWebResponse>();
            this.CreateMap<Regions, RegionsWebResponse>();
            this.CreateMap<Provinces, ProvincesWebResponse>();
            this.CreateMap<Municipalities, MunicipalitiesWebResponse>();
            this.CreateMap<Barangays, BarangaysWebResponse>();
        }
    }
}
