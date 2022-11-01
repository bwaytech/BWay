using AutoMapper;
using BWay.Infra.Exceptions;
using BWay.Repository.Interfaces;
using BWay.Repository.Models;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using System.Net;

namespace BWay.Service.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        private readonly IMapper _mapper;

        public ProjetoService(IProjetoRepository projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        public ProjetoDTO ObterProjeto(int id)
        {
            var projeto = _projetoRepository.ObterProjeto(id);
            if (projeto == null) throw new HttpImobException(HttpStatusCode.NotFound, "Projeto não encontrado.");

            return _mapper.Map<ProjetoDTO>(projeto);
        }

        public List<ProjetoDTO> ObterTodos()
        {
            var projetos = _projetoRepository.ObterTodos();
            return _mapper.Map<List<ProjetoDTO>>(projetos);
        }

        public ProjetoDTO Inserir(ProjetoDTO projeto)
        {
            var projetoCriado = _projetoRepository.Inserir(_mapper.Map<ProjetoModel>(projeto));
            return _mapper.Map<ProjetoDTO>(projetoCriado);
        }

        public void Deletar(int id)
        {
            var projeto = ObterProjeto(id);
            _projetoRepository.Deletar(_mapper.Map<ProjetoModel>(projeto));
        }
    }
}
