using BWay.Repository.Interfaces;
using BWay.Repository.Models;

namespace BWay.Repository.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        public static List<AtendimentoModel> atendimentos = new List<AtendimentoModel>();

        public List<AtendimentoModel> ObterAtendimentos()
        {
            return atendimentos;
        }

        public AtendimentoModel IniciarAtendimento(AtendimentoModel atendimentoModel)
        {
            atendimentos.Add(atendimentoModel);

            return atendimentoModel;
        }

        public AtendimentoModel EncerrarAtendimento(AtendimentoModel atendimentoModel)
        {
            atendimentos.Where(atendimento => atendimento.Id.Equals(atendimentoModel.Id)).ToList().ForEach(atendimento => atendimento.Termino = atendimentoModel.Termino);

            return atendimentoModel;
        }

        public AtendimentoModel ObterAtendimento(int id)
        {
            return atendimentos.Find(atendimento => atendimento.Id.Equals(id));
        }
    }
}
