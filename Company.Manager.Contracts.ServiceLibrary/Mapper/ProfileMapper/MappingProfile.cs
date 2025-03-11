
using Enterprise.Manager.Contracts.ServiceLibrary.DTO;
using Enterprise.Manager.Library.Entities;
using AutoMapper;

namespace Enterprise.Manager.ServiceLibrary.Mapper.ProfileMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyEntity, CompanyDto>();
        }
    }
}