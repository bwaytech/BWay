using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BWay.Api.Controllers
{
    [ApiController]
    [Route("projetos")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        public IEnumerable<ProjetoDTO> GetProjetos()
        {
            var projetos = _projetoService.ObterTodos();
            return projetos;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjetoDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProjeto(int id)
        {
            var projetoSelecionado = _projetoService.ObterProjeto(id);
            return Ok(projetoSelecionado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(ProjetoDTO projeto)
        {
            var projetoCriado = _projetoService.Inserir(projeto);
            return CreatedAtAction(nameof(GetProjeto), new { id = projeto.Id }, projetoCriado);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            _projetoService.Deletar(id);
            return NoContent();
        }
    }
}
