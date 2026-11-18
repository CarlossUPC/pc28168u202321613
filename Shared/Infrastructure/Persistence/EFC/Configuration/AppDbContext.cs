using Microsoft.EntityFrameworkCore;

namespace PC28168.U202321613.Openpay.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}