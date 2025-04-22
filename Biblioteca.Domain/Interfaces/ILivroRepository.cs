using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces
{
    // Interfaces/ILivroRepository.cs
    public interface ILivroRepository
    {
        Task<Livro> ObterPorIdAsync(int id);
        Task<List<Livro>> ListarTodosAsync();
        Task<List<Livro>> PesquisarAsync(string termo);
        Task AdicionarAsync(Livro livro);
        Task AtualizarAsync(Livro livro);
        Task RemoverAsync(int id);
        Task<bool> ExisteISBNAsync(string isbn);

        Task<int> ObterQuantidadeTotalAsync();

        IQueryable<Livro> Query();


    }



}
