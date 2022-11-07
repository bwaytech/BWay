using AutoMapper;
using BWay.Infra.Exceptions;
using BWay.Repository.Interfaces;
using BWay.Repository.Models;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using System.Net;

namespace BWay.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public UsuarioDTO ObterUsuario(int id)
        {
            var usuario = _usuarioRepository.ObterUsuario(id);

            if (usuario == null) throw new HttpImobException(HttpStatusCode.NotFound, "Usuário não encontrado.");

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public List<UsuarioDTO> ObterTodos()
        {
            var usuarios = _usuarioRepository.ObterTodos();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        public void Inserir(UsuarioDTO usuario)
        {
            _usuarioRepository.Inserir(_mapper.Map<UsuarioDTO, UsuarioModel>(usuario));
        }

        public void Deletar(int id)
        {
            _usuarioRepository.Deletar(id);
        }
    }
}
