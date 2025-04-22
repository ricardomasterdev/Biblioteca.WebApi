using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
            : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        // ✅ ADICIONE ESTA LINHA AQUI
        public DbSet<MovLocacao> MovLocacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livro>().ToTable("Livros");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Locacao>().ToTable("Locacoes");
            modelBuilder.Entity<MovLocacao>().ToTable("MovLocacao");


            modelBuilder.Entity<Livro>().HasKey(l => l.Id);
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Locacao>().HasKey(l => l.Id);
  

        modelBuilder.Entity<Locacao>()
                .HasOne(l => l.Livro)
                .WithMany()
                .HasForeignKey(l => l.LivroId);

            modelBuilder.Entity<Locacao>()
                .HasOne(l => l.Usuario)
                .WithMany(u => u.Locacoes)
                .HasForeignKey(l => l.UsuarioId);
        }
    }
}
