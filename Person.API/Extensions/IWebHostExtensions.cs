﻿using Person.Infra.Data;

namespace Person.API.Extensions
{
    public static class IWebHostExtensions
    {
        public static IHost MigrateContext(this IHost webHost)
        {
            var configuration = webHost.Services.GetRequiredService<IConfiguration>();

            using var scope = webHost.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var logger = serviceProvider.GetRequiredService<ILogger<Context>>();
            var globalContext = serviceProvider.GetService<Context>();
            var environment = serviceProvider.GetService<IWebHostEnvironment>();

            try
            {
                var migrator = serviceProvider.GetService<IContextMigrator>();
                var connectionString = configuration.GetConnectionString("DbConnection");
                migrator.ApplyMigration(connectionString);

                logger.LogInformation($"Base criada/atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocorreu um erro ao migrar os bancos associados com os Tenants");
                throw;
            }

            return webHost;
        }
    }
}
