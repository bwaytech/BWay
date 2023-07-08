using BWay.Infra.Models;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using BWay.Service.Services;
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

        [HttpGet("consultar")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult ListarProjetos()
        {
            try
            {
                var retorno = _projetoService.ListarProjetos();
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

        [HttpGet("consultarPorId/{idProjeto}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult ConsultarProjetoPorId(string idProjeto)
        {
            try
            {
                var retorno = _projetoService.BuscarProjetoPorId(idProjeto);
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
        public IActionResult CadastrarProjeto([FromBody] ProjetoModel projeto)
        {
            try
            {
                var retorno = _projetoService.CadastrarProjeto(projeto);
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

        [HttpPut("atualizar/{idProjeto}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult AtualizarUsuario(string idProjeto, [FromBody] ProjetoModel projeto)
        {
            try
            {
                var retorno = _projetoService.AtualizarProjeto(idProjeto, projeto);
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

        [HttpDelete("excluir/{idProjeto}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult ExcluirProjeto(string idProjeto)
        {
            try
            {
                var retorno = _projetoService.ExcluirProjeto(idProjeto);
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
    }
}
