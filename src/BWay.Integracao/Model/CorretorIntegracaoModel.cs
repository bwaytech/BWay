namespace BWay.Integracao.Model
{
    public class CorretorIntegracaoModel
    {
        public int IdOperacao { get; set; }
        public int IdCorretor { get; set; }

        public CorretorIntegracaoModel()
        { }

        public CorretorIntegracaoModel(int idOperacao, int idCorretor)
        {
            IdOperacao = idOperacao;
            IdCorretor = idCorretor;
        }
    }
}
