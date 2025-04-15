using Microsoft.AspNetCore.Mvc;
using AutoMapper; // ✅ AutoMapper
using Biblioteca.Application.Services;
using Biblioteca.Application.DTOs;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivroService _livroService;
        private readonly IMapper _mapper;

        public LivrosController(LivroService livroService, IMapper mapper)
        {
            _livroService = livroService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var livros = await _livroService.ListarTodosAsync();
            var dto = _mapper.Map<List<LivroDto>>(livros);
            return Ok(dto);
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var livro = await _livroService.ObterPorIdAsync(id);
            if (livro == null) return NotFound();

            var dto = _mapper.Map<LivroDto>(livro);
            return Ok(dto);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarLivroDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var livro = _mapper.Map<Livro>(dto);
            var sucesso = await _livroService.AdicionarAsync(livro);

            if (!sucesso)
                return BadRequest("Já existe um livro com este ISBN.");

            var retorno = _mapper.Map<LivroDto>(livro);
            return CreatedAtAction(nameof(GetPorId), new { id = livro.Id }, retorno);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] LivroDto dto)
        {
            if (id != dto.Id) return BadRequest("ID da URL e do corpo não coincidem.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var livro = _mapper.Map<Livro>(dto);
            await _livroService.AtualizarAsync(livro);
            return NoContent();
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _livroService.RemoverAsync(id);
            return NoContent();
        }

        //[Authorize(Roles = "Administrador")]
        [HttpGet("consultar")]
        public async Task<IActionResult> Consultar([FromQuery] ConsultaLivroDto dto)
        {
            var livros = await _livroService.ConsultarAsync(dto.Titulo, dto.Autor, dto.Pagina, dto.TamanhoPagina);
            var resultado = _mapper.Map<List<LivroDto>>(livros);
            return Ok(resultado);
        }

        //[Authorize(Roles = "Administrador")]
        [HttpGet("pesquisar")]
        public async Task<IActionResult> Pesquisar([FromQuery] string termo)
        {
            var livros = await _livroService.PesquisarAsync(termo);
            var dto = _mapper.Map<List<LivroDto>>(livros);
            return Ok(dto);
        }

        [HttpGet("quantidade")]
        public async Task<IActionResult> ObterQuantidade()
        {
            var total = await _livroService.ObterQuantidadeTotalAsync();
            return Ok(new { total });
        }

        [HttpGet("mais-locados")]
        public async Task<IActionResult> GetLivrosMaisLocados()
        {
            Dictionary<string, int> relatorio = await _livroService.ObterLivrosMaisLocadosAsync();
            return Ok(relatorio);
        }
    }
}
