namespace Croppilot.Infrastructure.Configuration;

public class LeasingConfiguration : IEntityTypeConfiguration<Leasing>
{
    public void Configure(EntityTypeBuilder<Leasing> builder)
    {
        builder.HasKey(l => l.Id);
    }
}