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

        //[HttpGet]
        //[Authorize(Roles = "gerente")]
        //public IEnumerable<UsuarioDTO> GetUsuarios()
        //{
        //    var usuarios = _usuarioService.ObterTodos();
        //    return usuarios;
        //}

        //[HttpGet("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDTO))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        //public IActionResult GetUsuario(int id)
        //{
        //    var usuarioSelecionado = _usuarioService.ObterUsuario(id);
        //    return Ok(usuarioSelecionado);
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[Authorize]
        //public IActionResult Post(UsuarioDTO usuario)
        //{
        //    _usuarioService.Inserir(usuario);
        //    return CreatedAtAction(nameof(GetUsuario), new { id = usuario.IdUsuario }, usuario);
        //}

        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize(Roles = "gerente")]
        //public IActionResult Delete(int id)
        //{
        //    _usuarioService.Deletar(id);
        //    return NoContent();
        //}

        [HttpPost("cadastrar")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
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
    }
}
