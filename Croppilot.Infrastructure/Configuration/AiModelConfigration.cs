using Croppilot.Date.Models.AiModel;

namespace Croppilot.Infrastructure.Configuration
{
    class AiModelConfigration : IEntityTypeConfiguration<ModelResult>
    {
        public void Configure(EntityTypeBuilder<ModelResult> builder)
        {
            builder.HasMany(c => c.FeedbackEntries)
                .WithOne(ci => ci.ModelResult)
                .HasForeignKey(ci => ci.ModelResultId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
