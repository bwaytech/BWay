using BWay.Service.DTOs;

namespace BWay.Service.Interfaces
{
    public interface ICorretorService
    {
        CorretorRoletaDto EntrarEmPausa(Guid idRoleta, int idCorretor);
        CorretorRoletaDto VoltarDaPausa(Guid idRoleta, int idCorretor);
        CorretorRoletaDto TornarDisponivel(Guid idRoleta, int idCorretor);
    }
}
