using PC28168u202321613.Openpay.Platform.Shared.Domain.Model;
using PC28168u202321613.Openpay.Platform.Shared.Domain.Model.ValueObjects;
using PC28168u202321613.Openpay.Platform.Settlements.Domain.Model.ValueObjects;

namespace PC28168U202321613.Openpay.Platform.Settlements.Domain.Model.Aggregates;

public sealed class DisbursementOrder : IAuditableEntity
{
    public const int UserMaxLength = 20;
    public const int RemarksMaxLength = 85;

    public int Id { get; private set; }
    public OpenpayReference OrderTrackingCode { get; private set; }
    public StoreIdentifier AffiliateStoreId { get; private set; }
    public DateInterval ExecutionSchedule { get; private set; } = null!;
    public FinancialAmount TransferCap { get; private set; } = null!;
    public DisbursementStatus Status { get; private set; }
    public string User { get; private set; } = null!;
    public string? Remarks { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private DisbursementOrder()
    {
    }
    
    public DisbursementOrder(OpenpayReference orderTrackingCode, StoreIdentifier affiliateStoreId,
        DateInterval executionSchedule, FinancialAmount transferCap, DisbursementStatus status,
        string user, string? remarks)
    {
        if (!Enum.IsDefined(status))
            throw new ArgumentOutOfRangeException(nameof(status), "InvalidStatus");
        if (string.IsNullOrWhiteSpace(user))
            throw new ArgumentException("RequiredUser", nameof(user));
        if (user.Length > UserMaxLength)
            throw new ArgumentException("UserTooLong", nameof(user));
        if (remarks is { Length: > RemarksMaxLength })
            throw new ArgumentException("RemarksTooLong", nameof(remarks));

        OrderTrackingCode = orderTrackingCode;
        AffiliateStoreId = affiliateStoreId;
        ExecutionSchedule = executionSchedule;
        TransferCap = transferCap;
        Status = status;
        User = user;
        Remarks = remarks;
    }
}