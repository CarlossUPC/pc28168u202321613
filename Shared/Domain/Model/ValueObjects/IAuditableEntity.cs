namespace PC28168.U202321613.Openpay.Platform.Shared.Domain.Model;


public interface IAuditableEntity
{
    DateTime CreatedAt { get; }
    DateTime UpdatedAt { get; }
}