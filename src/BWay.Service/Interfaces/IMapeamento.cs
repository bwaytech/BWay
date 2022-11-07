using BWay.Repository.Models;
using BWay.Service.DTOs;

namespace BWay.Service.Interfaces
{
    public interface IMapeamento
    {
        CorretorRoletaDto MapearCorretorRoletaDto(CorretorRoletaModel corretor);

        CorretorRoletaModel MapearParaCorretorRoletaModel(CorretorRoletaDto corretor);
    }
}
