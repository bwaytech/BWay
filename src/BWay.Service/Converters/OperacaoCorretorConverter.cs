using BWay.Repository.Models;
using BWay.Service.DTOs;

namespace BWay.Service.Converters
{
    public static class OperacaoCorretorConverter
    {
        public static OperacaoCorretorDTO OperacaoCorretorModelToDTO(OperacaoCorretorModel operacaoCorretorModel)
        {
            return new OperacaoCorretorDTO(operacaoCorretorModel.Id, operacaoCorretorModel.IdOperacao, operacaoCorretorModel.IdCorretor, operacaoCorretorModel.CheckIn, operacaoCorretorModel.CheckOut, operacaoCorretorModel.ElegivelSorteio, operacaoCorretorModel.ElegivelAtendimento);
        }

        public static OperacaoCorretorModel OperacaoCorretorDTOToModel(OperacaoCorretorDTO operacaoCorretorDTO)
        {
            return new OperacaoCorretorModel(operacaoCorretorDTO.Id, operacaoCorretorDTO.IdOperacao, operacaoCorretorDTO.IdCorretor, operacaoCorretorDTO.CheckIn, operacaoCorretorDTO.CheckOut, operacaoCorretorDTO.ElegivelSorteio, operacaoCorretorDTO.ElegivelAtendimento);
        }
    }
}
