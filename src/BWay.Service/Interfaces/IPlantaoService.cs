using BWay.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWay.Service.Interfaces
{
    public interface IPlantaoService
    {
        PlantaoDTO ObterPlantao(int id);
        List<PlantaoDTO> ObterTodos();
        PlantaoDTO Inserir(PlantaoDTO plantao);
        void Deletar(int id);
    }
}
