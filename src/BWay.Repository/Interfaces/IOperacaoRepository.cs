using BWay.Repository.Models;

namespace BWay.Repository.Interfaces
{
    public interface IOperacaoRepository
    {
        OperacaoModel CriarOperacao(OperacaoModel operacao);
        OperacaoModel AbrirOperacao(int id);
        OperacaoModel FecharOperacao(int id);
        OperacaoModel ObterOperacaoAberta(int id);
        OperacaoModel ObterOperacao(int id);
        List<OperacaoModel> ObterOperacoes();
    }
}
