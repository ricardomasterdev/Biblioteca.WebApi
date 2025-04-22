using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Domain.Entities
{
    public class Locacao
    {
        public int Id { get; set; }

        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoReal { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ValorLocacao { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Multa { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ValorRecebido { get; set; }
        public int Status { get; set; }

        public bool Devolvido => DataDevolucaoReal.HasValue;
    }
}
