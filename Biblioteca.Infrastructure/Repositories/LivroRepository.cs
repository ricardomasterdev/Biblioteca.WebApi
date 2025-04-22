using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaDbContext _context;

        public LivroRepository(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> ListarTodosAsync() =>
            await _context.Livros.ToListAsync();

        public async Task<Livro> ObterPorIdAsync(int id) =>
            await _context.Livros.FindAsync(id);

        public async Task<List<Livro>> PesquisarAsync(string termo) =>
            await _context.Livros
                .Where(l => l.Titulo.Contains(termo) || l.Autor.Contains(termo) || l.ISBN.Contains(termo))
                .ToListAsync();

        public async Task AdicionarAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
        }
        public IQueryable<Livro> Query()
        {
            return _context.Livros.AsQueryable();
        }

        public async Task<int> ObterQuantidadeTotalAsync()
        {
            return await _context.Livros.CountAsync();
        }

        public async Task<bool> ExisteISBNAsync(string isbn) =>
            await _context.Livros.AnyAsync(l => l.ISBN == isbn);
    }
}
