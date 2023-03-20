using BWay.Infra.Models;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BWay.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        
        [HttpGet("consultar")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult ListarUsuario()
        {
            try
            {
                var retorno = _usuarioService.ListarUsuarios();
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

        [HttpGet("{idUsuario}/consultarPorId")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult ConsultarUsuarioPorId(string idUsuario)
        {
            try
            {
                var retorno = _usuarioService.BuscarUsuarioPorId(idUsuario);
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
        public IActionResult CadastrarUsuario([FromBody] UsuarioModel usuario)
        {
            try
            {
                var retorno = _usuarioService.CadastrarUsuario(usuario);
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

        [HttpPut("{idUsuario}/atualizar")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult AtualizarUsuario(string idUsuario, [FromBody] UsuarioModel usuario)
        {
            try
            {
                var retorno = _usuarioService.AtualizarUsuario(idUsuario, usuario);
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

        [HttpDelete("{idUsuario}/excluir")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult ExcluirUsuario(string idUsuario)
        {
            try
            {
                var retorno = _usuarioService.ExcluirUsuario(idUsuario);
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

        [HttpPost("login")]
        [ProducesResponseType(typeof(UsuarioDTO), StatusCodes.Status200OK)]
        public IActionResult LoginUsuario([FromBody] LoginModel login)
        {
            try
            {
                var retorno = _usuarioService.EfetuarLogin(login);
                if (retorno == null)
                    return Ok("Dados do usuário não encontrados.");

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
