using Croppilot.Date.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Croppilot.Infrastructure.Configuration;

public class RoverConfiguration : IEntityTypeConfiguration<Rover>
{
    public void Configure(EntityTypeBuilder<Rover> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Id)
            .IsRequired()
            .HasMaxLength(450);
            
        builder.Property(r => r.UserId)
            .IsRequired()
            .HasMaxLength(450);
            
        builder.Property(r => r.CreatedAt)
            .IsRequired();
            
        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 