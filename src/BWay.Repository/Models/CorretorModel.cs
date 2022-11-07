namespace BWay.Repository.Models
{
    public class CorretorModel
    {
        public int IdOperacao { get; set; }
        public int IdCorretor { get; set; }

        public CorretorModel(int idOperacao, int idCorretor)
        {
            IdOperacao = idOperacao;
            IdCorretor = idCorretor;
        }
    }
}
