using Biblioteca.Domain.Enums;

namespace Biblioteca.Application.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public TipoPerfil Perfil { get; set; }
    }
}
