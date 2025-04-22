using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorIdAsync(int id);
        Task<Usuario> ObterPorEmailAsync(string email);
        Task<List<Usuario>> ListarTodosAsync();
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task RemoverAsync(int id);
        Task<bool> ExisteEmailAsync(string email);
        // Novo método para buscar usuários por nome
        Task<List<Usuario>> BuscarPorNomeAsync(string nome);

        Task<int> ObterQuantidadeTotalAsync();
    }
}
