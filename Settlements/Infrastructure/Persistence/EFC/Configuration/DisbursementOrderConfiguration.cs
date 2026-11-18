using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC28168.U202321613.Openpay.Platform.Settlements.Domain.Model.Aggregates;
using PC28168.U202321613.Openpay.Platform.Settlements.Domain.Model.ValueObjects;

namespace PC28168.U202321613.Openpay.Platform.Settlements.Infrastructure.Persistence.EFC.Configuration;


public sealed class DisbursementOrderConfiguration : IEntityTypeConfiguration<DisbursementOrder>
{
    
    public void Configure(EntityTypeBuilder<DisbursementOrder> builder)
    {
        builder.ToTable("disbursement_orders");
        builder.HasKey(order => order.Id).HasName("pk_disbursement_orders");
        builder.Property(order => order.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.Property(order => order.OrderTrackingCode).HasColumnName("order_tracking_code")
            .HasConversion(reference => reference.Value, value => new OpenpayReference(value));
        builder.HasIndex(order => order.OrderTrackingCode).IsUnique()
            .HasDatabaseName("ux_disbursement_orders_order_tracking_code");

        builder.Property(order => order.AffiliateStoreId).HasColumnName("affiliate_store_id")
            .HasConversion(identifier => identifier.Value, value => new StoreIdentifier(value));

        builder.OwnsOne(order => order.ExecutionSchedule, schedule =>
        {
            schedule.Property(interval => interval.ScheduledFrom).HasColumnName("scheduled_from");
            schedule.Property(interval => interval.ScheduledTo).HasColumnName("scheduled_to");
        });
        builder.Navigation(order => order.ExecutionSchedule).IsRequired();

        builder.OwnsOne(order => order.TransferCap, cap =>
        {
            cap.Property(amount => amount.Amount).HasColumnName("transfer_cap_amount").HasPrecision(57, 28);
            cap.Property(amount => amount.CurrencyCode).HasColumnName("transfer_cap_currency_code").IsRequired();
        });
        builder.Navigation(order => order.TransferCap).IsRequired();

        builder.Property(order => order.Status).HasColumnName("status").HasConversion<int>();
        builder.Property(order => order.User).HasColumnName("user").HasMaxLength(DisbursementOrder.UserMaxLength)
            .IsRequired();
        builder.Property(order => order.Remarks).HasColumnName("remarks")
            .HasMaxLength(DisbursementOrder.RemarksMaxLength);
        builder.Property(order => order.CreatedAt).HasColumnName("created_at");
        builder.Property(order => order.UpdatedAt).HasColumnName("updated_at");
    }
}