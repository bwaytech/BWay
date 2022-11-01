using BWay.Service.DTOs;

namespace BWay.Service.Interfaces
{
    public interface IProjetoService
    {
        ProjetoDTO ObterProjeto(int id);
        List<ProjetoDTO> ObterTodos();
        ProjetoDTO Inserir(ProjetoDTO projeto);
        void Deletar(int id);
    }
}
