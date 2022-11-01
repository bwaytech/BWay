using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BWay.Api.Controllers
{
    [ApiController]
    [Route("plantoes")]
    public class PlantaoController : ControllerBase
    {
        private readonly IPlantaoService _plantaoService;

        public PlantaoController(IPlantaoService plantaoService)
        {
            _plantaoService = plantaoService;
        }

        [HttpGet]
        public IEnumerable<PlantaoDTO> GetPlantoes()
        {
            var plantoes = _plantaoService.ObterTodos();

            return plantoes;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlantaoDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPlantao(int id)
        {
            var plantaoSelecionado = _plantaoService.ObterPlantao(id);
            return Ok(plantaoSelecionado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(PlantaoDTO plantao)
        {
            var plantaoCriado = _plantaoService.Inserir(plantao);
            return CreatedAtAction(nameof(GetPlantao), new { id = plantao.IdPlantao }, plantaoCriado);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var plantao = _plantaoService.ObterPlantao(id);

            if (plantao == null) return NotFound();

            _plantaoService.Deletar(id);

            return NoContent();
        }
    }
}
