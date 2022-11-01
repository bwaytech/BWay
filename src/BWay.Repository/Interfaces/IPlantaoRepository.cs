using BWay.Repository.Models;

namespace BWay.Repository.Interfaces
{
    public interface IPlantaoRepository
    {
        PlantaoModel ObterPlantao(int id);
        List<PlantaoModel> ObterTodos();
        PlantaoModel Inserir(PlantaoModel plantaoModel);
        void Deletar(PlantaoModel plantaoModel);
    }
}
