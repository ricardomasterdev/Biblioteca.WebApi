using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Domain.Enums;

namespace Biblioteca.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string SenhaHash { get; set; }  // armazenar senha criptografada
        public TipoPerfil Perfil { get; set; }

        // Relacionamento com locações
        public ICollection<Locacao> Locacoes { get; set; }
    }
}
