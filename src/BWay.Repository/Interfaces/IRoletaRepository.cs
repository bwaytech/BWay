using BWay.Repository.Models;

namespace BWay.Repository.Interfaces
{
    public interface IRoletaRepository
    {
        List<CorretorRoletaModel> ObterRoleta(Guid id);
        List<CorretorRoletaModel> ObterRoletaPorOperacao(int idOperacao);
        List<CorretorRoletaModel> SalvarRoleta(List<CorretorRoletaModel> roleta);
        CorretorRoletaModel ObterCorretorSeEstiverDisponivel(Guid idRoleta, int idCorretor);
        CorretorRoletaModel ObterCorretorEmPausa(Guid idRoleta, int idCorretor);
        CorretorRoletaModel ObterCorretorEmAtendimento(Guid idRoleta, int idCorretor);
        void AtualizarRoleta(List<CorretorRoletaModel> roleta);
        void AtualizarRoleta(CorretorRoletaModel corretor);
    }
}
