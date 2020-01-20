using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace questions4me_apirestful_net.Data
{
    /// <summary>
    /// Class needed to create migrations with ef core
    /// </summary>
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=ruben@educem-postgres;Password=awa");

            return new Context(optionsBuilder.Options);
        }
    }
}