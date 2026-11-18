using PC28168.U202321613.Openpay.Platform.Shared.Domain.Repositories;
using PC28168.U202321613.Openpay.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace PC28168.U202321613.Openpay.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
public abstract class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected AppDbContext Context { get; } = context;

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
}