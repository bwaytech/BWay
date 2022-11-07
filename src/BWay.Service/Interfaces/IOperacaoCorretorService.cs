using BWay.Service.DTOs;

namespace BWay.Service.Interfaces
{
    public interface IOperacaoCorretorService
    {
        OperacaoCorretorDTO CheckIn(OperacaoCorretorDTO operacaoCorretorDTO);
        OperacaoCorretorDTO CheckOut(int id);
        List<OperacaoCorretorDTO> ObterOperacaoCorretores();
        OperacaoCorretorDTO ObterOperacaoCorretor(int id);
        List<CorretorDTO> ObterCorretoresElegiveisSorteio(int idOperacao);
        List<CorretorDTO> ObterCorretoresElegiveisAtendimento(int idOperacao);
    }
}
