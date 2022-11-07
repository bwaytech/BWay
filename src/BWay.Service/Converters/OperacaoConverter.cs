using BWay.Repository.Models;
using BWay.Service.DTOs;

namespace BWay.Service.Converters
{
    public static class OperacaoConverter
    {
        public static OperacaoDTO OperacaoModelToOperacaoDTO(OperacaoModel operacaoModel)
        {
            return new OperacaoDTO(operacaoModel.Id, operacaoModel.IdPlantao, operacaoModel.HorarioBarra.ToString(@"hh\:mm"), operacaoModel.HorarioPosBarra.ToString(@"hh\:mm"), operacaoModel.Abertura, operacaoModel.Fechamento);
        }

        public static OperacaoModel OperacaoDTOToOperacaoModel(OperacaoDTO operacaoDTO)
        {
            return new OperacaoModel(operacaoDTO.Id, operacaoDTO.IdPlantao, TimeSpan.Parse(operacaoDTO.HorarioBarra), TimeSpan.Parse(operacaoDTO.HorarioPosBarra), operacaoDTO.Abertura, operacaoDTO.Fechamento);
        }
    }
}
