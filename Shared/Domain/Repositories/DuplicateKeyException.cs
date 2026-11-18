namespace PC28168.U202321613.Openpay.Platform.Shared.Domain.Repositories;


public sealed class DuplicateKeyException(Exception innerException)
    : Exception("A unique database key already exists.", innerException);