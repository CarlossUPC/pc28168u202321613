using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PC28168.U202321613.Openpay.Platform.Shared.Domain.Model;

namespace PC28168.U202321613.Openpay.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;


public sealed class AuditableEntityInterceptor(TimeProvider clock) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        StampEntries(eventData.Context);
        return result;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        StampEntries(eventData.Context);
        return ValueTask.FromResult(result);
    }

    private void StampEntries(DbContext? context)
    {
        if (context is null)
            return;

        var now = clock.GetUtcNow().UtcDateTime;
        foreach (var entry in context.ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Property(nameof(IAuditableEntity.CreatedAt)).CurrentValue = now;

            if (entry.State is EntityState.Added or EntityState.Modified)
                entry.Property(nameof(IAuditableEntity.UpdatedAt)).CurrentValue = now;
        }
    }
}