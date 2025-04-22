using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string? Editora { get; set; } // nullable
        public int AnoPublicacao { get; set; }
        public string ISBN { get; set; }
        public int QuantidadeDisponivel { get; set; }

        // Novos atributos adicionados
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorLocacao { get; set; }  // Valor para locação

        public int DiasLocacao { get; set; }         // Número de dias para a locação padrão

        [Column(TypeName = "decimal(5,2)")]
        public decimal PercentualMulta { get; set; }   // Percentual de multa por dia de atraso (ex: 5% ou 0.05)

        public void Alugar()
        {
            if (QuantidadeDisponivel <= 0)
                throw new InvalidOperationException("Livro indisponível.");
            QuantidadeDisponivel--;
        }

        public void Devolver()
        {
            QuantidadeDisponivel++;
        }
    }
}
