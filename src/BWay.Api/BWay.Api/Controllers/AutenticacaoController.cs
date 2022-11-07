using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BWay.Api.Controllers
{
    [ApiController]
    [Route("autenticacao")]
    public class AutenticacaoController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;
        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public IActionResult AutenticarUsuario(AutenticacaoDTO autenticacao)
        {
            var retorno = _autenticacaoService.AutenticarUsuario(autenticacao.Login, autenticacao.Senha);
            return Ok(retorno);
        }
    }
}
