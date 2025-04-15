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
    public class LocacoesController : ControllerBase
    {
        private readonly LocacaoService _locacaoService;
        private readonly IMapper _mapper;

        public LocacoesController(LocacaoService locacaoService, IMapper mapper)
        {
            _locacaoService = locacaoService;
            _mapper = mapper;
        }
        //[Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> GetTodas()
        {
            var locacoes = await _locacaoService.ListarTodasAsync();
            var dto = _mapper.Map<List<DetalhesLocacaoDto>>(locacoes);
            return Ok(dto);
        }

        //[Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var locacao = await _locacaoService.ObterPorIdAsync(id);
            if (locacao == null)
                return NotFound();

            var dto = _mapper.Map<DetalhesLocacaoDto>(locacao);
            return Ok(dto);
        }

        //[Authorize(Roles = "Administrador")]
        [HttpGet("pendentes")]
        public async Task<IActionResult> GetPendentes()
        {
            var locacoes = await _locacaoService.ListarPendentesAsync();
            var dto = _mapper.Map<List<DetalhesLocacaoDto>>(locacoes);
            return Ok(dto);
        }

        //[Authorize(Roles = "Administrador,Usuario")]
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetPorUsuario(int usuarioId)
        {
            var locacoes = await _locacaoService.ListarPorUsuarioAsync(usuarioId);
            var dto = _mapper.Map<List<DetalhesLocacaoDto>>(locacoes);
            return Ok(dto);
        }

        //[Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarLocacaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var locacao = _mapper.Map<Locacao>(dto);

            var sucesso = await _locacaoService.RegistrarLocacaoAsync(locacao);
            if (!sucesso)
                return BadRequest("Não foi possível registrar a locação.");

            var locacaoInserida = await _locacaoService.ObterPorIdAsync(locacao.Id);
            var retorno = _mapper.Map<DetalhesLocacaoDto>(locacaoInserida);
            return CreatedAtAction(nameof(GetPorId), new { id = locacaoInserida.Id }, retorno);
        }

        
        //[Authorize(Roles = "Administrador")]
        [HttpPatch("cancelar")]
        public async Task<IActionResult> CancelarLocacao([FromBody] CancelaLocacaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sucesso = await _locacaoService.AtualizarStatusAsync(dto.Id, dto.Status);
            if (!sucesso)
                return NotFound("Locação não encontrada ou erro ao atualizar o status.");

            return NoContent();
        }

        //[Authorize(Roles = "Administrador")]
        [HttpPost("renovar")]
        public async Task<IActionResult> RenovarLocacao([FromBody] RenovaLocacaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var sucesso = await _locacaoService.RenovarLocacaoAsync(dto);
                if (!sucesso)
                    return BadRequest("Não foi possível renovar a locação (verifique o ID informado).");

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro interno: {ex.Message}");
            }
        }

        //[Authorize(Roles = "Administrador")]
        [HttpPost("devolver")]
        public async Task<IActionResult> DevolverLocacao([FromBody] FinalizaLocacaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var sucesso = await _locacaoService.FinalizaLocacaoAsync(dto);
                if (!sucesso)
                    return BadRequest("Não foi possível finalizar a locação (verifique o ID informado).");

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("status-quantidade")]
        public async Task<IActionResult> ObterTotaisPorStatus()
        {
            var (emAndamento, finalizadas, canceladas) = await _locacaoService.ObterTotaisPorStatusAsync();

            return Ok(new
            {
                emAndamento,
                finalizadas,
                canceladas
            });
        }


        // Retorna os clientes com mais empréstimos
        [HttpGet("clientes-mais-emprestimos")]
        public async Task<IActionResult> ClientesMaisEmprestimos()
        {
            Dictionary<string, int> clientes = await _locacaoService.ObterClientesComMaisEmprestimosAsync();
            return Ok(clientes);
        }

        [Authorize(Roles = "Administrador,Usuario")]
        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar(
    [FromQuery] string? nomeLivro,
    [FromQuery] string? nomeUsuario,
    [FromQuery] int? status)
        {
            var locacoes = await _locacaoService.BuscarLocacoesAsync(nomeLivro, nomeUsuario, status);
            var dto = _mapper.Map<List<DetalhesLocacaoDto>>(locacoes);
            return Ok(dto);
        }

        //[Authorize(Roles = "Administrador,Usuario")]
        [HttpGet("status-quantidade/{usuarioId}")]
        public async Task<IActionResult> StatusQuantidadePorUsuario(int usuarioId)
        {
            // Busca todas as locações do usuário
            var locacoes = await _locacaoService.ListarPorUsuarioAsync(usuarioId);

            // Calcula os totais para cada status (supondo que 0=Em Andamento, 1=Finalizadas, 2=Canceladas)
            int emAndamento = locacoes.Count(l => l.Status == 0);
            int finalizadas = locacoes.Count(l => l.Status == 1);
            int canceladas = locacoes.Count(l => l.Status == 2);

            var resultado = new
            {
                emAndamento,
                finalizadas,
                canceladas
            };

            return Ok(resultado);
        }


    }
}