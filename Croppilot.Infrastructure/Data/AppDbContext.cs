﻿using Croppilot.Date.Identity;
using Croppilot.Date.Models.AiModel;
using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Data.Extensions;
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
        public DbSet<Cupon> Cupons { get; set; }

        public DbSet<ModelResult> AIModelResults { get; set; }
        public DbSet<FeedbackEntry> FeedbackEntries { get; set; }

        public DbSet<Rover> Rovers { get; set; }

        //Dashborad Models
        public DbSet<WeatherData> WeatherDatas { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<SoilMoisture> SoilMoistures { get; set; }
        public DbSet<Alert> EmergencyAlerts { get; set; }
        //public DbSet<FarmerAdminDashboard> FarmerAdminDashboards { get; set; }
        //public DbSet<CropYield> CropYields { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
            //use this is better
            // Automatically apply all IEntityTypeConfiguration implementations in the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}