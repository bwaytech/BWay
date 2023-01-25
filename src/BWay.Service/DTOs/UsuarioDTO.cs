﻿namespace BWay.Service.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public int IdPerfilUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdStatusUsuario { get; set; }



        public UsuarioDTO(int idUsuario, int idPerfilUsuario, string nome, string email, string senha, int idStatusUsuario)
        {
            IdUsuario = idUsuario;
            IdPerfilUsuario = idPerfilUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            IdStatusUsuario = idStatusUsuario;
        }
    }
}
