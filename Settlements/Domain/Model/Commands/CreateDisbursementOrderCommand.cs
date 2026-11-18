namespace PC28168.U202321613.Openpay.Platform.Settlements.Domain.Model.Commands;

public sealed record CreateDisbursementOrderCommand(
    Guid OrderTrackingCode,
    Guid AffiliateStoreId,
    DateOnly ScheduledFrom,
    DateOnly ScheduledTo,
    decimal TransferCapAmount,
    string TransferCapCurrencyCode,
    int Status,
    string User,
    string? Remarks);