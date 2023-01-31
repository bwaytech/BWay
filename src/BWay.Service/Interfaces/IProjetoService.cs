using BWay.Infra.DTOs;
using BWay.Infra.Models;

namespace BWay.Service.Interfaces
{
    public interface IProjetoService
    {
        List<ProjetoDTO> ListarProjetos();
        ProjetoDTO BuscarProjetoPorId(string idProjeto);
        string CadastrarProjeto(ProjetoModel projeto);
        string AtualizarProjeto(string idProjeto, ProjetoModel projeto);
        string ExcluirProjeto(string idProjeto);

    }
}
