namespace Croppilot.Infrastructure.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Price)
            .HasPrecision(18, 4);

        builder.HasMany(p => p.ProductImages)
            .WithOne(pI => pI.Product)
            .HasForeignKey(pI => pI.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Leasings)
            .WithOne(l => l.Product)
            .HasForeignKey(l => l.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(p => p.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);


    }
}