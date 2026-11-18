using PC28168.U202321613.Openpay.Platform.Settlements.Domain.Model.Aggregates;
using PC28168.U202321613.Openpay.Platform.Settlements.Domain.Model.ValueObjects;
using PC28168.U202321613.Openpay.Platform.Shared.Domain.Repositories;

namespace PC28168.U202321613.Openpay.Platform.Settlements.Domain.Repositories;

public interface IDisbursementOrderRepository : IBaseRepository<DisbursementOrder>
{
    
    Task<bool> ExistsByTrackingCodeAsync(OpenpayReference trackingCode, CancellationToken cancellationToken = default);
}