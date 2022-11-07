using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWay.Repository.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? Perfil { get; set; }

        public UsuarioModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public UsuarioModel(int id, string nome, string login, string senha, string perfil)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
            Perfil = perfil;
        }
    }
}
