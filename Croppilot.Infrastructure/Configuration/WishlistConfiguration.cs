namespace Croppilot.Infrastructure.Configuration;

public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.UserId)
            .IsRequired();

        builder.Property(w => w.CreatedAt)
            .HasDefaultValueSql($"GETUTCDATE()");

        builder.Property(w => w.UpdatedAt)
            .IsRequired(false);

        builder.HasMany(w => w.WishlistItems)
            .WithOne(wi => wi.Wishlist)
            .HasForeignKey(wi => wi.WishlistId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(w => w.User)
            .WithOne(u => u.Wishlist)
            .HasForeignKey<Wishlist>(w => w.UserId)
            .IsRequired();
    }
}