namespace BWay.Service.DTOs
{
    public class OperacaoDTO
    {
        public int Id { get; set; }
        public int IdPlantao { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime Fechamento { get; set; }
        public string HorarioBarra { get; set; }
        public string HorarioPosBarra { get; set; }

        public OperacaoDTO()
        {
        }

        public OperacaoDTO(int id, int idPlantao, string horarioBarra, string horarioPosBarra)
        {
            Id = id;
            IdPlantao = idPlantao;
            HorarioBarra = horarioBarra;
            HorarioPosBarra = horarioPosBarra;
        }

        public OperacaoDTO(int id, int idPlantao, string horarioBarra, string horarioPosBarra, DateTime abertura, DateTime fechamento)
        {
            Id = id;
            IdPlantao = idPlantao;
            HorarioBarra = horarioBarra;
            HorarioPosBarra = horarioPosBarra;
            Abertura = abertura;
            Fechamento = fechamento;
        }

        public bool OperacaoEstaAberta()
        {
            return !Abertura.Equals(DateTime.MinValue);
        }

        public bool OperacaoEstaFechada()
        {
            return !Fechamento.Equals(DateTime.MinValue);
        }
    }
}
