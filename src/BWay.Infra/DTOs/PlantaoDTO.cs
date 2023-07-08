namespace BWay.Infra.DTOs
{
    public class PlantaoDTO
    {
        public Guid Id { get; set; }
        public Guid IdLocalizacaoPlantao { get; set; }
        public Guid IdUsuarioResponsavel { get; set; }
        public string NomePlantao { get; set; }
        public string HorarioAbertura { get; set; }
        public string HorarioFechamento { get; set; }
        public Guid IdProjeto { get; set; }
        public Guid IdUsuarioAlteracao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
    }
}
