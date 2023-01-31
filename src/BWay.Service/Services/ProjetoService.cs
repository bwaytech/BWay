using AutoMapper;
using BWay.Infra.DTOs;
using BWay.Infra.Models;
using BWay.Repository.Interfaces;
using BWay.Service.Interfaces;

namespace BWay.Service.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        //private readonly IMapper _mapper;

        public ProjetoService(IProjetoRepository projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            //_mapper = mapper;
        }

        public List<ProjetoDTO> ListarProjetos()
        {
            try
            {
                return _projetoRepository.ListarProjetos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProjetoDTO BuscarProjetoPorId(string idProjeto)
        {
            try
            {
                return _projetoRepository.BuscarProjetoPorId(idProjeto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarProjeto(ProjetoModel projeto)
        {
            try
            {
                return _projetoRepository.CadastrarProjeto(projeto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AtualizarProjeto(string idProjeto, ProjetoModel projeto)
        {
            try
            {
                return _projetoRepository.AtualizarProjeto(idProjeto, projeto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ExcluirProjeto(string idProjeto)
        {
            try
            {
                return _projetoRepository.ExcluirProjeto(idProjeto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
