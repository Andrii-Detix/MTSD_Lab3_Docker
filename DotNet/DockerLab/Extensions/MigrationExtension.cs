using DockerLab.Database;
using Microsoft.EntityFrameworkCore;

namespace DockerLab.Extensions;

public static class MigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        
        using MyDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<MyDbContext>();
        
        dbContext.Database.Migrate();
    }
}