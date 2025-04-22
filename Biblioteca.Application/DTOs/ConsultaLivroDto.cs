namespace Biblioteca.Application.DTOs
{
    public class ConsultaLivroDto
    {
        public string? Titulo { get; set; }
        public string? Autor { get; set; }

        public int Pagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
    }
}
