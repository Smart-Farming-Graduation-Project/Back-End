using Croppilot.Date.Identity;
using Croppilot.Date.Models.AiModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Croppilot.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Leasing> Leasings { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ChatHistory> ChatHistories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public DbSet<ModelResult> AIModelResults { get; set; }
        public DbSet<FeedbackEntry> FeedbackEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new LeasingConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            //modelBuilder.ApplyConfiguration(new CartConfiguration());
            //modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            //modelBuilder.ApplyConfiguration(new WishlistConfiguration());
            //modelBuilder.ApplyConfiguration(new WishlistItemConfiguration());
            //modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            //modelBuilder.ApplyConfiguration(new PostConfiguration());
            //modelBuilder.ApplyConfiguration(new CommentConfiguration());
            //modelBuilder.ApplyConfiguration(new VoteConfiguration());


            //use this is better
            // Automatically apply all IEntityTypeConfiguration implementations in the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}