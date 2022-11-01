using AutoMapper;
using BWay.Repository.Models;
using BWay.Service.DTOs;

namespace BWay.Service.Mappings
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<ProjetoDTO, ProjetoModel>();
            CreateMap<ProjetoModel, ProjetoDTO>();
        }
    }
}
