using BWay.Infra.Exceptions;
using BWay.Repository.Interfaces;
using BWay.Repository.Models;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BWay.Service.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacaoService(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public TokenDTO AutenticarUsuario(string login, string senha)
        {
            var usuario = _usuarioRepository.AutenticarLogin(login, senha);

            if (usuario == null) throw new HttpImobException(HttpStatusCode.NotFound, "Usuario ou senha inválidos.");

            return new TokenDTO
            {
                Token = GerarToken(usuario)
            };
        }

        private string GerarToken(UsuarioModel model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                    new Claim(ClaimTypes.Role, model.Perfil)
                }),
                Expires = DateTime.UtcNow.AddHours(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
