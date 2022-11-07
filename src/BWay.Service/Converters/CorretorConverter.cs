using BWay.Repository.Models;
using BWay.Service.DTOs;

namespace BWay.Service.Converters
{
    public class CorretorConverter
    {
        public CorretorDTO CorretorModelToDTO(CorretorModel corretorModel)
        {
            return new CorretorDTO(corretorModel.IdOperacao, corretorModel.IdCorretor);
        }
    }
}
