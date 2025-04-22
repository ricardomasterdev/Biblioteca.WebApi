using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public UsuarioService(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<List<Usuario>> ListarTodosAsync()
        {
            return await _usuarioRepo.ListarTodosAsync();
        }

        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await _usuarioRepo.ObterPorIdAsync(id);
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _usuarioRepo.ObterPorEmailAsync(email);
        }

        public async Task<bool> AdicionarAsync(Usuario usuario)
        {
            if (await _usuarioRepo.ExisteEmailAsync(usuario.Email))
                return false;

            await _usuarioRepo.AdicionarAsync(usuario);
            return true;
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            await _usuarioRepo.AtualizarAsync(usuario);
        }

        public async Task RemoverAsync(int id)
        {
            await _usuarioRepo.RemoverAsync(id);
        }

        // Novo método para buscar usuários por nome
        public async Task<List<Usuario>> BuscarPorNomeAsync(string nome)
        {
            return await _usuarioRepo.BuscarPorNomeAsync(nome);
        }

        public async Task<int> ObterQuantidadeTotalAsync()
        {
            return await _usuarioRepo.ObterQuantidadeTotalAsync();
        }
    }
}
