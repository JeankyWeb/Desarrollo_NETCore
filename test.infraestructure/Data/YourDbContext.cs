using test.domain;
using Microsoft.EntityFrameworkCore;

namespace YourNamespace // Cambia esto a tu espacio de nombres
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.Id); // Configura Id como clave primaria

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .IsRequired(); // Asegura que Amount sea obligatorio

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Currency)
                .IsRequired()
                .HasMaxLength(3); // Limita la longitud de Currency a 3 caracteres

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Date)
                .IsRequired(); // Asegura que Date sea obligatorio

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50); // Limita la longitud de Status a 50 caracteres

            // Otras configuraciones pueden ir aquí
        }
    }
}