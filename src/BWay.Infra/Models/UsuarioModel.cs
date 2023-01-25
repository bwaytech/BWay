using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWay.Infra.Models
{
    public class UsuarioModel
    {
        //public Guid? idUsuario { get; set; }
        public int IdPerfilUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdStatusUsuario { get; set; }

        public UsuarioModel(int idPerfilUsuario, string nome, string email, string senha, int idStatusUsuario)
        {
            IdPerfilUsuario = idPerfilUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            IdStatusUsuario = idStatusUsuario;
        }
    }
}
