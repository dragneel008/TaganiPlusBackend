using AutoMapper;
using Entities.Entities;
using Entities.WebRequests;

namespace TaganiPlus.AutoMapperProfiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            this.CreateMap<LoginWebRequest, Users>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
