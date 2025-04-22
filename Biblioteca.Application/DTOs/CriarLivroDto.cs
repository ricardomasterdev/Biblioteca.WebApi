using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Application.DTOs
{
    public class CriarLivroDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Editora { get; set; }

        [Required]
        [Range(1000, 2100, ErrorMessage = "Ano deve estar entre 1000 e 2100")]
        public int AnoPublicacao { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "O ISBN deve ter entre 10 e 13 caracteres.")]
        public string ISBN { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a zero.")]
        public int QuantidadeDisponivel { get; set; }
    }
}
