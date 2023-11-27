using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Person.Infra.Data
{

    public interface IContextMigrator
    {
        void ApplyMigration(string connectionString);
    }


    public class ContextMigrator : IContextMigrator
    {

        readonly ILogger<ContextMigrator> _logger;

        public ContextMigrator(ILogger<ContextMigrator> logger)
        {
            _logger = logger;
        }

        public void ApplyMigration(string connectionString)
        {
            _logger.LogInformation($"Migrating database");

            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            object p = optionsBuilder.UseSqlServer(connectionString, options =>
            {
                options.MigrationsHistoryTable(Context.MIGRATIONS_HISTORY_TABLE, Context.SCHEMA);
            });

            var context = new Context(optionsBuilder.Options);
            context.Database.Migrate();

            _logger.LogInformation($"Database successfully migrated");
        }
    }
}
