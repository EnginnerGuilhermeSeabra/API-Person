
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Person.Infra.Data
{
    public class Context : DbContext
    {
        public static readonly string SCHEMA = "Person";
        public static readonly string MIGRATIONS_HISTORY_TABLE = "_EFMigrationHistory";

        public Context(DbContextOptions<Context> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SCHEMA);


            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
               

    }

    public class ContextDesignFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Person;Trusted_Connection=True;");

            return new Context(optionsBuilder.Options);
        }
    }
}
