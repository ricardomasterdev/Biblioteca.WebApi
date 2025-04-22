using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure;

namespace Biblioteca.Infrastructure.Data
{
    public static class GerarDados
    {
        public static void Popular(BibliotecaDbContext context)
        {
            // Verifica se já tem dados
            if (context.Livros.Any() || context.Usuarios.Any()) return;

            // Livros
            var livros = new List<Livro> {
    new Livro { Titulo = "Capitães da Areia", Autor = "Jorge Amado", ISBN = "9788535910513", Editora = "Record" },
new Livro { Titulo = "Gabriela, Cravo e Canela", Autor = "Jorge Amado", ISBN = "9788535920644", Editora = "Record" },
new Livro { Titulo = "Dona Flor e Seus Dois Maridos", Autor = "Jorge Amado", ISBN = "9788535930874", Editora = "Record" },
new Livro { Titulo = "Tieta do Agreste", Autor = "Jorge Amado", ISBN = "9788535932157", Editora = "Record" },
new Livro { Titulo = "O Compadre de Ogum", Autor = "Jorge Amado", ISBN = "9788535933000", Editora = "Record" },
new Livro { Titulo = "Memórias Póstumas de Brás Cubas", Autor = "Machado de Assis", ISBN = "9788572325947", Editora = "Companhia das Letras" },
new Livro { Titulo = "Dom Casmurro", Autor = "Machado de Assis", ISBN = "9788572320965", Editora = "Companhia das Letras" },
new Livro { Titulo = "Quincas Borba", Autor = "Machado de Assis", ISBN = "9788572325954", Editora = "Companhia das Letras" },
new Livro { Titulo = "Vidas Secas", Autor = "Graciliano Ramos", ISBN = "9788535911802", Editora = "Companhia das Letras" },
new Livro { Titulo = "São Bernardo", Autor = "Graciliano Ramos", ISBN = "9788572325985", Editora = "Companhia das Letras" },
new Livro { Titulo = "Grande Sertão: Veredas", Autor = "João Guimarães Rosa", ISBN = "9788501001095", Editora = "Record" },
new Livro { Titulo = "Sagarana", Autor = "João Guimarães Rosa", ISBN = "9788501014839", Editora = "Record" },
new Livro { Titulo = "Campo Geral", Autor = "João Guimarães Rosa", ISBN = "9788501009021", Editora = "Record" },
new Livro { Titulo = "Os Sertões", Autor = "Euclides da Cunha", ISBN = "9788535910375", Editora = "Companhia das Letras" },
new Livro { Titulo = "O Tempo e o Vento", Autor = "Érico Veríssimo", ISBN = "9788572324061", Editora = "Globo" },
new Livro { Titulo = "Incidente em Antares", Autor = "Érico Veríssimo", ISBN = "9788572324078", Editora = "Globo" },
new Livro { Titulo = "Perto do Coração Selvagem", Autor = "Clarice Lispector", ISBN = "9788572324095", Editora = "Companhia das Letras" },
new Livro { Titulo = "A Paixão Segundo G.H.", Autor = "Clarice Lispector", ISBN = "9788572324101", Editora = "Companhia das Letras" },
new Livro { Titulo = "A Hora da Estrela", Autor = "Clarice Lispector", ISBN = "9788572324118", Editora = "Companhia das Letras" },
new Livro { Titulo = "O Alquimista", Autor = "Paulo Coelho", ISBN = "9788572324125", Editora = "Rocco" },
new Livro { Titulo = "Veronika Decide Morrer", Autor = "Paulo Coelho", ISBN = "9788572324132", Editora = "Rocco" },
new Livro { Titulo = "Brida", Autor = "Paulo Coelho", ISBN = "9788572324149", Editora = "Rocco" },
new Livro { Titulo = "Vestido de Noiva", Autor = "Nelson Rodrigues", ISBN = "9788572324156", Editora = "Record" },
new Livro { Titulo = "A Falecida", Autor = "Nelson Rodrigues", ISBN = "9788572324163", Editora = "Record" },
new Livro { Titulo = "O Seminarista", Autor = "Rubem Fonseca", ISBN = "9788572324184", Editora = "Rocco" },
new Livro { Titulo = "Feliz Ano Novo", Autor = "Rubem Fonseca", ISBN = "9788572324191", Editora = "Rocco" },
new Livro { Titulo = "Agosto", Autor = "Rubem Fonseca", ISBN = "9788572324207", Editora = "Rocco" },
new Livro { Titulo = "Ciranda de Pedra", Autor = "Lygia Fagundes Telles", ISBN = "9788572324214", Editora = "Companhia das Letras" },
new Livro { Titulo = "As Meninas", Autor = "Lygia Fagundes Telles", ISBN = "9788572324221", Editora = "Companhia das Letras" },
new Livro { Titulo = "Viva o Povo Brasileiro", Autor = "João Ubaldo Ribeiro", ISBN = "9788572324238", Editora = "Record" },
new Livro { Titulo = "Sargento Getúlio", Autor = "João Ubaldo Ribeiro", ISBN = "9788572324245", Editora = "Record" },
new Livro { Titulo = "Estorvo", Autor = "Chico Buarque", ISBN = "9788572324252", Editora = "Companhia das Letras" },
new Livro { Titulo = "Budapeste", Autor = "Chico Buarque", ISBN = "9788572324269", Editora = "Companhia das Letras" },
new Livro { Titulo = "Morangos Mofados", Autor = "Caio Fernando Abreu", ISBN = "9788572324276", Editora = "Record" },
new Livro { Titulo = "Dois Irmãos", Autor = "Milton Hatoum", ISBN = "9788572324283", Editora = "Companhia das Letras" },
new Livro { Titulo = "Quem Somos Nós?", Autor = "Milton Hatoum", ISBN = "9788572324290", Editora = "Companhia das Letras" },
new Livro { Titulo = "Quase Memórias", Autor = "Adriana Lisboa", ISBN = "9788572324306", Editora = "Record" },
new Livro { Titulo = "O Filho Eterno", Autor = "Cristovão Tezza", ISBN = "9788572324313", Editora = "Companhia das Letras" },
new Livro { Titulo = "Zero", Autor = "Ignácio de Loyola Brandão", ISBN = "9788572324320", Editora = "Record" },
new Livro { Titulo = "O Amor Natural", Autor = "Dalton Trevisan", ISBN = "9788572324337", Editora = "Record" },
new Livro { Titulo = "Macunaíma", Autor = "Mário de Andrade", ISBN = "9788572324344", Editora = "Record" },
new Livro { Titulo = "Anarquistas, Graças a Deus", Autor = "Zélia Gattai", ISBN = "9788572324351", Editora = "Record" },
new Livro { Titulo = "Estrela Solitária", Autor = "Ruy Castro", ISBN = "9788572324368", Editora = "Companhia das Letras" },
new Livro { Titulo = "O Menino Maluquinho", Autor = "Ziraldo", ISBN = "9788572324375", Editora = "Agir" },
new Livro { Titulo = "Auto da Compadecida", Autor = "Ariano Suassuna", ISBN = "9788572324382", Editora = "Record" },
new Livro { Titulo = "Libertinagem", Autor = "Manuel Bandeira", ISBN = "9788572324399", Editora = "Record" },
new Livro { Titulo = "A Rosa do Povo", Autor = "Carlos Drummond de Andrade", ISBN = "9788572324405", Editora = "Companhia das Letras" },
new Livro { Titulo = "Cela", Autor = "Hilda Hilst", ISBN = "9788572324412", Editora = "Record" },
new Livro { Titulo = "Catatau", Autor = "Paulo Leminski", ISBN = "9788572324429", Editora = "Companhia das Letras" },
new Livro { Titulo = "O Morto", Autor = "Adonias Filho", ISBN = "9788572324436", Editora = "Record" },
new Livro { Titulo = "Bufo & Spallanzani", Autor = "Rubem Fonseca", ISBN = "9788572324443", Editora = "Rocco" },
new Livro { Titulo = "Ponciá Vicêncio", Autor = "Conceição Evaristo", ISBN = "9788572324450", Editora = "Objetiva" },
new Livro { Titulo = "Parque Industrial", Autor = "Lya Luft", ISBN = "9788572324467", Editora = "Record" },
new Livro { Titulo = "O Rapto do Garoto de Ouro", Autor = "João Anzanello Carrascoza", ISBN = "9788572324474", Editora = "Verus" },
new Livro { Titulo = "Leite Derramado", Autor = "Chico Buarque", ISBN = "9788572324481", Editora = "Companhia das Letras" },
new Livro { Titulo = "Lavoura Arcaica", Autor = "Raduan Nassar", ISBN = "9788572324498", Editora = "Globo" },
new Livro { Titulo = "O Encontro Marcado", Autor = "Fernando Sabino", ISBN = "9788572324504", Editora = "Record" },
new Livro { Titulo = "O Grande Mentecapto", Autor = "Fernando Sabino", ISBN = "9788572324511", Editora = "Record" },
new Livro { Titulo = "A Turma do Pererê", Autor = "Ziraldo", ISBN = "9788572324528", Editora = "Agir" },
new Livro { Titulo = "Cinzas do Norte", Autor = "Milton Hatoum", ISBN = "9788572324535", Editora = "Companhia das Letras" },
new Livro { Titulo = "Babilônia", Autor = "Mário Prata", ISBN = "9788572324542", Editora = "Record" },
new Livro { Titulo = "Poemas Escolhidos", Autor = "Ferreira Gullar", ISBN = "9788572324559", Editora = "L&PM" },
new Livro { Titulo = "Claro Enigma", Autor = "Carlos Drummond de Andrade", ISBN = "9788572324566", Editora = "Companhia das Letras" },
new Livro { Titulo = "Laços de Família", Autor = "Clarice Lispector", ISBN = "9788572324573", Editora = "Companhia das Letras" },
new Livro { Titulo = "Felicidade Clandestina", Autor = "Clarice Lispector", ISBN = "9788572324580", Editora = "Companhia das Letras" },
new Livro { Titulo = "Quarto de Despejo", Autor = "Carolina Maria de Jesus", ISBN = "9788572324597", Editora = "Record" },
new Livro { Titulo = "Cidade de Deus", Autor = "Paulo Lins", ISBN = "9788572324603", Editora = "Objetiva" },
new Livro { Titulo = "A Máquina de Escrever", Autor = "Fernando Sabino", ISBN = "9788572324610", Editora = "Record" },
new Livro { Titulo = "Antes do Baile Verde", Autor = "Lygia Fagundes Telles", ISBN = "9788572324627", Editora = "Companhia das Letras" },
new Livro { Titulo = "Onde Tudo Termina", Autor = "Ricardo Lísias", ISBN = "9788572324634", Editora = "Companhia das Letras" },
new Livro { Titulo = "O Sol se Põe em São Paulo", Autor = "Luis Fernando Verissimo", ISBN = "9788572324641", Editora = "Objetiva" },
new Livro { Titulo = "Comédias da Vida Privada", Autor = "Luis Fernando Verissimo", ISBN = "9788572324658", Editora = "Objetiva" },
new Livro { Titulo = "O Analista de Bagé", Autor = "Luis Fernando Verissimo", ISBN = "9788572324665", Editora = "Objetiva" },
new Livro { Titulo = "A Comédia dos Erros", Autor = "Luis Fernando Verissimo", ISBN = "9788572324672", Editora = "Objetiva" },
new Livro { Titulo = "Bandidos da Falange", Autor = "Marçal Aquino", ISBN = "9788572324689", Editora = "Companhia das Letras" },
new Livro { Titulo = "O Cheiro do Ralo", Autor = "Nelson Rodrigues", ISBN = "9788572324696", Editora = "Record" },
new Livro { Titulo = "Toda Nudez Será Castigada", Autor = "Nelson Rodrigues", ISBN = "9788572324702", Editora = "Record" },
new Livro { Titulo = "Fogo Morto", Autor = "José Lins do Rego", ISBN = "9788572324719", Editora = "Record" },
new Livro { Titulo = "Menino de Engenho", Autor = "José Lins do Rego", ISBN = "9788572324726", Editora = "Record" },
new Livro { Titulo = "Quarup", Autor = "Antônio Callado", ISBN = "9788572324733", Editora = "Record" },
new Livro { Titulo = "Um Copo de Cólera", Autor = "Raduan Nassar", ISBN = "9788572324740", Editora = "Record" },
new Livro { Titulo = "O Casamento", Autor = "Lygia Fagundes Telles", ISBN = "9788572324757", Editora = "Companhia das Letras" },
new Livro { Titulo = "Chiclete com Banana", Autor = "Luis Fernando Verissimo", ISBN = "9788572324764", Editora = "Objetiva" },
new Livro { Titulo = "O Primeiro Beijo", Autor = "Cristovão Tezza", ISBN = "9788572324771", Editora = "Companhia das Letras" },
new Livro { Titulo = "A Casa dos Budas Ditosos", Autor = "João Ubaldo Ribeiro", ISBN = "9788572324788", Editora = "Record" },
new Livro { Titulo = "Veredas do Destino", Autor = "Carlos Pereira", ISBN = "9788572324795", Editora = "Editora Brasil" },
new Livro { Titulo = "Sombra e Luz", Autor = "Ana Martins", ISBN = "9788572324801", Editora = "Editora Brasil" },
new Livro { Titulo = "O Vendedor de Sonhos", Autor = "João Silva", ISBN = "9788572324818", Editora = "Record Brasil" },
new Livro { Titulo = "Maré Alta", Autor = "Maria Oliveira", ISBN = "9788572324825", Editora = "Companhia das Letras" },
new Livro { Titulo = "Caminhos Cruzados", Autor = "Pedro Souza", ISBN = "9788572324832", Editora = "Record Brasil" },
new Livro { Titulo = "Raízes do Tempo", Autor = "Luiza Costa", ISBN = "9788572324849", Editora = "Editora Brasil" },
new Livro { Titulo = "Luz na Escuridão", Autor = "Marcos Almeida", ISBN = "9788572324856", Editora = "Companhia das Letras" },
new Livro { Titulo = "Destino Incerto", Autor = "Fernanda Rocha", ISBN = "9788572324863", Editora = "Record Brasil" },
new Livro { Titulo = "Entre Vidas", Autor = "Ricardo Almeida", ISBN = "9788572324870", Editora = "Editora Brasil" },
new Livro { Titulo = "Além do Horizonte", Autor = "Paula Fernandes", ISBN = "9788572324887", Editora = "Companhia das Letras" },
new Livro { Titulo = "Caleidoscópio", Autor = "Rafael Costa", ISBN = "9788572324894", Editora = "Record Brasil" },
new Livro { Titulo = "Ecos do Passado", Autor = "Larissa Gomes", ISBN = "9788572324900", Editora = "Editora Brasil" }

};


            // Usuários
            var usuarios = new List<Usuario> {
    new Usuario { Nome = "Ana Silva", Email = "ana@example.com", SenhaHash = "123456", Telefone = "11988887777" },
    new Usuario { Nome = "Carlos Souza", Email = "carlos@example.com", SenhaHash = "abc123", Telefone = "11999998888" },
    new Usuario { Nome = "João Pedro", Email = "joao@example.com", SenhaHash = "senhaTeste", Telefone = "11977776666" },
     new Usuario { Nome = "Ana Silsva", Email = "ana@example.com", SenhaHash = "123456", Telefone = "119888877s77" },
    new Usuario { Nome = "Carlos Sosuza", Email = "carlos@example.com", SenhaHash = "abc123", Telefone = "11999998888" },
    new Usuario { Nome = "João Pesdro", Email = "joao@example.com", SenhaHash = "senhaTeste", Telefone = "11977s776666" }
};


            context.Livros.AddRange(livros);
            context.Usuarios.AddRange(usuarios);
            context.SaveChanges();

            // (Opcional) Locações
            var locacoes = new List<Locacao> {
                new Locacao {
                    LivroId = livros[0].Id,
                    UsuarioId = usuarios[0].Id,
                    //DataLocacao = DateTime.Now.AddDays(-3),
                    DataDevolucaoPrevista = DateTime.Now.AddDays(4)
                },
                new Locacao {
                    LivroId = livros[1].Id,
                    UsuarioId = usuarios[1].Id,
                    //DataLocacao = DateTime.Now.AddDays(-10),
                    DataDevolucaoPrevista = DateTime.Now.AddDays(-3),
                    DataDevolucaoReal = DateTime.Now.AddDays(-1),
                    Multa = 5.0m
                }
            };

            context.Locacoes.AddRange(locacoes);
            context.SaveChanges();
        }
    }
}
