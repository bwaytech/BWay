using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWay.Repository.Models
{
    public class PlantaoModel
    {
        public int Id { get; set; }
        public string NomePlantao { get; set; }
        public int IdLocalizacao { get; set; }
        public int IdResponsavel { get; set; }

        public PlantaoModel()
        {

        }

        public PlantaoModel(int idPlantao, string nomePlantao, int idLocalizacao, int idResponsavel)
        {
            Id = idPlantao;
            NomePlantao = nomePlantao;
            IdLocalizacao = idLocalizacao;
            IdResponsavel = idResponsavel;
        }
    }
}
