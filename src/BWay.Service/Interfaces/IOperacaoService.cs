using BWay.Infra.DTOs;
using BWay.Infra.Models;

namespace BWay.Service.Interfaces
{
    public interface IOperacaoService
    {
        #region Operacao
        List<OperacaoDTO> ListarOperacao();
        OperacaoDTO BuscarOperacaoPorId(string idOperacao);
        string CadastrarOperacao(OperacaoModel operacao);
        string AtualizarOperacao(string idOperacao, OperacaoModel operacao);
        string AtualizarCodigoOperacao(string idOperacao, string codigoOperacao);
        string ExcluirOperacao(string idOperacao);
        #endregion
    }
}
