namespace BWay.Repository.Models
{
    public class OperacaoModel
    {
        public int Id { get; set; }
        public int IdPlantao { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime Fechamento { get; set; }
        public TimeSpan HorarioBarra { get; set; }
        public TimeSpan HorarioPosBarra { get; set; }

        public OperacaoModel(int id, int idPlantao, TimeSpan horarioBarra, TimeSpan horarioPosBarra)
        {
            Id = id;
            IdPlantao = idPlantao;
            HorarioBarra = horarioBarra;
            HorarioPosBarra = horarioPosBarra;
        }

        public OperacaoModel(int id, int idPlantao, TimeSpan horarioBarra, TimeSpan horarioPosBarra, DateTime abertura, DateTime fechamento)
        {
            Id = id;
            IdPlantao = idPlantao;
            HorarioBarra = horarioBarra;
            HorarioPosBarra = horarioPosBarra;
            Abertura = abertura;
            Fechamento = fechamento;
        }
    }
}
