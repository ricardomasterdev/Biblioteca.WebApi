using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.DTOs
{
    internal class AtualizarUsuarioDto
     
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; }

     
        [Required(ErrorMessage = "O perfil é obrigatório.")]
        [Range(0, 1, ErrorMessage = "Perfil inválido. Use 0 para Administrador e 1 para Usuário Padrão.")]
        public int Perfil { get; set; } // 0 = Administrador, 1 = Usuário
    }
}
