using BWay.Infra.DTOs;
using BWay.Infra.Models;
using BWay.Repository.Models;

namespace BWay.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        List<UsuarioDTO> ListarUsuarios();
        UsuarioDTO BuscarUsuarioPorId(string idUsuario);
        string CadastrarUsuario(UsuarioModel usuario);
        string AtualizarUsuario(string idUsuario, UsuarioModel usuario);
        string ExcluirUsuario(string idUsuario);
    }
}
