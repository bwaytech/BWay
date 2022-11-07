using BWay.Repository.Interfaces;
using BWay.Repository.Models;

namespace BWay.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static List<UsuarioModel> usuarios = new List<UsuarioModel>{
                new UsuarioModel(1, "Conra","csilva", "senha1", "gerente"),
                new UsuarioModel(2, "Bruno", "boliveira", "senha2", "corretor"),
                new UsuarioModel(3, "Gerson", "gsantos", "senha3", "atendente")
            };

        public UsuarioModel? ObterUsuario(int id)
        {
            return usuarios.Find(usuario => usuario.Id.Equals(id));
        }

        public List<UsuarioModel> ObterTodos()
        {
            return usuarios;
        }

        public void Inserir(UsuarioModel usuarioModel)
        {
            usuarios.Add(usuarioModel);
        }

        public void Deletar(int id)
        {
            usuarios.RemoveAll(usuario => usuario.Id.Equals(id));
        }

        public UsuarioModel? AutenticarLogin(string login, string senha)
        {
            return usuarios.Where(x => x.Login.ToLower() == login.ToLower() && x.Senha == senha).FirstOrDefault();
        }
    }
}
