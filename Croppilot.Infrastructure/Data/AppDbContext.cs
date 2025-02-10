using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Croppilot.Infrastructure.Data
{
	public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Leasing> Leasings { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<RefreshToken> RefreshTokens { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new LeasingConfiguration());
			modelBuilder.ApplyConfiguration(new ProductImageConfiguration());

			//please do not uncomment this line to seed data for Now 
			// modelBuilder.SeedData();


		}
	}
}
