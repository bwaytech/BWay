using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWay.Service.DTOs
{
    public class PlantaoDTO
    {
        public int IdPlantao { get; set; }
        public string NomePlantao { get; set; }
        public int IdLocalizacao { get; set; }
        public int IdResponsavel { get; set; }

        public PlantaoDTO(int idPlantao, string nomePlantao, int idLocalizacao, int idResponsavel)
        {
            IdPlantao = idPlantao;
            NomePlantao = nomePlantao;
            IdLocalizacao = idLocalizacao;
            IdResponsavel = idResponsavel;
        }
    }
}
