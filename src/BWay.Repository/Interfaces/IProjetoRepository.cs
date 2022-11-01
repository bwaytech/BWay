using BWay.Repository.Models;

namespace BWay.Repository.Interfaces
{
    public interface IProjetoRepository
    {
        ProjetoModel ObterProjeto(int id);
        List<ProjetoModel> ObterTodos();
        ProjetoModel Inserir(ProjetoModel projetoModel);
        void Deletar(ProjetoModel projeto);
    }
}
