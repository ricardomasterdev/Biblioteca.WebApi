using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Domain.Entities;



namespace Biblioteca.Domain.Interfaces
{
    public interface ILocacaoRepository
    {
        Task<Locacao> ObterPorIdAsync(int id);
        Task<List<Locacao>> ListarTodasAsync();
        Task<List<Locacao>> ListarPorUsuarioAsync(int usuarioId);
        Task AdicionarAsync(Locacao locacao);
        Task AtualizarAsync(Locacao locacao);
        Task<List<Locacao>> ListarPendentesAsync();
        Task<List<Locacao>> LivrosMaisLocadosAsync();

      
        // Adicione exatamente este método
        Task ExecutarProcedureAsync(string procedureName, int locacaoId);

        // Método que retorna um dicionário com o título do livro e a quantidade de locações
        Task<Dictionary<string, int>> ObterLivrosMaisLocadosAsync();


        // Método para obter os clientes que possuem o maior número de empréstimos
        Task<Dictionary<string, int>> ObterClientesComMaisEmprestimosAsync();

        Task<(int emAndamento, int finalizadas, int canceladas)> ObterTotaisPorStatusAsync();

        // método para busca robusta usando filtros
        Task<List<Locacao>> BuscarLocacoesAsync(string nomeLivro, string nomeUsuario, int? status);


    }
}
