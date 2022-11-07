using AutoMapper;
using BWay.Repository.Models;
using BWay.Service.DTOs;

namespace BWay.Service.Mappings
{
    public class RoletaProfile : Profile
    {
        public RoletaProfile()
        {
            CreateMap<CorretorRoletaDto, CorretorRoletaModel>();
            CreateMap<CorretorRoletaModel, CorretorRoletaDto>();
        }
    }
}
