namespace BWay.Service.DTOs
{
    public class CorretorDTO
    {
        public int IdOperacao { get; set; }
        public int IdCorretor { get; set; }

        public CorretorDTO(int idOperacao, int idCorretor)
        {
            IdOperacao = idOperacao;
            IdCorretor = idCorretor;
        }
    }
}
