using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly BibliotecaDbContext _context;

        public LocacaoRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Locacao locacao)
        {
            _context.Locacoes.Add(locacao);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Locacao locacao)
        {
            _context.Locacoes.Update(locacao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Locacao>> ListarTodasAsync()
        {
            return await _context.Locacoes
                .Include(l => l.Livro)
                .Include(l => l.Usuario)
                .OrderByDescending(l => l.Id)
                .ToListAsync();
        }

        public async Task<List<Locacao>> ListarPorUsuarioAsync(int usuarioId)
        {
            return await _context.Locacoes
                .Where(l => l.UsuarioId == usuarioId)
                .Include(l => l.Livro)
                .OrderByDescending(l => l.Id)
                .ToListAsync();
        }

        public async Task<List<Locacao>> ListarPendentesAsync()
        {
            return await _context.Locacoes
                .Where(l => l.DataDevolucaoReal == null)
                .Include(l => l.Livro)
                .ToListAsync();
        }

        public async Task<Locacao> ObterPorIdAsync(int id)
        {
            return await _context.Locacoes
                .Include(l => l.Livro)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Locacao>> LivrosMaisLocadosAsync()
        {
            return await _context.Locacoes
                .GroupBy(l => l.LivroId)
                .Select(g => new Locacao
                {
                    LivroId = g.Key,
                    Livro = g.First().Livro
                })
                .Take(10)
                .ToListAsync();
        }

        public async Task ExecutarProcedureAsync(string procedureName, int locacaoId)
        {
            var parametro = new SqlParameter("@LocacaoId", locacaoId);
            await _context.Database.ExecuteSqlRawAsync($"EXEC {procedureName} @LocacaoId", parametro);
        }

        public async Task<(int emAndamento, int finalizadas, int canceladas)> ObterTotaisPorStatusAsync()
        {
            var emAndamento = await _context.Locacoes.CountAsync(l => l.Status == 0);
            var finalizadas = await _context.Locacoes.CountAsync(l => l.Status == 1);
            var canceladas = await _context.Locacoes.CountAsync(l => l.Status == 2);

            return (emAndamento, finalizadas, canceladas);
        }

        // Outras implementações de métodos omitidos para brevidade...

        public async Task<Dictionary<string, int>> ObterLivrosMaisLocadosAsync()
        {
            return await _context.Locacoes
                .Include(l => l.Livro) // Carrega os detalhes do livro
                .Where(l => l.Status == 1) // Usa o filtro desejado (ajuste conforme sua lógica)
                .GroupBy(l => l.Livro.Titulo)
                .Select(g => new { Livro = g.Key, Quantidade = g.Count() })
                .OrderByDescending(x => x.Quantidade)
                .ToDictionaryAsync(x => x.Livro, x => x.Quantidade);
        }

        public async Task<Dictionary<string, int>> ObterClientesComMaisEmprestimosAsync()
        {
            return await _context.Locacoes
                .Include(l => l.Usuario) // Carrega os dados do usuário relacionado
                .GroupBy(l => l.Usuario.Nome) // Agrupa por nome do usuário (pode ser alterado para outro identificador único, se necessário)
                .Select(g => new { Usuario = g.Key, Quantidade = g.Count() })
                .OrderByDescending(x => x.Quantidade)
                .ToDictionaryAsync(x => x.Usuario, x => x.Quantidade);
        }

        public async Task<List<Locacao>> BuscarLocacoesAsync(string nomeLivro, string nomeUsuario, int? status)
        {
            var query = _context.Locacoes
                        .Include(l => l.Livro)
                        .Include(l => l.Usuario)
                        .AsQueryable();

            // Aplica filtro por nome do livro, se informado.
            if (!string.IsNullOrWhiteSpace(nomeLivro))
            {
                query = query.Where(l => EF.Functions.Like(l.Livro.Titulo, $"%{nomeLivro.Trim()}%"));
            }

            // Aplica filtro por nome do usuário, se informado.
            if (!string.IsNullOrWhiteSpace(nomeUsuario))
            {
                query = query.Where(l => EF.Functions.Like(l.Usuario.Nome, $"%{nomeUsuario.Trim()}%"));
            }

            // Aplica filtro por status, se informado.
            if (status.HasValue)
            {
                query = query.Where(l => l.Status == status.Value);
            }

            return await query.ToListAsync();
        }


    }
}
