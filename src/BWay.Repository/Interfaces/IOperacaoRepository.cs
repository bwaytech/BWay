using BWay.Infra.DTOs;
using BWay.Infra.Models;

namespace BWay.Repository.Interfaces
{
    public interface IOperacaoRepository
    {
        #region Operacao
        List<OperacaoDTO> ListarOperacao();
        OperacaoDTO BuscarOperacaoPorId(string idOperacao);
        string CadastrarOperacao(OperacaoModel operacao);
        string AtualizarOperacao(string idOperacao, OperacaoModel operacao);
        string ExcluirOperacao(string idOperacao);
        string AtualizarCodigoOperacao(string idOperacao, string codigoOperacao);
        #endregion

    }
}
