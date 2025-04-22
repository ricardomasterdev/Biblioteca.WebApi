namespace Biblioteca.Application.DTOs
{
    public class LivroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string? Editora { get; set; }
        public int AnoPublicacao { get; set; }
        public string ISBN { get; set; }
        public int QuantidadeDisponivel { get; set; }

        // Novos atributos
        public decimal ValorLocacao { get; set; }
        public int DiasLocacao { get; set; }
        public decimal PercentualMulta { get; set; }
    }
}

