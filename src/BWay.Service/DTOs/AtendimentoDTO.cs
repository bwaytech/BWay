namespace BWay.Service.DTOs
{
    public class AtendimentoDTO
    {
        public int Id { get; set; }
        public int IdOperacaoCorretor { get; set; }
        public int IdCliente { get; set; }
        public DateTime Inicio { get; private set; }
        public DateTime Termino { get; private set; }
        public string Observacao { get; set; }

        public AtendimentoDTO()
        {

        }

        public AtendimentoDTO(int id, int idOperacaoCorretor, int idCliente, string observacao)
        {
            Id = id;
            IdOperacaoCorretor = idOperacaoCorretor;
            IdCliente = idCliente;
            Observacao = observacao;
        }

        public AtendimentoDTO(int id, int idOperacaoCorretor, int idCliente, DateTime inicio, DateTime termino, string observacao)
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
