using back_softek.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace back_softek.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Libro> Libro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.fechaNac).IsRequired();
                entity.Property(e => e.ciudadProcedencia).IsRequired().HasMaxLength(100);
                entity.Property(e => e.correo).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.correo).IsUnique();
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.titulo).IsRequired().HasMaxLength(200);
                entity.Property(e => e.año).IsRequired();
                entity.Property(e => e.genero).IsRequired().HasMaxLength(50);
                entity.Property(e => e.numeroPaginas).IsRequired();
                    
                entity.HasOne(e => e.autor)
                    .WithMany(u => u.Libros)
                    .HasForeignKey(e => e.autorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new { e.id });

            });
        }
    }
}
