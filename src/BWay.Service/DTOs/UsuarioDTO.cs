namespace BWay.Service.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }

        public UsuarioDTO(int idUsuario, string nome)
        {
            IdUsuario = idUsuario;
            Nome = nome;
        }
    }
}
