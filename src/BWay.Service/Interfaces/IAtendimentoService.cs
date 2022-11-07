using BWay.Service.DTOs;

namespace BWay.Service.Interfaces
{
    public interface IAtendimentoService
    {
        List<AtendimentoDTO> ObterAtendimentos();
        AtendimentoDTO ObterAtendimento(int id);
        AtendimentoDTO IniciarAtendimento(AtendimentoDTO atendimentoDTO);
        AtendimentoDTO EncerrarAtendimento(int id);
    }
}
