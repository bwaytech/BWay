using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BWay.Api.Controllers
{
    [Route("/roletas")]
    public class CorretorController : Controller
    {
        private readonly ICorretorService _corretorService;

        public CorretorController(ICorretorService corretorService)
        {
            _corretorService = corretorService;
        }

        [HttpPut("{idRoleta}/corretores/{idCorretor}/entrarEmPausa")]
        public CorretorRoletaDto EntrarEmPausa([FromRoute] Guid idRoleta, [FromRoute] int idCorretor)
        {
            return _corretorService.EntrarEmPausa(idRoleta, idCorretor);
        }

        [HttpPut("{idRoleta}/corretores/{idCorretor}/voltarDaPausa")]
        public CorretorRoletaDto VoltarDaPausa([FromRoute] Guid idRoleta, [FromRoute] int idCorretor)
        {
            return _corretorService.VoltarDaPausa(idRoleta, idCorretor);
        }

        [HttpPut("{idRoleta}/corretores/{idCorretor}/tornarDisponivel")]
        public CorretorRoletaDto TornarDisponivel([FromRoute] Guid idRoleta, [FromRoute] int idCorretor)
        {
            return _corretorService.TornarDisponivel(idRoleta, idCorretor);
        }
    }
}
