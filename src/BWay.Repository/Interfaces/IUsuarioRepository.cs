using BWay.Infra.Models;
using BWay.Repository.Models;

namespace BWay.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        //UsuarioModel ObterUsuario(int id);
        //List<UsuarioModel> ObterTodos();
        //void Inserir(UsuarioModel usuarioModel);
        //void Deletar(int id);
        //UsuarioModel AutenticarLogin(string login, string senha);

        string CadastrarUsuario(UsuarioModel usuario);
    }
}
