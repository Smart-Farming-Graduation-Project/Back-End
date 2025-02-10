namespace Croppilot.Infrastructure.Configuration;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.UserId)
            .IsRequired();
        
        builder.Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");
        
        builder.Property(c => c.UpdatedAt)
            .IsRequired(false);
        
        builder.HasMany(c => c.CartItems)
            .WithOne(ci => ci.Cart)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}