

using BWay.Infra.DTOs;
using BWay.Infra.Models;

namespace BWay.Repository.Interfaces
{
    public interface IProjetoRepository
    {
        string CadastrarProjeto(ProjetoModel projeto);
        string AtualizarProjeto(string idProjeto, ProjetoModel projeto);
        string ExcluirProjeto(string idProjeto);
        List<ProjetoDTO> ListarProjetos();
        ProjetoDTO BuscarProjetoPorId(string idProjeto);
    }
}
