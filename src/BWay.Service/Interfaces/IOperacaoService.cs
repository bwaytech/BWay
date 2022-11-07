using BWay.Service.DTOs;

namespace BWay.Service.Interfaces
{
    public interface IOperacaoService
    {
        OperacaoDTO CriarOperacao(OperacaoDTO operacao);
        OperacaoDTO AbrirOperacao(int id);
        OperacaoDTO FecharOperacao(int id);
        OperacaoDTO ObterOperacaoAberta(int id);
        OperacaoDTO ObterOperacao(int id);
        List<OperacaoDTO> ObterOperacoes();
    }
}
