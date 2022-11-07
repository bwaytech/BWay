namespace BWay.Integracao.Interface
{
    public interface IOperacaoCorretorIntegracao
    {
        Task<List<CorretorIntegracaoModel>> ObterCorretoresSorteio(int idOperacao);
        Task<List<CorretorIntegracaoModel>> ObterCorretoresAtendimento(int idOperacao);
    }
}
