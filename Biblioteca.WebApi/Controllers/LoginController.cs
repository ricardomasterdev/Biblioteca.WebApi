using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Biblioteca.Application.DTOs;
using Biblioteca.Domain.Entities;
using Biblioteca.Application.Services;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public LoginController(UsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Busca o usuário pelo e-mail
            var usuario = await _usuarioService.ObterPorEmailAsync(dto.Email);
            if (usuario == null)
                return Unauthorized("Usuário não encontrado.");

            // Verifica a senha: gera o hash da senha enviada e compara com o SenhaHash armazenado
            string senhaHash = GerarHash(dto.Senha);
            if (usuario.SenhaHash != senhaHash)
                return Unauthorized("Senha incorreta.");

            // Gera o token JWT
            string token = GerarToken(usuario);
            var loginResult = new LoginResultDto { Token = token };

            return Ok(loginResult);
        }

        // Método para gerar o hash usando SHA256
        private string GerarHash(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        // Método para gerar o token JWT
        private string GerarToken(Usuario usuario)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define a role com base no perfil. Por exemplo, 0 = Administrador, 1 = Usuário Padrão
            var role = usuario.Perfil == 0 ? "Administrador" : "Usuario";

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
        new Claim("nome", usuario.Nome),
        new Claim(ClaimTypes.Role, role),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
