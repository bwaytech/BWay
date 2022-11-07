using BWay.Service.DTOs;

namespace BWay.Service.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDTO ObterUsuario(int id);
        List<UsuarioDTO> ObterTodos();
        void Inserir(UsuarioDTO usuario);
        void Deletar(int id);
    }
}
