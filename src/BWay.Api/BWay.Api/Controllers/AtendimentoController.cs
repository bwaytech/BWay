using BWay.Api.Models;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BWay.Api.Controllers
{
    [Route("/atendimentos")]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;
        private Envelope<AtendimentoDTO> envelope = new Envelope<AtendimentoDTO>();

        public AtendimentoController(IAtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        [HttpPost]
        public IActionResult IniciarAtendimento([FromBody] AtendimentoDTO atendimentoDTO)
        {
            var atendimento = _atendimentoService.IniciarAtendimento(atendimentoDTO);

            if (atendimento == null)
            {
                envelope.Message = "Não foi possível iniciar o atendimento";
                return BadRequest(envelope);
            }

            envelope.Data = atendimento;
            return Ok(envelope);
        }

        [HttpPut("{id:int}/encerrar")]
        public IActionResult EncerrarAtendimento(int id)
        {
            var atendimento = _atendimentoService.EncerrarAtendimento(id);

            if (atendimento == null)
            {
                envelope.Message = "Não foi possível encerrar o atendimento";
                return BadRequest(envelope);
            }

            envelope.Data = atendimento;
            return Ok(envelope);
        }

        [HttpGet]
        public IActionResult ObterAtendimentos()
        {
            var atendimentos = _atendimentoService.ObterAtendimentos();
            Envelope<List<AtendimentoDTO>> envelope = new Envelope<List<AtendimentoDTO>>();
            envelope.Data = atendimentos;

            return Ok(envelope);
        }

        [HttpGet("{id:int}")]
        public IActionResult ObterAtendimento(int id)
        {
            var atendimento = _atendimentoService.ObterAtendimento(id);

            if (atendimento == null)
            {
                envelope.Message = $"Atendimento não encontrado para o id: {id}";
                return NotFound(envelope);
            }

            envelope.Data = atendimento;
            return Ok(envelope);
        }
    }
}
