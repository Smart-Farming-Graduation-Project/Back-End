namespace Croppilot.Infrastructure.Configuration;

public class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.UserId)
            .IsRequired();

        builder.Property(v => v.TargetId)
            .IsRequired();

        builder.Property(v => v.TargetType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(v => v.VoteType)
            .IsRequired();

        builder.Property(v => v.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        // Ensure each user can vote only once per target.
        builder.HasIndex(v => new { v.UserId, v.TargetId, v.TargetType }).IsUnique();

        // Allow only +1 or -1 as vote values.
        builder.HasCheckConstraint("CK_Vote_VoteType", "[VoteType] IN (1, -1)");

        // Allow only 'post' or 'comment' as target types.
        builder.HasCheckConstraint("CK_Vote_TargetType", "[TargetType] IN ('post', 'comment')");

        builder.HasOne(v => v.User)
            .WithMany()
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}