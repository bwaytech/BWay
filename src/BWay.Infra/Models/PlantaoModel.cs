namespace BWay.Infra.Models
{
    public class PlantaoModel
    {
        public string IdLocalizacaoPlantao { get; set; }
        public string IdUsuarioResponsavel { get; set; }
        public string NomePlantao { get; set; }
        public string HorarioAbertura { get; set; }
        public string HorarioFechamento { get; set; }
        public string IdUsuarioAlteracao { get; set; }
        public string IdProjeto { get; set; }

        public PlantaoModel(string idLocalizacaoPlantao, string idUsuarioResponsavel, string nomePlantao, string horarioAbertura, string horarioFechamento, string idUsuarioAlteracao, string idProjeto)
        {
            IdLocalizacaoPlantao = idLocalizacaoPlantao;
            IdUsuarioResponsavel = idUsuarioResponsavel;
            NomePlantao = nomePlantao;
            HorarioAbertura = horarioAbertura;
            HorarioFechamento = horarioFechamento;
            IdUsuarioAlteracao = idUsuarioAlteracao;
            IdProjeto = idProjeto;
        }
    }
}
