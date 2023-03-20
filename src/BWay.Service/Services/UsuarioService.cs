using AutoMapper;
using BWay.Infra.DTOs;
using BWay.Infra.Models;
using BWay.Repository.Interfaces;
using BWay.Service.Interfaces;

namespace BWay.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        //private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            //_mapper = mapper;
        }

        public List<UsuarioDTO> ListarUsuarios()
        {
            try
            {
                return _usuarioRepository.ListarUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioDTO BuscarUsuarioPorId(string idUsuario)
        {
            try
            {
                return _usuarioRepository.BuscarUsuarioPorId(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarUsuario(UsuarioModel usuario)
        {
            try
            {
                return _usuarioRepository.CadastrarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AtualizarUsuario(string idUsuario, UsuarioModel usuario)
        {
            try
            {
                return _usuarioRepository.AtualizarUsuario(idUsuario, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ExcluirUsuario(string idUsuario)
        {
            try
            {
                return _usuarioRepository.ExcluirUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioDTO EfetuarLogin(LoginModel login)
        {
            try
            {
                return _usuarioRepository.EfetuarLogin(login);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
