namespace BWay.Repository.Models
{
    public class OperacaoCorretorModel
    {
        public int Id { get; set; }
        public int IdOperacao { get; set; }
        public int IdCorretor { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool ElegivelSorteio { get; set; }
        public bool ElegivelAtendimento { get; set; }

        public OperacaoCorretorModel()
        { }

        public OperacaoCorretorModel(int id, int idOperacao, int idCorretor, DateTime checkIn, bool elegivelSorteio, bool elegivelAtendimento)
        {
            Id = id;
            IdOperacao = idOperacao;
            IdCorretor = idCorretor;
        }

        public OperacaoCorretorModel(int id, int idOperacao, int idCorretor, DateTime checkIn, DateTime checkOut, bool elegivelSorteio, bool elegivelAtendimento)
        {
            Id = id;
            IdOperacao = idOperacao;
            IdCorretor = idCorretor;
            CheckIn = checkIn;
            CheckOut = checkOut;
            ElegivelSorteio = elegivelSorteio;
            ElegivelAtendimento = elegivelAtendimento;
        }
    }
}
