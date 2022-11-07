using BWay.Repository.Enums;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;

namespace BWay.Service.Services
{
    public class CorretorService : ICorretorService
    {
        private readonly IRoletaService _roletaService;

        public CorretorService(IRoletaService roletaService)
        {
            _roletaService = roletaService;
        }

        public CorretorRoletaDto EntrarEmPausa(Guid idRoleta, int idCorretor)
        {
            var corretor = _roletaService.ObterCorretorSeEstiverDisponivel(idRoleta, idCorretor);
            corretor.StatusCorretor = StatusCorretorEnum.EmPausa;

            _roletaService.AtualizarRoleta(corretor);

            return corretor;
        }

        public CorretorRoletaDto VoltarDaPausa(Guid idRoleta, int idCorretor)
        {
            var corretor = _roletaService.ObterCorretorEmPausa(idRoleta, idCorretor);
            corretor.StatusCorretor = StatusCorretorEnum.Disponivel;

            _roletaService.AtualizarRoleta(corretor);

            return corretor;
        }

        public CorretorRoletaDto TornarDisponivel(Guid idRoleta, int idCorretor)
        {
            var corretor = _roletaService.ObterCorretorEmAtendimento(idRoleta, idCorretor);
            corretor.StatusCorretor = StatusCorretorEnum.Disponivel;

            _roletaService.AtualizarRoleta(corretor);

            return corretor;
        }
    }
}
