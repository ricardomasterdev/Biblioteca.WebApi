using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Biblioteca.Application.Services;
using Biblioteca.Application.DTOs;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(UsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var usuarios = await _usuarioService.ListarTodosAsync();
            var dto = _mapper.Map<List<UsuarioDto>>(usuarios);
            return Ok(dto);
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var usuario = await _usuarioService.ObterPorIdAsync(id);
            if (usuario == null) return NotFound();

            var dto = _mapper.Map<UsuarioDto>(usuario);
            return Ok(dto);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarUsuarioDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var usuario = _mapper.Map<Usuario>(dto);
            var sucesso = await _usuarioService.AdicionarAsync(usuario);

            if (!sucesso)
                return BadRequest("Já existe um usuário com este e-mail.");

            var retorno = _mapper.Map<UsuarioDto>(usuario);
            return CreatedAtAction(nameof(GetPorId), new { id = usuario.Id }, retorno);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UsuarioDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID da URL e do corpo não coincidem.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Busca o usuário existente no banco
            var usuarioExistente = await _usuarioService.ObterPorIdAsync(id);
            if (usuarioExistente == null)
                return NotFound("Usuário não encontrado.");

            // Atualiza somente os campos que podem ser alterados
            usuarioExistente.Nome = dto.Nome;
            usuarioExistente.Email = dto.Email;
            usuarioExistente.Telefone = dto.Telefone;
            usuarioExistente.Perfil = dto.Perfil;

            // Note: o SenhaHash não é alterado
            await _usuarioService.AtualizarAsync(usuarioExistente);
            return NoContent();
        }
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _usuarioService.RemoverAsync(id);
            return NoContent();
        }

        [Authorize(Roles = "Administrador")]
        // Novo endpoint para buscar usuários por nome
        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorNome([FromQuery] string nome)
        {
            var usuarios = await _usuarioService.BuscarPorNomeAsync(nome);
            var dto = _mapper.Map<List<UsuarioDto>>(usuarios);
            return Ok(dto);
        }

        [HttpGet("quantidade")]
        public async Task<IActionResult> ObterQuantidade()
        {
            var total = await _usuarioService.ObterQuantidadeTotalAsync();
            return Ok(new { total });
        }
    }
}
