using BWay.Repository.Interfaces;
using BWay.Repository.Models;

namespace BWay.Repository.Repositories
{
    public class OperacaoCorretorRepository : IOperacaoCorretorRepository
    {
        private static List<OperacaoCorretorModel> listaOperacaoCorretorModel = new List<OperacaoCorretorModel>();

        public OperacaoCorretorModel CheckIn(OperacaoCorretorModel operacaoCorretorModel)
        {
            listaOperacaoCorretorModel.Add(operacaoCorretorModel);

            return operacaoCorretorModel;
        }

        public OperacaoCorretorModel CheckOut(int id)
        {
            listaOperacaoCorretorModel.Where(operacaoCorretor => operacaoCorretor.Id.Equals(id)).ToList().ForEach(operacaoCorretor => operacaoCorretor.CheckOut = DateTime.Now);
            return listaOperacaoCorretorModel.Find(operacao => operacao.Id.Equals(id));
        }

        public OperacaoCorretorModel ObterOperacaoCorretor(int id)
        {
            return listaOperacaoCorretorModel.Find(operacaoCorretor => operacaoCorretor.Id.Equals(id));
        }

        public OperacaoCorretorModel ObterOperacaoCorretor(int idCorretor, int idOperacao, DateTime checkin)
        {
            var retorno = listaOperacaoCorretorModel.Find(operacaoCorretor => operacaoCorretor.IdCorretor.Equals(idCorretor) && operacaoCorretor.IdOperacao.Equals(idOperacao) && DateTime.Compare(operacaoCorretor.CheckIn.Date, checkin.Date) == 0);
            return retorno;
        }

        public List<OperacaoCorretorModel> ObterOperacaoCorretores()
        {
            return listaOperacaoCorretorModel;
        }

        public List<CorretorModel> ObterCorretoresElegiveisSorteio(int idOperacao)
        {
            List<CorretorModel> corretores = new List<CorretorModel>();
            var elegiveis = listaOperacaoCorretorModel.FindAll(corretor => corretor.IdOperacao.Equals(idOperacao) && corretor.ElegivelSorteio.Equals(true));

            elegiveis.ForEach(corretor => corretores.Add(new CorretorModel(corretor.IdOperacao, corretor.IdCorretor)));

            return corretores;
        }

        public List<CorretorModel> ObterCorretoresElegiveisAtendimento(int idOperacao)
        {
            List<CorretorModel> corretores = new List<CorretorModel>();
            var elegiveis = listaOperacaoCorretorModel.FindAll(corretor => corretor.IdOperacao.Equals(idOperacao) && corretor.ElegivelAtendimento.Equals(true) && corretor.ElegivelSorteio.Equals(false));

            elegiveis.ForEach(corretor => corretores.Add(new CorretorModel(corretor.IdOperacao, corretor.IdCorretor)));

            return corretores;
        }
    }
}
