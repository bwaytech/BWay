using BWay.Infra.DTOs;
using BWay.Infra.Models;
using BWay.Service.Interfaces;
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


        #region LocalizacaoPlantao
        [HttpGet("localizacaoplantao/consultar")]
        [ProducesResponseType(typeof(List<LocalizacaoPlantaoDTO>), StatusCodes.Status200OK)]
        public IActionResult ListarLocalizacaoPlantao()
        {
            try
            {
                var retorno = _plantaoService.ListarLocalizacaoPlantao();
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }

        [HttpGet("localizacaoplantao/consultarPorId/{idLocalizacaoPlantao}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult BuscarLocalizacaoPlantaoPorId(string idLocalizacaoPlantao)
        {
            try
            {
                var retorno = _plantaoService.BuscarLocalizacaoPlantaoPorId(idLocalizacaoPlantao);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }

        [HttpPost("localizacaoplantao/cadastrar")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        public IActionResult CadastrarLocalizacaoPlantao([FromBody] LocalizacaoPlantaoModel localizacaoPlantao)
        {
            try
            {
                var retorno = _plantaoService.CadastrarLocalizacaoPlantao(localizacaoPlantao);
                return Created("cadastrar", retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }

        [HttpPut("localizacaoplantao/atualizar/{idLocalizacaoPlantao}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult AtualizarLocalizacaoPlantao(string idLocalizacaoPlantao, [FromBody] LocalizacaoPlantaoModel localizacaoPlantao)
        {
            try
            {
                var retorno = _plantaoService.AtualizarLocalizacaoPlantao(idLocalizacaoPlantao, localizacaoPlantao);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }

        [HttpDelete("localizacaoplantao/excluir/{idLocalizacaoPlantao}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult ExcluirLocalizacaoPlantao(string idLocalizacaoPlantao)
        {
            try
            {
                var retorno = _plantaoService.ExcluirLocalizacaoPlantao(idLocalizacaoPlantao);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }
        #endregion


        #region Plantao
        [HttpGet("consultar")]
        [ProducesResponseType(typeof(List<PlantaoDTO>), StatusCodes.Status200OK)]
        public IActionResult ListarPlantao()
        {
            try
            {
                var retorno = _plantaoService.ListarPlantao();
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }

        [HttpGet("consultarPorId/{idPlantao}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult BuscarPlantaoPorId(string idPlantao)
        {
            try
            {
                var retorno = _plantaoService.BuscarPlantaoPorId(idPlantao);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }

        [HttpPost("cadastrar")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        public IActionResult CadastrarPlantao([FromBody] PlantaoModel plantao)
        {
            try
            {
                var retorno = _plantaoService.CadastrarPlantao(plantao);
                return Created("cadastrar", retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }

        [HttpPut("atualizar/{idPlantao}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult AtualizarPlantao(string idPlantao, [FromBody] PlantaoModel plantao)
        {
            try
            {
                var retorno = _plantaoService.AtualizarPlantao(idPlantao, plantao);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }

        [HttpDelete("excluir/{idPlantao}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult ExcluirPlantao(string idPlantao)
        {
            try
            {
                var retorno = _plantaoService.ExcluirPlantao(idPlantao);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }

        }
        #endregion

    }
}
