using BWay.Repository.Interfaces;
using BWay.Repository.Models;
using BWay.Service.Converters;
using BWay.Service.DTOs;
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

        public OperacaoDTO CriarOperacao(OperacaoDTO operacao)
        {
            OperacaoModel operacaoModel = OperacaoConverter.OperacaoDTOToOperacaoModel(operacao);

            var operacaoCriada = _operacaoRepository.CriarOperacao(operacaoModel);

            return OperacaoConverter.OperacaoModelToOperacaoDTO(operacaoCriada);
        }

        public OperacaoDTO AbrirOperacao(int id)
        {
            var operacaoAberta = _operacaoRepository.AbrirOperacao(id);

            return OperacaoConverter.OperacaoModelToOperacaoDTO(operacaoAberta);
        }

        public OperacaoDTO FecharOperacao(int id)
        {
            var operacaoFechada = _operacaoRepository.FecharOperacao(id);

            return OperacaoConverter.OperacaoModelToOperacaoDTO(operacaoFechada);
        }

        public OperacaoDTO ObterOperacaoAberta(int id)
        {
            var operacao = _operacaoRepository.ObterOperacaoAberta(id);

            return operacao == null ? null : OperacaoConverter.OperacaoModelToOperacaoDTO(operacao);
        }

        public OperacaoDTO ObterOperacao(int id)
        {
            var operacao = _operacaoRepository.ObterOperacao(id);

            return operacao == null ? null : OperacaoConverter.OperacaoModelToOperacaoDTO(operacao);
        }

        public List<OperacaoDTO> ObterOperacoes()
        {
            var operacoes = _operacaoRepository.ObterOperacoes();
            List<OperacaoDTO> operacoesDTO = new List<OperacaoDTO>();

            operacoes.ForEach(operacao => operacoesDTO.Add(OperacaoConverter.OperacaoModelToOperacaoDTO(operacao)));

            return operacoesDTO;
        }
    }
}
