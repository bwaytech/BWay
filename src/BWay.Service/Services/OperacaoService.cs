using BWay.Infra.DTOs;
using BWay.Infra.Models;
using BWay.Repository.Interfaces;
using BWay.Service.Interfaces;

namespace BWay.Service.Services
{
    public class OperacaoService : IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;

        public OperacaoService(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }

        #region Operacao
        public List<OperacaoDTO> ListarOperacao()
        {
            try
            {
                return _operacaoRepository.ListarOperacao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OperacaoDTO BuscarOperacaoPorId(string idOperacao)
        {
            try
            {
                return _operacaoRepository.BuscarOperacaoPorId(idOperacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarOperacao(OperacaoModel operacao)
        {
            try
            {
                return _operacaoRepository.CadastrarOperacao(operacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AtualizarOperacao(string idOperacao, OperacaoModel operacao)
        {
            try
            {
                return _operacaoRepository.AtualizarOperacao(idOperacao, operacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AtualizarCodigoOperacao(string idOperacao, string codigoOperacao)
        {
            try
            {
                return _operacaoRepository.AtualizarCodigoOperacao(idOperacao, codigoOperacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ExcluirOperacao(string idOperacao)
        {
            try
            {
                return _operacaoRepository.ExcluirOperacao(idOperacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
