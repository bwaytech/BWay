using BWay.Repository.Interfaces;
using BWay.Repository.Models;

namespace BWay.Repository.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ApiContext _context;

        public ProjetoRepository()
        {
            _context = new ApiContext();
        }

        public ProjetoModel ObterProjeto(int id)
        {
            return _context.Projetos.Where(projeto => projeto.Id.Equals(id)).FirstOrDefault();
        }

        public List<ProjetoModel> ObterTodos()
        {
            return _context.Projetos.ToList();
        }

        public ProjetoModel Inserir(ProjetoModel projetoModel)
        {
            _context.Projetos.Add(projetoModel);
            _context.SaveChanges();

            return projetoModel;
        }

        public void Deletar(ProjetoModel projetoModel)
        {
            var projeto = _context.Projetos.Where(x => x.Id.Equals(projetoModel.Id)).First();

            _context.Remove(projeto);
            _context.SaveChanges();
        }
    }
}
