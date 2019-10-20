using Microsoft.EntityFrameworkCore;
using EstacionamentoDomain.Entities;
using System.Configuration;
using EstacionamentoData.Configurations;

namespace EstacionamentoData.Context
{
    public class EstacionamentoContext : DbContext
    {
        public EstacionamentoContext (DbContextOptions options) : base (options) { }

        public DbSet<Vigencia> Vigencias { get; set; }
        public DbSet<Registro> Registros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=db.sqlite3");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VigenciaConfiguration());
            modelBuilder.ApplyConfiguration(new RegistroConfiguration());
        }
    }
}