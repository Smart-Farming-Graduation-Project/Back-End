namespace Croppilot.Infrastructure.Configuration;

public class ProductImageConfiguration:IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(pI => pI.Id);
    }
}