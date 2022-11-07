using BWay.Service.DTOs;

namespace BWay.Service.Interfaces
{
    public interface IRoletaService
    {
        LinkedList<CorretorRoletaDto> MontarRoleta(OperacaoCorretorDTO operacaoCorretorDto, List<CorretorDTO> corretoresElegiveisSorteio, List<CorretorDTO> corretoresElegiveisAtendimento);
        LinkedList<CorretorRoletaDto> ObterRoleta(Guid id);
        List<CorretorRoletaDto> Mover(Guid idRoleta);
        void AtualizarRoleta(List<CorretorRoletaDto> roleta);
        void AtualizarRoleta(CorretorRoletaDto corretor);
        CorretorRoletaDto ObterCorretorSeEstiverDisponivel(Guid idRoleta, int idCorretor);
        CorretorRoletaDto ObterCorretorEmPausa(Guid idRoleta, int idCorretor);
        CorretorRoletaDto ObterCorretorEmAtendimento(Guid idRoleta, int idCorretor);
    }
}
