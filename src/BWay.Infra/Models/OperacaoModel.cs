using System.Reflection.Metadata.Ecma335;

namespace BWay.Infra.Models
{
    public class OperacaoModel
    {
        public string IdPlantao { get; set; }
        public string DataAbertura { get; set; }
        public string DataFechamento { get; set; }
        public string HorarioBarra { get; set; }
        public string HorarioPosBarra { get; set; }
        public string IdUsuarioAlteracao { get; set; }
        public string CodigoOperacao { get; set; }

        public OperacaoModel(string idPlantao, string dataAbertura, string dataFechamento, string horarioBarra, string horarioPosBarra, string idUsuarioAlteracao, string codigoOperacao)
        {
            IdPlantao = idPlantao;
            DataAbertura = dataAbertura;
            DataFechamento = dataFechamento;
            HorarioBarra = horarioBarra;
            HorarioPosBarra = horarioPosBarra;
            IdUsuarioAlteracao = idUsuarioAlteracao;
            CodigoOperacao = codigoOperacao;
        }
    }
}
