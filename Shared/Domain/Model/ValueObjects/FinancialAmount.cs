namespace Pc28168u202321613.Openpay.Platform.Shared.Domain.Model.ValueObjects;


public sealed record FinancialAmount
{
    public decimal Amount { get; }
    public string CurrencyCode { get; }

  
    public FinancialAmount(decimal amount, string currencyCode)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "InvalidAmount");
        if (currencyCode is null)
            throw new ArgumentNullException(nameof(currencyCode), "InvalidCurrency");
        if (string.IsNullOrWhiteSpace(currencyCode))
            throw new ArgumentException("InvalidCurrency", nameof(currencyCode));

        Amount = amount;
        CurrencyCode = currencyCode;
    }

    public FinancialAmount MultiplyBy(decimal factor) => new(Amount * factor, CurrencyCode);
}