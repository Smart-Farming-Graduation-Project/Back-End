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

        ////Make Many To Many Rel between ( Products and Categories)
        //builder
        //    .HasMany(p => p.Categories)
        //    .WithMany(c => c.Products) 
        //    .UsingEntity<Dictionary<string, object>>(
        //        "ProductCategory", // Junction table name
        //        j => j
        //            .HasOne<Category>()
        //            .WithMany()
        //            .HasForeignKey("CategoryId")
        //            .HasConstraintName("FK_ProductCategory_CategoryId")
        //            .OnDelete(DeleteBehavior.Cascade),
        //        j => j
        //            .HasOne<Product>()
        //            .WithMany()
        //            .HasForeignKey("ProductId")
        //            .HasConstraintName("FK_ProductCategory_ProductId")
        //            .OnDelete(DeleteBehavior.Cascade),
        //        j =>
        //        {
        //            j.HasKey("ProductId", "CategoryId");
        //            j.ToTable("ProductCategories");
        //        }
        //    );

    }
}