namespace PC28168.U202321613.Openpay.Platform.Shared.Domain.Model.ValueObjects;


public sealed record DateInterval
{
    public DateOnly ScheduledFrom { get; }
    public DateOnly ScheduledTo { get; }


    public DateInterval(DateOnly scheduledFrom, DateOnly scheduledTo)
    {
        if (scheduledTo <= scheduledFrom)
            throw new ArgumentException("InvalidSchedule", nameof(scheduledTo));

        ScheduledFrom = scheduledFrom;
        ScheduledTo = scheduledTo;
    }

    public bool HasElapsed(DateOnly referenceDate) => referenceDate > ScheduledTo;
}