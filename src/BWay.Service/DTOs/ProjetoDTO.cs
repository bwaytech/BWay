namespace BWay.Service.DTOs
{
    public class ProjetoDTO
    {
        public int Id { get; set; }
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }

        public ProjetoDTO()
        {

        }

        public ProjetoDTO(int idProjeto, string nomeProjeto, string descricao)
        {
            Id = idProjeto;
            NomeProjeto = nomeProjeto;
            Descricao = descricao;
        }
    }
}
