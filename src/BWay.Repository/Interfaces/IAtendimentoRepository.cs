using BWay.Repository.Models;

namespace BWay.Repository.Interfaces
{
    public interface IAtendimentoRepository
    {
        List<AtendimentoModel> ObterAtendimentos();
        AtendimentoModel IniciarAtendimento(AtendimentoModel atendimentoModel);
        AtendimentoModel EncerrarAtendimento(AtendimentoModel atendimentoModel);
        AtendimentoModel ObterAtendimento(int id);
    }
}
