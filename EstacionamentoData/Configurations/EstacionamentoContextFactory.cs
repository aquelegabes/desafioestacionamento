using EstacionamentoData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EstacionamentoData.Configurations
{
    public class EstacionamentoContextFactory : IDesignTimeDbContextFactory<EstacionamentoContext>
    {
        public EstacionamentoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstacionamentoContext>();
            optionsBuilder.UseSqlite("Data Source=db.sqlite3");

            return new EstacionamentoContext(optionsBuilder.Options);
        }
    }
}