using Croppilot.Date.Enum;

namespace Croppilot.Infrastructure.Data.Extensions
{
	public static class ModelBuilderExtensions
	{
		public static void SeedData(this ModelBuilder modelBuilder)
		{
			// Seed Categories 
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Fresh Vegetables", Description = "Daily harvested organic vegetables", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/0bdbd4c8-2503-427c-b4fe-ffa6e5c57a23_Fresh Vegetables.jpg" },
				new Category { Id = 2, Name = "Seasonal Fruits", Description = "Naturally grown fruits with authentic flavors", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/5caaf20a-3510-4d38-b2b4-b16e79cf45ab_Seasonal Fruits.jpg" },
				new Category { Id = 3, Name = "Dairy Products", Description = "Fresh cheese and milk from our farm", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/61cd1282-c3c4-4ef3-9b2c-ae7d5beb482c_Dairy Products.jpg" },
				new Category { Id = 4, Name = "Organic Eggs", Description = "Free-range chicken eggs", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/b7f5884a-6833-43f0-bb78-367c371a37fb_Organic Eggs.jpg" },
				new Category { Id = 5, Name = "Ornamental Plants", Description = "Home garden flowers and decorative plants", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/9aa3dfb7-12b7-4631-908c-eb11fa0c64f9_Ornamental Plants.jpg" },
				new Category { Id = 6, Name = "Seedlings", Description = "Vegetable and fruit starters for home gardening", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/28773f2f-5619-406e-8c74-1cd82b296d3f_Seedlings.jpg" },
				new Category { Id = 7, Name = "Organic Animal Feed", Description = "Natural feed for livestock and poultry", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/a5a834c1-736c-4858-95df-673e21014525_Organic Animal Feed.jpg" },
				new Category { Id = 8, Name = "Farming Tools", Description = "Essential agricultural equipment", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/c10224a6-0625-41a3-8332-73433f96f39e_Farming Tools.jpg" },
				new Category { Id = 9, Name = "Premium Seeds", Description = "Certified high-yield seeds", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/6c4bef01-1181-4fde-8bc4-78331a8c82d2_Premium Seeds.jpg" },
				new Category { Id = 10, Name = "Organic Fertilizers", Description = "Natural soil enhancers", ImageUrl = "https://graduationprojetct.blob.core.windows.net/category-images/242d456f-5b41-4d3a-8744-cd18ec583aae_Organic Fertilizers.jpg" }
			);

			// Seed Products 
			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Id = 1,
					Name = "Organic Tomatoes",
					Description = "Fresh vine-ripened tomatoes",
					Price = 19.99m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 1
				},
				new Product
				{
					Id = 2,
					Name = "Cucumbers",
					Description = "Crisp and refreshing cucumbers",
					Price = 12.50m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 1
				},
				new Product
				{
					Id = 3,
					Name = "Bell Peppers",
					Description = "Mixed color sweet peppers",
					Price = 18.75m,
					Availability = Availability.Lease,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 1
				},
				new Product
				{
					Id = 4,
					Name = "Strawberries",
					Description = "Sweet and juicy strawberries",
					Price = 25.99m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 2
				},
				new Product
				{
					Id = 5,
					Name = "Mangoes",
					Description = "Premium imported mangoes",
					Price = 30.50m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 2
				},
				new Product
				{
					Id = 6,
					Name = "Watermelons",
					Description = "Large sweet watermelons",
					Price = 45.00m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 2
				},
				 new Product
				 {
					 Id = 7,
					 Name = "Farm Fresh Milk",
					 Description = "Whole milk 1L bottle",
					 Price = 20.00m,
					 Availability = Availability.Sale,
					 CreatedAt = DateTime.UtcNow,
					 UpdatedAt = DateTime.UtcNow,
					 UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					 CategoryId = 3
				 },
				new Product
				{
					Id = 8,
					Name = "Artisan Cheese",
					Description = "Aged cheddar cheese 200g",
					Price = 35.75m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 3
				},
				new Product
				{
					Id = 9,
					Name = "Natural Yogurt",
					Description = "Natural Yogurt",
					Price = 18.50m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 3
				},
				new Product
				{
					Id = 10,
					Name = "Free-Range Eggs (12pk)",
					Description = "Large brown eggs",
					Price = 30.00m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 4
				},
				 new Product
				 {
					 Id = 11,
					 Name = "Rose Bush",
					 Description = "Red rose plant in 12\" pot",
					 Price = 120.00m,
					 Availability = Availability.Sale,
					 CreatedAt = DateTime.UtcNow,
					 UpdatedAt = DateTime.UtcNow,
					 UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					 CategoryId = 5
				 },
				new Product
				{
					Id = 12,
					Name = "Lavender Plant",
					Description = "Fragrant lavender for gardens",
					Price = 85.50m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 5
				},
				new Product
				{
					Id = 13,
					Name = "Tomato Seedlings",
					Description = "Early girl tomato plants",
					Price = 15.00m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 6
				},
				new Product
				{
					Id = 14,
					Name = "Cucumber Seedlings",
					Description = "Burpless cucumber plants, disease-resistant",
					Price = 13.25m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 6
				},
				new Product
				{
					Id = 15,
					Name = "Poultry Feed 20kg",
					Description = "Organic chicken feed",
					Price = 150.00m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 7
				},
				new Product
				{
					Id = 16,
					Name = "Cattle Feed 25kg",
					Description = "Nutritional cattle mix",
					Price = 220.00m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 7
				},
				new Product
				{
					Id = 17,
					Name = "Pruning Shears",
					Description = "Professional grade shears",
					Price = 65.00m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 8
				},
				new Product
				{
					Id = 18,
					Name = "Garden Hoe",
					Description = "Sturdy steel garden hoe",
					Price = 45.00m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 8
				},
				new Product
				{
					Id = 19,
					Name = "Compost 10kg",
					Description = "Nutrient-rich compost",
					Price = 40.00m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 10
				},
				new Product
				{
					Id = 20,
					Name = "Worm Castings",
					Description = "Organic soil amendment",
					Price = 55.00m,
					Availability = Availability.Sale,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow,
					UserId = "8efa5fd5-ac9b-4cfd-833a-654b1fa84ef2",
					CategoryId = 10
				}

			);

			// Seed Product Images
			modelBuilder.Entity<ProductImage>().HasData(
				new ProductImage { Id = 1, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Organic Tomatoes_2520f86d-8700-4b06-bed5-e9e317e71d95_R %283%29.jpg", ProductId = 1 },
				new ProductImage { Id = 2, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Cucumbers_d29f0202-cbf9-4f0e-ae62-344521eec15c_R %284%29.jpg", ProductId = 2 },
				new ProductImage { Id = 3, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Cucumbers_771c182f-18c0-43b4-af95-281406ed89fe_OIP.jpg", ProductId = 2 },
				new ProductImage { Id = 4, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_765ca4be-6179-4ce9-bed6-57613481d475_OIP %281%29.jpg", ProductId = 3 },
				new ProductImage { Id = 5, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_7d5babea-020f-4e79-8552-9450f997853e_primary-430.jpg", ProductId = 3 },
				new ProductImage { Id = 6, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_d561a4c3-5e47-4ec4-9a40-dccc6b7157bc_Bell-Peppers.jpg", ProductId = 3 },
				new ProductImage { Id = 7, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_b66be9e1-5421-4592-9038-a546c2c49bd6_R %285%29.jpg", ProductId = 7 },
				new ProductImage { Id = 8, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_affe0646-14b5-4440-9373-823c0aab4132_R %286%29.jpg", ProductId = 7 },
				new ProductImage { Id = 9, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_5d1f9c4f-444c-49d3-8cb0-eb4e1ff19d40_R %287%29.jpg", ProductId = 7 },
				new ProductImage { Id = 10, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Strawberries_eefc35b5-e857-4cf5-a5a3-b09fa75f3c6f_R %288%29.jpg", ProductId = 4 },
				new ProductImage { Id = 11, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Strawberries_779eca40-dfb3-4c51-9ae4-f6d022bdea1a_R %289%29.jpg", ProductId = 4 },
				new ProductImage { Id = 12, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Mangoes_d0c89732-4204-4804-ba7c-d0ef0a822573_download.jpg", ProductId = 5 },
				new ProductImage { Id = 13, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Mangoes_0aa7f942-c40f-4f0f-a2d0-f960d599a9d2_OIP %282%29.jpg", ProductId = 5 },
				new ProductImage { Id = 14, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Watermelons_f13f305a-8f7d-4bdd-ad67-08982d51bd88_OIP %283%29.jpg", ProductId = 6 },
				new ProductImage { Id = 15, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Watermelons_5a90c66a-c7c8-4de4-8ae3-c5d763f63955_OIP %284%29.jpg", ProductId = 6 },
				new ProductImage { Id = 16, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Artisan Cheese_a1d3e7ec-afba-4883-812d-30216c3cb4e7_R %2810%29.jpg", ProductId = 8 },
				new ProductImage { Id = 17, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Artisan Cheese_26e0102e-b43e-4124-b3af-9d87e6ad5ce5_OIP %285%29.jpg", ProductId = 8 },
				new ProductImage { Id = 18, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Natural Yogurt_c5f98e11-0931-43e2-9d9a-fd70f42a5dbd_OIP %286%29.jpg", ProductId = 9 },
				new ProductImage { Id = 19, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Natural Yogurt_7337ee02-8893-4ab2-aec7-cb1414df80dd_R %2811%29.jpg", ProductId = 9 },
				new ProductImage { Id = 20, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Free-Range Eggs %2812pk%29_2d35c5fc-6d4c-4f8e-aa13-1c16ed674601_OIP %287%29.jpg", ProductId = 10 },
				new ProductImage { Id = 21, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Free-Range Eggs %2812pk%29_33b205d9-91da-40ef-9a96-c9a0337b3fe4_OIP %288%29.jpg", ProductId = 10 },
				new ProductImage { Id = 22, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Rose Bush_c7bff713-4c6c-4352-869e-c85f673baf1f_R %2812%29.jpg", ProductId = 11 },
				new ProductImage { Id = 23, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Rose Bush_edb3d662-5727-4c71-93a5-bb460cddd3c3_OIP %289%29.jpg", ProductId = 11 },
				new ProductImage { Id = 24, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Lavender Plant_53ef2c19-0a3b-4114-b178-32c1a6110069_OIP %2810%29.jpg", ProductId = 12 },
				new ProductImage { Id = 25, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Tomato Seedlings_e6e9622b-bbc1-4aa6-96b2-297ebb8257f4_IMG_9275.jpg", ProductId = 13 },
				new ProductImage { Id = 26, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Cucumber Seedlings_89f422cb-7093-4814-bd2f-0d4ad099cc6e_R %2813%29.jpg", ProductId = 14 },
				new ProductImage { Id = 27, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Poultry Feed 20kg_e9e91afb-1a50-4726-bd37-e162ec9ed15a_OIP %2811%29.jpg", ProductId = 15 },
				new ProductImage { Id = 28, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Poultry Feed 20kg_2a70c24b-9b7a-4905-af6e-796ab5566709_OIP %2812%29.jpg", ProductId = 15 },
				new ProductImage { Id = 29, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Cattle Feed 25kg_c8ec9374-4839-4004-96c1-0054ad698925_OIP %2813%29.jpg", ProductId = 16 },
				new ProductImage { Id = 30, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Cattle Feed 25kg_b441f3a3-b774-4efb-bf75-543fa2700a4e_OIP %2814%29.jpg", ProductId = 16 },
				new ProductImage { Id = 31, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Pruning Shears_e40f5237-442d-4452-8f32-2883bcfbe8bf_OIP %2815%29.jpg", ProductId = 17 },
				new ProductImage { Id = 32, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Pruning Shears_54af077d-62db-4fe4-9bcb-ad0fbf184d15_OIP %2816%29.jpg", ProductId = 17 },
				new ProductImage { Id = 33, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Garden Hoe_477a31d4-f9c0-4ec2-bd8f-bc81c5aaeaac_OIP %2817%29.jpg", ProductId = 18 },
				new ProductImage { Id = 34, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Compost 10kg_d8e29f75-83a8-4968-992f-343303f0404b_61gvcvZgosL._AC_SL1500_.jpg", ProductId = 19 },
				new ProductImage { Id = 35, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Compost 10kg_a02227ba-a1a8-4053-9f95-7c354402c179_R %2814%29.jpg", ProductId = 19 },
				new ProductImage { Id = 36, ImageUrl = "https://graduationprojetct.blob.core.windows.net/product-images/Worm Castings_e1155a6c-3ce2-4d69-979f-a8840c282f02_OIP %2818%29.jpg", ProductId = 20 }
			);
			//// Seed Initial Equipment Data
			//modelBuilder.Entity<Equipment>().HasData(
			//   new Equipment { Id = 1, EquipmentId = "EQ-001", Name = "Tractor A", Status = EquipmentStatus.Active, LastMaintenance = DateTime.UtcNow.AddDays(-30), HoursUsed = 120, Battery = 85, Connectivity = EquipmentConnectivity.Online },
			//   new Equipment { Id = 2, EquipmentId = "EQ-002", Name = "Drone B", Status = EquipmentStatus.Idle, LastMaintenance = DateTime.UtcNow.AddDays(-15), HoursUsed = 50, Battery = 60, Connectivity = EquipmentConnectivity.Offline },
			//   new Equipment { Id = 3, EquipmentId = "EQ-003", Name = "Sprinkler C", Status = EquipmentStatus.Maintenance, LastMaintenance = DateTime.UtcNow.AddDays(-10), HoursUsed = 30, Battery = 95, Connectivity = EquipmentConnectivity.Online },
			//   new Equipment { Id = 4, EquipmentId = "EQ-004", Name = "Harvester D", Status = EquipmentStatus.Active, LastMaintenance = DateTime.UtcNow.AddDays(-45), HoursUsed = 200, Battery = 75, Connectivity = EquipmentConnectivity.Online },
			//   new Equipment { Id = 5, EquipmentId = "EQ-005", Name = "Seeder E", Status = EquipmentStatus.Idle, LastMaintenance = DateTime.UtcNow.AddDays(-5), HoursUsed = 20, Battery = 100, Connectivity = EquipmentConnectivity.Offline },
			//   new Equipment { Id = 6, EquipmentId = "EQ-006", Name = "Plow F", Status = EquipmentStatus.Maintenance, LastMaintenance = DateTime.UtcNow.AddDays(-20), HoursUsed = 90, Battery = 50, Connectivity = EquipmentConnectivity.Online }
			// );

			//// Seed Initial Field Data
			//modelBuilder.Entity<Field>().HasData(
			//  new Field { Id = 1, Name = "Field Alpha", Size = 10.5, Crop = "Wheat", PlantingDate = DateTime.UtcNow.AddMonths(-3), HarvestDate = DateTime.UtcNow.AddMonths(2), Irrigation = IrrigationType.Drip, Status = FieldStatus.Planted },
			//  new Field { Id = 2, Name = "Field Beta", Size = 15.2, Crop = "Corn", PlantingDate = DateTime.UtcNow.AddMonths(-2), HarvestDate = DateTime.UtcNow.AddMonths(3), Irrigation = IrrigationType.Sprinkler, Status = FieldStatus.Planted },
			//  new Field { Id = 3, Name = "Field Gamma", Size = 8.0, Crop = "Rice", PlantingDate = DateTime.UtcNow.AddMonths(-4), HarvestDate = DateTime.UtcNow.AddMonths(1), Irrigation = IrrigationType.Flood, Status = FieldStatus.Planted },
			//  new Field { Id = 4, Name = "Field Delta", Size = 12.7, Crop = "Soybeans", PlantingDate = DateTime.UtcNow.AddMonths(-1), HarvestDate = DateTime.UtcNow.AddMonths(5), Irrigation = IrrigationType.Drip, Status = FieldStatus.Preparing },
			//  new Field { Id = 5, Name = "Field Epsilon", Size = 20.3, Crop = "Barley", PlantingDate = DateTime.UtcNow.AddMonths(-5), HarvestDate = DateTime.UtcNow.AddMonths(3), Irrigation = IrrigationType.CenterPivot, Status = FieldStatus.Planted },
			//  new Field { Id = 6, Name = "Field Zeta", Size = 9.5, Crop = "Oats", PlantingDate = DateTime.UtcNow.AddMonths(-6), HarvestDate = DateTime.UtcNow.AddMonths(4), Irrigation = IrrigationType.Manual, Status = FieldStatus.Fallow }
			//);
			//// Seed Initial SoilMoisture Data
			//modelBuilder.Entity<SoilMoisture>().HasData(
			//    new SoilMoisture { Id = 1, FieldName = "Field Alpha", Moisture = 58, Optimal = 65, PH = 6.2f, FieldId = 1 },
			//    new SoilMoisture { Id = 2, FieldName = "Field Beta", Moisture = 62, Optimal = 60, PH = 6.5f, FieldId = 2 },
			//    new SoilMoisture { Id = 3, FieldName = "Field Gamma", Moisture = 70, Optimal = 68, PH = 6.8f, FieldId = 3 },
			//    new SoilMoisture { Id = 4, FieldName = "Field Delta", Moisture = 45, Optimal = 60, PH = 5.9f, FieldId = 4 },
			//    new SoilMoisture { Id = 5, FieldName = "Field Epsilon", Moisture = 67, Optimal = 70, PH = 6.3f, FieldId = 5 },
			//    new SoilMoisture { Id = 6, FieldName = "Field Zeta", Moisture = 52, Optimal = 60, PH = 6.0f, FieldId = 6 }
			//);
			// Seed Alerts
			//modelBuilder.Entity<Alert>().HasData(
			//  new Alert
			//  {
			//   Id = 1,
			//   EmergencyType = EmergencyType.Irrigation,
			//   Message = "Low moisture detected in Field A",
			//   Severity = SeverityType.High,
			//   Latitude = 26.820553,
			//   Longitude = 30.802498,
			//   LocationDescription = "Farm Field #1",
			//   CreatedAt = DateTime.UtcNow.AddMinutes(-30)
			//  },
			//  new Alert
			//  {
			//   Id = 2,
			//   EmergencyType = EmergencyType.Pest,
			//   Message = "Pest activity reported in Wheat field",
			//   Severity = SeverityType.Medium,
			//   Latitude = 27.820553,
			//   Longitude = 31.802498,
			//   LocationDescription = "Farm Field #2",
			//   CreatedAt = DateTime.UtcNow.AddMinutes(-45)
			//  },
			//  new Alert
			//  {
			//   Id = 3,
			//   EmergencyType = EmergencyType.EquipmentFailure,
			//   Message = "Tractor requires maintenance",
			//   Severity = SeverityType.Low,
			//   Latitude = 28.820553,
			//   Longitude = 32.802498,
			//   LocationDescription = "Farm Field #3",
			//   CreatedAt = DateTime.UtcNow.AddMinutes(-60)
			//  },
			//  new Alert
			//  {
			//   Id = 4,
			//   EmergencyType = EmergencyType.SevereWeather,
			//   Message = "Storm warning for tonight",
			//   Severity = SeverityType.High,
			//   Latitude = 29.820553,
			//   Longitude = 33.802498,
			//   LocationDescription = "Farm Field #4",
			//   CreatedAt = DateTime.UtcNow.AddMinutes(-15)
			//  },
			//  new Alert
			//  {
			//   Id = 5,
			//   EmergencyType = EmergencyType.Soil,
			//   Message = "High pH level detected in Field B",
			//   Severity = SeverityType.Medium,
			//   Latitude = 30.820553,
			//   Longitude = 34.802498,
			//   LocationDescription = "Farm Field #5",
			//   CreatedAt = DateTime.UtcNow.AddMinutes(-20)
			//  },
			//  new Alert
			//  {
			//   Id = 6,
			//   EmergencyType = EmergencyType.Irrigation,
			//   Message = "Low moisture detected in Field C",
			//   Severity = SeverityType.High,
			//   Latitude = 31.820553,
			//   Longitude = 35.802498,
			//   LocationDescription = "Farm Field #6",
			//   CreatedAt = DateTime.UtcNow.AddMinutes(-5)
			//  },
			//  new Alert
			//  {
			//   Id = 7,
			//   EmergencyType = EmergencyType.Pest,
			//   Message = "Pest activity reported in Corn field",
			//   Severity = SeverityType.Medium,
			//   Latitude = 32.820553,
			//   Longitude = 36.802498,
			//   LocationDescription = "Farm Field #7",
			//   CreatedAt = DateTime.UtcNow.AddMinutes(-10)
			//  }, new Alert
			//  {
			//   Id = 8,
			//   EmergencyType = EmergencyType.MedicalEmergency,
			//   Message = "Medical emergency: Worker injured in Field A",
			//   Severity = SeverityType.High,
			//   Latitude = 26.820553,
			//   Longitude = 30.802498,
			//   LocationDescription = "Farm Field #1",
			//   CreatedAt = DateTime.UtcNow.AddMinutes(-3)
			//  },
			//  new Alert
			//  {
			//   Id = 9,
			//   EmergencyType = EmergencyType.Other,  // This will match "other"
			//   Message = "Unusual activity reported near the farm entrance",
			//   Severity = SeverityType.Low,
			//   Latitude = 27.820553,
			//   Longitude = 31.802498,
			//   LocationDescription = "Farm Entrance",
			//   CreatedAt = DateTime.UtcNow.AddMinutes(-2)
			//  });
		}
	}
}
