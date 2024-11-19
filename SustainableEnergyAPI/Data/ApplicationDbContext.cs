using Microsoft.EntityFrameworkCore;
using SustainableEnergyAPI.Models;

namespace SustainableEnergyAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Propriedade não anulável com inicialização explícita para evitar warnings do compilador
        public DbSet<EnergyResource> EnergyResources { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurando explicitamente o nome da tabela
            modelBuilder.Entity<EnergyResource>(entity =>
            {
                entity.ToTable("EnergyResource");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Type)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Efficiency)
                      .IsRequired();
            });
        }
    }
}
