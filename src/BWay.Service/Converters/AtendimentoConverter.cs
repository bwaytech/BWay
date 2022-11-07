using BWay.Repository.Models;
using BWay.Service.DTOs;

namespace BWay.Service.Converters
{
    public static class AtendimentoConverter
    {
        public static AtendimentoDTO AtendimentoModelToDTO(AtendimentoModel atendimentoModel)
        {
            return new AtendimentoDTO(atendimentoModel.Id, atendimentoModel.IdOperacaoCorretor, atendimentoModel.IdCliente, atendimentoModel.Inicio, atendimentoModel.Termino, atendimentoModel.Observacao);
        }

        public static AtendimentoModel AtendimentoDTOToModel(AtendimentoDTO atendimentoDTO)
        {
            return new AtendimentoModel(atendimentoDTO.Id, atendimentoDTO.IdOperacaoCorretor, atendimentoDTO.IdCliente, atendimentoDTO.Inicio, atendimentoDTO.Termino, atendimentoDTO.Observacao);
        }
    }
}
