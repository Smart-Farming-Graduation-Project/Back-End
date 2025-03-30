using Croppilot.Date.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Croppilot.Infrastructure.Configuration
{
	public class CuponConfiguration : IEntityTypeConfiguration<Cupon>
	{
		public void Configure(EntityTypeBuilder<Cupon> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Code)
				.IsRequired()
				.HasMaxLength(50);
			builder.Property(x => x.Discount_Type)
				.IsRequired()
				.HasConversion(new EnumToStringConverter<Discount_Type>());
			builder.Property(x => x.Discount_Value)
				.IsRequired()
				.HasColumnType("decimal(18,3)");
			builder.Property(x => x.UsageCount)
				.HasDefaultValue(0);

			builder.HasMany(x => x.Products)
				.WithOne(x => x.Cupon)
				.HasForeignKey(x => x.CuponId)
				.OnDelete(DeleteBehavior.SetNull);
			builder.HasOne(x => x.User)
				.WithMany(x => x.Cupons)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasIndex(x => x.Code)
				.IsUnique();
			builder.ToTable(t => t.HasCheckConstraint("CK_Cupon_Discount_Value", "Discount_Value > 0"));
			builder.ToTable(t => t.HasCheckConstraint("CK_Cupon_UsageLimit", "UsageLimit > 0"));
			builder.ToTable(t => t.HasCheckConstraint("ck_Cupon_ExpirationDate", "ExpirationDate > GetDate()"));

		}
	}
}
