using BWay.Repository.Models;

namespace BWay.Repository.Interfaces
{
    public interface IOperacaoCorretorRepository
    {
        OperacaoCorretorModel CheckIn(OperacaoCorretorModel operacaoCorretorModel);
        OperacaoCorretorModel CheckOut(int id);
        OperacaoCorretorModel ObterOperacaoCorretor(int id);
        OperacaoCorretorModel ObterOperacaoCorretor(int idCorretor, int idOperacao, DateTime checkin);
        List<OperacaoCorretorModel> ObterOperacaoCorretores();
        List<CorretorModel> ObterCorretoresElegiveisSorteio(int idOperacao);
        List<CorretorModel> ObterCorretoresElegiveisAtendimento(int idOperacao);
    }
}
