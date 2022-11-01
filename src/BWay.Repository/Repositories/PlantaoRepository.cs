using BWay.Repository.Interfaces;
using BWay.Repository.Models;

namespace BWay.Repository.Repositories
{
    public class PlantaoRepository : IPlantaoRepository
    {
        private readonly ApiContext _context;

        public PlantaoRepository()
        {
            _context = new ApiContext();
        }

        public PlantaoModel ObterPlantao(int id)
        {
            var plantao = _context.Plantoes.FirstOrDefault(plantao => plantao.Id.Equals(id));
            return plantao;
        }

        public List<PlantaoModel> ObterTodos()
        {
            return _context.Plantoes.ToList();
        }

        public PlantaoModel Inserir(PlantaoModel plantaoModel)
        {
            _context.Plantoes.Add(plantaoModel);
            _context.SaveChanges();

            return plantaoModel;
        }

        public void Deletar(PlantaoModel plantaoModel)
        {
            var plantao = _context.Plantoes.First(x => x.Id.Equals(plantaoModel.Id));

            _context.Remove(plantao);
            _context.SaveChanges();
        }
    }
}
