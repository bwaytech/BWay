namespace BWay.Infra.DTOs
{
    public class OperacaoDTO
    {
        public Guid Id { get; set; }
        public Guid IdPlantao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
        public string HorarioBarra { get; set; }
        public string HorarioPosBarra { get; set; }
        public Guid IdUsuarioAlteracao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public string CodigoOperacao { get; set; }
    }
}
