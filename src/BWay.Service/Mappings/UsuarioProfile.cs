using AutoMapper;
using BWay.Repository.Models;
using BWay.Service.DTOs;

namespace BWay.Service.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDTO, UsuarioModel>();
            CreateMap<UsuarioModel, UsuarioDTO>();
        }
    }
}
