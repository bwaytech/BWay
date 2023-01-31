namespace BWay.Infra.Models
{
    public class ProjetoModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string IdUsuarioAlteracao { get; set; }        

        public ProjetoModel(string nome, string descricao, string idUsuarioAlteracao)
        {
            Nome = nome;
            Descricao = descricao;
            IdUsuarioAlteracao = idUsuarioAlteracao;            
        }
    }
}
