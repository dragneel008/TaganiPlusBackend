namespace TaganiPlus.AutoMapperProfiles
{
    using AutoMapper;
    using Entities.Entities;
    using Entities.WebResponses;

    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            this.CreateMap<Users, LoginWebResponse>();
        }
    }
}
