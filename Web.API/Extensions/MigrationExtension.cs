using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistencia;
namespace Web.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AplicacionDbContext>();

        dbContext.Database.Migrate();
    }
}