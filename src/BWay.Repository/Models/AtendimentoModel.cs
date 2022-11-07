namespace BWay.Repository.Models
{
    public class AtendimentoModel
    {
        public int Id { get; set; }
        public int IdOperacaoCorretor { get; set; }
        public int IdCliente { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public string Observacao { get; set; }

        public AtendimentoModel(int id, int idOperacaoCorretor, int idCliente, DateTime inicio, DateTime termino, string observacao)
        {
            Id = id;
            IdOperacaoCorretor = idOperacaoCorretor;
            IdCliente = idCliente;
            Inicio = inicio;
            Termino = termino;
            Observacao = observacao;
        }
    }
}
