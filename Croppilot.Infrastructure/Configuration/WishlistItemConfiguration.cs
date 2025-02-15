namespace Croppilot.Infrastructure.Configuration;

public class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItem>
{
    public void Configure(EntityTypeBuilder<WishlistItem> builder)
    {
        builder.HasKey(wi => wi.Id);

        builder.Property(wi => wi.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(wi => wi.UpdatedAt)
            .IsRequired(false);

        builder.HasOne(wi => wi.Product)
            .WithMany()
            .HasForeignKey(wi => wi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}