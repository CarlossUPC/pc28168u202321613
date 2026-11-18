namespace PC28168u202321613.Openpay.Platform.Shared.Domain.Model;


public interface IAuditableEntity
{
    DateTime CreatedAt { get; }
    DateTime UpdatedAt { get; }
}