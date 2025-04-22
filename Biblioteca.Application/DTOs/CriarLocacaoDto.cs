namespace Biblioteca.Application.DTOs
{
    public class CriarLocacaoDto
    {
        public int LivroId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime? DataDevolucaoPrevista { get; set; }
        public DateTime? DataLocacao { get; set; }
        public decimal? ValorLocacao { get; set; }
        public int Status { get; set; }
    }
}
