using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Domain.Entities
{
    public class MovLocacao
    {
        public int Id { get; set; }

        // Relação com Livro
        public int LivroId { get; set; }
      
        // Relação com Usuário
        public int UsuarioId { get; set; }
        
        // Datas principais
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoReal { get; set; }

        // Valores financeiros
        [Column(TypeName = "decimal(10,2)")]
        public decimal? ValorLocacao { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Multa { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ValorRecebido { get; set; }

        // Status numérico e textual
        public int Status { get; set; }

       
      
    }
}
