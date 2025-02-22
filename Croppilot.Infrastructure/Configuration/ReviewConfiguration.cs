namespace Croppilot.Infrastructure.Configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.ReviewID);

        builder.Property(r => r.UserID)
            .IsRequired();

        builder.Property(r => r.ProductID)
            .IsRequired();

        builder.Property(r => r.Headline)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(r => r.Rating)
            .IsRequired();
        builder.HasCheckConstraint("CK_Review_Rating", "[Rating] BETWEEN 1 AND 5");

        builder.Property(r => r.ReviewText)
            .IsRequired(false);

        builder.Property(r => r.ReviewDate)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(r => r.UpdatedAt)
            .IsRequired(false);

        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}