namespace Biblioteca.Application.DTOs
{
    public class DetalhesLocacaoDto
    {
        public int Id { get; set; }
        public string TituloLivro { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime? DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoReal { get; set; }
        public decimal? ValorLocacao { get; set; }
        public decimal? Multa { get; set; }
        public decimal? ValorRecebido { get; set; }
        public int Status { get; set; }
    }
}
