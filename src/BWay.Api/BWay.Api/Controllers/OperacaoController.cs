using BWay.Api.Models;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BWay.Api.Controllers
{
    [Route("/operacoes")]
    public class OperacaoController : ControllerBase
    {
        public readonly IOperacaoCorretorService _operacaoCorretorService;
        public readonly IOperacaoService _operacaoService;

        private Envelope<OperacaoDTO> envelope = new Envelope<OperacaoDTO>();

        public OperacaoController(IOperacaoService operacaoService, IOperacaoCorretorService operacaoCorretorService)
        {
            _operacaoCorretorService = operacaoCorretorService;
            _operacaoService = operacaoService;
        }

        [HttpGet]
        public IActionResult GetOperacoes()
        {
            var operacoes = _operacaoService.ObterOperacoes();

            Envelope<List<OperacaoDTO>> envelopeListaOperacoes = new Envelope<List<OperacaoDTO>>();
            envelopeListaOperacoes.Data = operacoes;

            return Ok(envelopeListaOperacoes);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOperacao(int id)
        {
            var operacao = _operacaoService.ObterOperacaoAberta(id);

            if (operacao == null)
            {
                envelope.Message = $"Não foi possível achar uma operação para o id: {id}.";
                return NotFound(envelope);
            }

            envelope.Data = operacao;

            return Ok(envelope);
        }

        [HttpPost]
        public IActionResult CriarOperacao([FromBody] OperacaoDTO operacao)
        {
            // TODO: Criar validação de campos para operação
            return Ok(_operacaoService.CriarOperacao(operacao));
        }

        [HttpPut("{id:int}/abrirOperacao")]
        public IActionResult AbrirOperacao(int id)
        {
            var operacao = _operacaoService.ObterOperacao(id);

            if (operacao == null)
            {
                envelope.Message = $"Não existe uma operação pendente de abertura com o id: {id}.";
                return NotFound(envelope);
            }

            if (operacao.OperacaoEstaAberta())
            {
                envelope.Message = "A operação já está aberta.";
                return BadRequest(envelope);
            }

            envelope.Data = _operacaoService.AbrirOperacao(id);

            return Ok(envelope);
        }

        [HttpPut("{id:int}/fecharOperacao")]
        public IActionResult FecharOperacao(int id)
        {
            var operacao = _operacaoService.ObterOperacaoAberta(id);

            if (operacao == null)
            {
                envelope.Message = $"Não existe uma operação pendente de fechamento com o id: {id}.";
                return NotFound(envelope);
            }

            if (operacao.OperacaoEstaFechada())
            {
                envelope.Message = "A operação já está fechada.";
                return BadRequest(envelope);
            }

            return Ok(_operacaoService.FecharOperacao(id));
        }

        [HttpGet("{id:int}/elegiveisAoSorteio")]
        public IActionResult ObterCorretoresElegiveisAoSorteio(int id)
        {
            Envelope<List<CorretorDTO>> envelope = new Envelope<List<CorretorDTO>>();

            var operacao = _operacaoService.ObterOperacaoAberta(id);

            if (operacao == null)
            {
                envelope.Message = $"Operação não encontrada.";
                return NotFound(envelope);
            }

            List<CorretorDTO> corretores = _operacaoCorretorService.ObterCorretoresElegiveisSorteio(id);

            if (!corretores.Any())
            {
                envelope.Message = "Não existem corretores elegíveis ao sorteio";
                return NotFound(envelope);
            }

            envelope.Data = corretores;
            return Ok(envelope);
        }

        [HttpGet("{id:int}/elegiveisAoAtendimento")]
        public IActionResult ObterCorretoresElegiveisAoAtendimento(int id)
        {
            Envelope<List<CorretorDTO>> envelope = new Envelope<List<CorretorDTO>>();

            var operacao = _operacaoService.ObterOperacaoAberta(id);

            if (operacao == null)
            {
                envelope.Message = $"Operação não encontrada.";
                return NotFound(envelope);
            }

            List<CorretorDTO> corretores = _operacaoCorretorService.ObterCorretoresElegiveisAtendimento(id);

            if (!corretores.Any())
            {
                envelope.Message = "Não existem corretores elegíveis ao atendimento";
                return NotFound(envelope);
            }

            envelope.Data = corretores;
            return Ok(envelope);
        }
    }
}
