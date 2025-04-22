using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Application.DTOs; // Necessário para LivroMaisLocadoDTO
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Microsoft.EntityFrameworkCore; // Necessário para usar .ToListAsync()

namespace Biblioteca.Application.Services
{
    public class LivroService
    {
        private readonly ILivroRepository _livroRepo;
        private readonly ILocacaoRepository _locacaoRepo;

        // Construtor único que injeta ambas as dependências.
        public LivroService(ILivroRepository livroRepo, ILocacaoRepository locacaoRepo)
        {
            _livroRepo = livroRepo;
            _locacaoRepo = locacaoRepo;
        }

        public async Task<List<Livro>> ListarTodosAsync()
        {
            return await _livroRepo.ListarTodosAsync();
        }

        public async Task<Livro?> ObterPorIdAsync(int id)
        {
            return await _livroRepo.ObterPorIdAsync(id);
        }

        public async Task<bool> AdicionarAsync(Livro livro)
        {
            if (await _livroRepo.ExisteISBNAsync(livro.ISBN))
                return false;

            await _livroRepo.AdicionarAsync(livro);
            return true;
        }

        public async Task AtualizarAsync(Livro livro)
        {
            await _livroRepo.AtualizarAsync(livro);
        }

        public async Task RemoverAsync(int id)
        {
            await _livroRepo.RemoverAsync(id);
        }

        public async Task<List<Livro>> PesquisarAsync(string termo)
        {
            return await _livroRepo.PesquisarAsync(termo);
        }

        public async Task<List<Livro>> ConsultarAsync(string? titulo, string? autor, int pagina, int tamanhoPagina)
        {
            var query = _livroRepo.Query();

            if (!string.IsNullOrWhiteSpace(titulo))
                query = query.Where(l => l.Titulo.Contains(titulo));

            if (!string.IsNullOrWhiteSpace(autor))
                query = query.Where(l => l.Autor.Contains(autor));

            return await query
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();
        }

        public async Task<int> ObterQuantidadeTotalAsync()
        {
            return await _livroRepo.ObterQuantidadeTotalAsync();
        }

        // Método que obtém o relatório de livros mais locados sem usar DTO
        public async Task<Dictionary<string, int>> ObterLivrosMaisLocadosAsync()
        {
            return await _locacaoRepo.ObterLivrosMaisLocadosAsync();
        }

    }
}
