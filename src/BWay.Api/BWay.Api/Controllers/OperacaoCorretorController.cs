using BWay.Api.Models;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BWay.Api.Controllers
{
    [Route("/operacaoCorretores")]
    public class OperacaoCorretorController : ControllerBase
    {
        private readonly IOperacaoCorretorService _operacaoCorretorService;
        private Envelope<OperacaoCorretorDTO> envelope = new Envelope<OperacaoCorretorDTO>();

        public OperacaoCorretorController(IOperacaoCorretorService operacaoCorretorService)
        {
            _operacaoCorretorService = operacaoCorretorService;
        }

        [HttpPost]
        public IActionResult EfetuarCheckIn([FromBody] OperacaoCorretorDTO operacaoCorretorDTO)
        {
            var operacaoCorretor = _operacaoCorretorService.CheckIn(operacaoCorretorDTO);

            if (operacaoCorretor == null)
            {
                envelope.Message = "Não foi possível fazer o check-in.";
                return BadRequest(envelope);
            }

            envelope.Data = operacaoCorretor;

            return Ok(envelope);
        }

        [HttpPut("{id:int}/checkout")]
        public IActionResult EfetuarCheckout(int id)
        {
            var operacaoCorretor = _operacaoCorretorService.ObterOperacaoCorretor(id);

            if (operacaoCorretor == null)
            {
                envelope.Message = "Operacao não encontrada.";
                return NotFound(envelope);
            }

            if (operacaoCorretor.CheckoutJaRealizado())
            {
                envelope.Message = "Checkout já realizado";
                return BadRequest(envelope);
            }

            envelope.Data = _operacaoCorretorService.CheckOut(id);

            return Ok(envelope);
        }

        [HttpGet]
        public IActionResult ObterOperacaoCorretores()
        {
            var operacaoCorretores = _operacaoCorretorService.ObterOperacaoCorretores();
            Envelope<List<OperacaoCorretorDTO>> envelopeLista = new Envelope<List<OperacaoCorretorDTO>>();

            envelopeLista.Data = operacaoCorretores;

            return Ok(envelopeLista);
        }
    }
}
