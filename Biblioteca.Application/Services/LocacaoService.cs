using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Application.DTOs;

namespace Biblioteca.Application.Services
{
    public class LocacaoService
    {
        private readonly ILocacaoRepository _locacaoRepo;
        private readonly ILivroRepository _livroRepo;

        public LocacaoService(
            ILocacaoRepository locacaoRepo,
            ILivroRepository livroRepo)
        {
            _locacaoRepo = locacaoRepo;
            _livroRepo = livroRepo;
        }

        public async Task<List<Locacao>> ListarTodasAsync()
        {
            return await _locacaoRepo.ListarTodasAsync();
        }

        public async Task<Locacao> ObterPorIdAsync(int id)
        {
            return await _locacaoRepo.ObterPorIdAsync(id);
        }

        public async Task<bool> RegistrarLocacaoAsync(Locacao locacao)
        {
            var livro = await _livroRepo.ObterPorIdAsync(locacao.LivroId);
            if (livro == null || livro.QuantidadeDisponivel <= 0)
                return false;

            livro.Alugar();
            await _livroRepo.AtualizarAsync(livro);

            await _locacaoRepo.AdicionarAsync(locacao);

            var locacaoInserida = await _locacaoRepo.ObterPorIdAsync(locacao.Id);
            return locacaoInserida != null && locacaoInserida.Id > 0;
        }

        public async Task<List<Locacao>> ListarPorUsuarioAsync(int usuarioId)
        {
            return await _locacaoRepo.ListarPorUsuarioAsync(usuarioId);
        }

        public async Task<List<Locacao>> ListarPendentesAsync()
        {
            return await _locacaoRepo.ListarPendentesAsync();
        }

        public async Task<List<Locacao>> LivrosMaisLocadosAsync()
        {
            return await _locacaoRepo.LivrosMaisLocadosAsync();
        }

        public async Task<bool> AtualizarStatusAsync(int locacaoId, int novoStatus)
        {
            var locacao = await _locacaoRepo.ObterPorIdAsync(locacaoId);
            if (locacao == null)
                return false;

            locacao.Status = novoStatus;

            await _locacaoRepo.AtualizarAsync(locacao);
            return true;
        }

        public async Task<bool> RenovarLocacaoAsync(RenovaLocacaoDto dto)
        {
            try
            {
                await _locacaoRepo.ExecutarProcedureAsync("spRenovarLocacao", dto.Id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao executar procedure: {ex.Message}");
            }
        }

        public async Task<bool> FinalizarDevolucaoAsync(int locacaoId)
        {
            try
            {
                await _locacaoRepo.ExecutarProcedureAsync("spFinalizarDevolucaoLocacao", locacaoId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao executar procedure de devolução: {ex.Message}");
            }
        }

        public async Task<bool> FinalizaLocacaoAsync(FinalizaLocacaoDto dto)
        {
            try
            {
                await _locacaoRepo.ExecutarProcedureAsync("spFinalizarDevolucaoLocacao", dto.Id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao executar procedure: {ex.Message}");
            }
        }

        public async Task<bool> FinalizaLocacaooAsync(int locacaoId)
        {
            try
            {
                await _locacaoRepo.ExecutarProcedureAsync("spFinalizarDevolucaoLocacao", locacaoId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao executar procedure de devolução: {ex.Message}");
            }
        }

        public async Task<(int emAndamento, int finalizadas, int canceladas)> ObterTotaisPorStatusAsync()
        {
            return await _locacaoRepo.ObterTotaisPorStatusAsync();
        }

        public async Task<Dictionary<string, int>> ObterClientesComMaisEmprestimosAsync()
        {
            return await _locacaoRepo.ObterClientesComMaisEmprestimosAsync();
        }

        public async Task<List<Locacao>> BuscarLocacoesAsync(string nomeLivro, string nomeUsuario, int? status)
        {
            return await _locacaoRepo.BuscarLocacoesAsync(nomeLivro, nomeUsuario, status);
        }
    }
}
