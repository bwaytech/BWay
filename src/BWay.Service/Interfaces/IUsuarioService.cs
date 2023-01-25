using BWay.Infra.DTOs;
using BWay.Infra.Models;

namespace BWay.Service.Interfaces
{
    public interface IUsuarioService
    {
        //UsuarioDTO ObterUsuario(int id);
        //List<UsuarioDTO> ObterTodos();
        //void Inserir(UsuarioDTO usuario);
        //void Deletar(int id);

        List<UsuarioDTO> ListarUsuarios();
        string CadastrarUsuario(UsuarioModel usuario);
        string AtualizarUsuario(string idUsuario, UsuarioModel usuario);
        string ExcluirUsuario(string idUsuario);
    }
}
