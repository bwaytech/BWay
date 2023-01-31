namespace BWay.Infra.DTOs
{
    public class ProjetoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid IdUsuarioAlteracao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
    }
}
