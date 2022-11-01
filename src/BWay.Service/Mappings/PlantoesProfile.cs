using AutoMapper;
using BWay.Repository.Models;
using BWay.Service.DTOs;

namespace BWay.Service.Mappings
{
    public class PlantoesProfile : Profile
    {
        public PlantoesProfile()
        {
            CreateMap<PlantaoDTO, PlantaoModel>();
            CreateMap<PlantaoModel, PlantaoDTO>();
        }
    }
}
