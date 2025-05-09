using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Services;

public class MigrationService(IDbContextFactory<AppDbContext> contextFactory) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var context = contextFactory.CreateDbContext();
        await context.Database.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
