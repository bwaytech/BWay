using BWay.Api.Models;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BWay.Api.Controllers
{
    [Route("/roletas")]
    public class RoletaController : Controller
    {
        private readonly IRoletaService _roletaService;
        private readonly IOperacaoCorretorService _operacaoCorretorService;

        public RoletaController(IRoletaService roletaService, IOperacaoCorretorService operacaoCorretorService)
        {
            _roletaService = roletaService;
            _operacaoCorretorService = operacaoCorretorService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(List<CorretorRoletaDto>), StatusCodes.Status200OK)]
        public IActionResult MontarRoleta([FromBody][Required] OperacaoCorretorDTO operacaoCorretorDto)
        {
            Envelope<LinkedList<CorretorRoletaDto>> envelope = new Envelope<LinkedList<CorretorRoletaDto>>();

            List<CorretorDTO> corretoresElegiveisSorteio = _operacaoCorretorService.ObterCorretoresElegiveisSorteio(operacaoCorretorDto.IdOperacao);

            if (!corretoresElegiveisSorteio.Any())
            {
                envelope.Message = "Não existem corretores elegíveis ao sorteio";
                return NotFound(envelope);
            }

            List<CorretorDTO> corretoresElegiveisAtendimento = _operacaoCorretorService.ObterCorretoresElegiveisAtendimento(operacaoCorretorDto.IdOperacao);

            if (!corretoresElegiveisAtendimento.Any())
            {
                envelope.Message = "Não existem corretores elegíveis ao atendimento";
                return NotFound(envelope);
            }

            envelope.Data = _roletaService.MontarRoleta(operacaoCorretorDto, corretoresElegiveisSorteio, corretoresElegiveisAtendimento);
            return Ok(envelope);
        }

        [HttpGet("{id}")]
        public IActionResult ObterRoleta(Guid id)
        {
            var roleta = _roletaService.ObterRoleta(id);
            return Ok(roleta);
        }

        [HttpPut("{id}/mover")]
        public IActionResult MoverRoleta(Guid id)
        {
            var roleta = _roletaService.Mover(id);
            return Ok(roleta);
        }
    }
}
