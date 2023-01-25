namespace BWay.Infra.DTOs
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public int IdPerfilUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int StatusUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
