using BWay.Repository.Interfaces;
using BWay.Repository.Models;

namespace BWay.Repository.Repositories
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private static List<OperacaoModel> operacoes = new List<OperacaoModel>(){
            new OperacaoModel(1, 1, new TimeSpan(16, 00, 0), new TimeSpan(16, 30, 0))
        };

        public OperacaoModel CriarOperacao(OperacaoModel operacao)
        {
            operacoes.Add(operacao);

            return operacao;
        }

        public OperacaoModel AbrirOperacao(int id)
        {
            operacoes.Where(operacao => operacao.Id.Equals(id)).ToList().ForEach(operacao => operacao.Abertura = DateTime.Now);
            return operacoes.Find(operacao => operacao.Id.Equals(id));
        }

        public OperacaoModel FecharOperacao(int id)
        {
            operacoes.Where(operacao => operacao.Id.Equals(id)).ToList().ForEach(operacao => operacao.Fechamento = DateTime.Now);
            return operacoes.Find(operacao => operacao.Id.Equals(id));
        }

        public OperacaoModel ObterOperacaoAberta(int id)
        {
            return operacoes.Find(operacao => operacao.Id.Equals(id) && !operacao.Abertura.Equals(DateTime.MinValue) && operacao.Fechamento.Equals(DateTime.MinValue));
        }

        public OperacaoModel ObterOperacao(int id)
        {
            return operacoes.Find(operacao => operacao.Id.Equals(id) && operacao.Abertura.Equals(DateTime.MinValue));
        }

        public List<OperacaoModel> ObterOperacoes()
        {
            return operacoes;
        }
    }
}
