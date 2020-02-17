using System.Collections.Generic;
using AutoMapper;
using Entities.DTOs.WebResponses;
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
            this.CreateMap<ICollection<RegionsWebResponse>, BaseResponse<ICollection<RegionsWebResponse>>>()
                .ForMember(x => x.StatusName, opt => opt.Ignore())
                .ForMember(x => x.StatusCode, opt => opt.Ignore())
                .ForMember(x => x.Data, opt => opt.MapFrom(x => x));
            this.CreateMap<ICollection<ProvincesWebResponse>, BaseResponse<ICollection<ProvincesWebResponse>>>()
                .ForMember(x => x.StatusName, opt => opt.Ignore())
                .ForMember(x => x.StatusCode, opt => opt.Ignore())
                .ForMember(x => x.Data, opt => opt.MapFrom(x => x));
            this.CreateMap<ICollection<MunicipalitiesWebResponse>, BaseResponse<ICollection<MunicipalitiesWebResponse>>>()
                .ForMember(x => x.StatusName, opt => opt.Ignore())
                .ForMember(x => x.StatusCode, opt => opt.Ignore())
                .ForMember(x => x.Data, opt => opt.MapFrom(x => x));
            this.CreateMap<ICollection<BarangaysWebResponse>, BaseResponse<ICollection<BarangaysWebResponse>>>()
                .ForMember(x => x.StatusName, opt => opt.Ignore())
                .ForMember(x => x.StatusCode, opt => opt.Ignore())
                .ForMember(x => x.Data, opt => opt.MapFrom(x => x));
        }
    }
}
