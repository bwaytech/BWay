using BWay.Repository.Models;
using BWay.Service.DTOs;

namespace BWay.Service.Converters
{
    public class PlantaoConverter
    {
        public static PlantaoDTO PlantaoModelToDTO(PlantaoModel plantao)
        {
            if (plantao == null) return null;

            return new PlantaoDTO(plantao.Id, plantao.NomePlantao, plantao.IdLocalizacao, plantao.IdResponsavel);
        }

        public static PlantaoModel PlantaoDTOToModel(PlantaoDTO plantao)
        {
            if (plantao == null) return null;

            return new PlantaoModel(plantao.IdPlantao, plantao.NomePlantao, plantao.IdLocalizacao, plantao.IdResponsavel);
        }
    }
}
