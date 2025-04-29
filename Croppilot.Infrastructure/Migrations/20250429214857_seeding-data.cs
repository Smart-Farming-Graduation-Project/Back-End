using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Croppilot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Daily harvested organic vegetables", "https://graduationprojetct.blob.core.windows.net/category-images/0bdbd4c8-2503-427c-b4fe-ffa6e5c57a23_Fresh Vegetables.jpg", "Fresh Vegetables" },
                    { 2, "Naturally grown fruits with authentic flavors", "https://graduationprojetct.blob.core.windows.net/category-images/5caaf20a-3510-4d38-b2b4-b16e79cf45ab_Seasonal Fruits.jpg", "Seasonal Fruits" },
                    { 3, "Fresh cheese and milk from our farm", "https://graduationprojetct.blob.core.windows.net/category-images/61cd1282-c3c4-4ef3-9b2c-ae7d5beb482c_Dairy Products.jpg", "Dairy Products" },
                    { 4, "Free-range chicken eggs", "https://graduationprojetct.blob.core.windows.net/category-images/b7f5884a-6833-43f0-bb78-367c371a37fb_Organic Eggs.jpg", "Organic Eggs" },
                    { 5, "Home garden flowers and decorative plants", "https://graduationprojetct.blob.core.windows.net/category-images/9aa3dfb7-12b7-4631-908c-eb11fa0c64f9_Ornamental Plants.jpg", "Ornamental Plants" },
                    { 6, "Vegetable and fruit starters for home gardening", "https://graduationprojetct.blob.core.windows.net/category-images/28773f2f-5619-406e-8c74-1cd82b296d3f_Seedlings.jpg", "Seedlings" },
                    { 7, "Natural feed for livestock and poultry", "https://graduationprojetct.blob.core.windows.net/category-images/a5a834c1-736c-4858-95df-673e21014525_Organic Animal Feed.jpg", "Organic Animal Feed" },
                    { 8, "Essential agricultural equipment", "https://graduationprojetct.blob.core.windows.net/category-images/c10224a6-0625-41a3-8332-73433f96f39e_Farming Tools.jpg", "Farming Tools" },
                    { 9, "Certified high-yield seeds", "https://graduationprojetct.blob.core.windows.net/category-images/6c4bef01-1181-4fde-8bc4-78331a8c82d2_Premium Seeds.jpg", "Premium Seeds" },
                    { 10, "Natural soil enhancers", "https://graduationprojetct.blob.core.windows.net/category-images/242d456f-5b41-4d3a-8744-cd18ec583aae_Organic Fertilizers.jpg", "Organic Fertilizers" }
                });

            migrationBuilder.InsertData(
                table: "EmergencyAlerts",
                columns: new[] { "Id", "CreatedAt", "EmergencyType", "Latitude", "LocationDescription", "Longitude", "Message", "Severity" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 29, 21, 18, 56, 657, DateTimeKind.Utc).AddTicks(2434), 5, 26.820553, "Farm Field #1", 30.802498, "Low moisture detected in Field A", 2 },
                    { 2, new DateTime(2025, 4, 29, 21, 3, 56, 657, DateTimeKind.Utc).AddTicks(2436), 4, 27.820553, "Farm Field #2", 31.802498, "Pest activity reported in Wheat field", 1 },
                    { 3, new DateTime(2025, 4, 29, 20, 48, 56, 657, DateTimeKind.Utc).AddTicks(2438), 0, 28.820553, "Farm Field #3", 32.802498, "Tractor requires maintenance", 0 },
                    { 4, new DateTime(2025, 4, 29, 21, 33, 56, 657, DateTimeKind.Utc).AddTicks(2452), 3, 29.820553, "Farm Field #4", 33.802498, "Storm warning for tonight", 2 },
                    { 5, new DateTime(2025, 4, 29, 21, 28, 56, 657, DateTimeKind.Utc).AddTicks(2454), 6, 30.820553, "Farm Field #5", 34.802498, "High pH level detected in Field B", 1 },
                    { 6, new DateTime(2025, 4, 29, 21, 43, 56, 657, DateTimeKind.Utc).AddTicks(2455), 5, 31.820553, "Farm Field #6", 35.802498, "Low moisture detected in Field C", 2 },
                    { 7, new DateTime(2025, 4, 29, 21, 38, 56, 657, DateTimeKind.Utc).AddTicks(2457), 4, 32.820552999999997, "Farm Field #7", 36.802498, "Pest activity reported in Corn field", 1 },
                    { 8, new DateTime(2025, 4, 29, 21, 45, 56, 657, DateTimeKind.Utc).AddTicks(2458), 1, 26.820553, "Farm Field #1", 30.802498, "Medical emergency: Worker injured in Field A", 2 },
                    { 9, new DateTime(2025, 4, 29, 21, 46, 56, 657, DateTimeKind.Utc).AddTicks(2460), 7, 27.820553, "Farm Entrance", 31.802498, "Unusual activity reported near the farm entrance", 0 }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Battery", "Connectivity", "EquipmentId", "HoursUsed", "LastMaintenance", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 85.0, 0, "EQ-001", 120.0, new DateTime(2025, 3, 30, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2297), "Tractor A", 0 },
                    { 2, 60.0, 1, "EQ-002", 50.0, new DateTime(2025, 4, 14, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2313), "Drone B", 2 },
                    { 3, 95.0, 0, "EQ-003", 30.0, new DateTime(2025, 4, 19, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2315), "Sprinkler C", 1 },
                    { 4, 75.0, 0, "EQ-004", 200.0, new DateTime(2025, 3, 15, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2316), "Harvester D", 0 },
                    { 5, 100.0, 1, "EQ-005", 20.0, new DateTime(2025, 4, 24, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2318), "Seeder E", 2 },
                    { 6, 50.0, 0, "EQ-006", 90.0, new DateTime(2025, 4, 9, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2320), "Plow F", 1 }
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Crop", "HarvestDate", "Irrigation", "Name", "PlantingDate", "Size", "Status" },
                values: new object[,]
                {
                    { 1, "Wheat", new DateTime(2025, 6, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2357), 1, "Field Alpha", new DateTime(2025, 1, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2350), 10.5, 2 },
                    { 2, "Corn", new DateTime(2025, 7, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2361), 2, "Field Beta", new DateTime(2025, 2, 28, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2360), 15.199999999999999, 2 },
                    { 3, "Rice", new DateTime(2025, 5, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2364), 3, "Field Gamma", new DateTime(2024, 12, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2362), 8.0, 2 },
                    { 4, "Soybeans", new DateTime(2025, 9, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2366), 1, "Field Delta", new DateTime(2025, 3, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2365), 12.699999999999999, 4 },
                    { 5, "Barley", new DateTime(2025, 7, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2368), 5, "Field Epsilon", new DateTime(2024, 11, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2367), 20.300000000000001, 2 },
                    { 6, "Oats", new DateTime(2025, 8, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2370), 4, "Field Zeta", new DateTime(2024, 10, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2369), 9.5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Availability", "CategoryId", "CreatedAt", "CuponId", "Description", "Name", "Price", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2080), null, "Fresh vine-ripened tomatoes", "Organic Tomatoes", 19.99m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2081), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 2, 0, 1, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2083), null, "Crisp and refreshing cucumbers", "Cucumbers", 12.50m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2084), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 3, 1, 1, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2086), null, "Mixed color sweet peppers", "Bell Peppers", 18.75m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2086), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 4, 0, 2, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2089), null, "Sweet and juicy strawberries", "Strawberries", 25.99m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2089), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 5, 0, 2, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2092), null, "Premium imported mangoes", "Mangoes", 30.50m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2092), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 6, 0, 2, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2094), null, "Large sweet watermelons", "Watermelons", 45.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2095), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 7, 0, 3, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2097), null, "Whole milk 1L bottle", "Farm Fresh Milk", 20.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2097), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 8, 0, 3, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2099), null, "Aged cheddar cheese 200g", "Artisan Cheese", 35.75m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2099), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 9, 0, 3, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2102), null, "Natural Yogurt", "Natural Yogurt", 18.50m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2102), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 10, 0, 4, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2104), null, "Large brown eggs", "Free-Range Eggs (12pk)", 30.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2104), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 11, 0, 5, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2106), null, "Red rose plant in 12\" pot", "Rose Bush", 120.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2107), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 12, 0, 5, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2109), null, "Fragrant lavender for gardens", "Lavender Plant", 85.50m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2109), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 13, 0, 6, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2112), null, "Early girl tomato plants", "Tomato Seedlings", 15.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2112), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 14, 0, 6, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2114), null, "Burpless cucumber plants, disease-resistant", "Cucumber Seedlings", 13.25m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2115), "642b8bd1-a65f-4598-95bc-29b833dcb84e" },
                    { 15, 0, 7, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2117), null, "Organic chicken feed", "Poultry Feed 20kg", 150.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2117), "655501be-8ca7-434d-9cbe-6e8d23b3d92c" },
                    { 16, 0, 7, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2119), null, "Nutritional cattle mix", "Cattle Feed 25kg", 220.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2120), "655501be-8ca7-434d-9cbe-6e8d23b3d92c" },
                    { 17, 0, 8, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2122), null, "Professional grade shears", "Pruning Shears", 65.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2122), "655501be-8ca7-434d-9cbe-6e8d23b3d92c" },
                    { 18, 0, 8, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2124), null, "Sturdy steel garden hoe", "Garden Hoe", 45.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2124), "655501be-8ca7-434d-9cbe-6e8d23b3d92c" },
                    { 19, 0, 10, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2126), null, "Nutrient-rich compost", "Compost 10kg", 40.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2127), "655501be-8ca7-434d-9cbe-6e8d23b3d92c" },
                    { 20, 0, 10, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2129), null, "Organic soil amendment", "Worm Castings", 55.00m, new DateTime(2025, 4, 29, 21, 48, 56, 657, DateTimeKind.Utc).AddTicks(2129), "655501be-8ca7-434d-9cbe-6e8d23b3d92c" }
                });

            migrationBuilder.InsertData(
                table: "SoilMoistures",
                columns: new[] { "Id", "FieldId", "FieldName", "Moisture", "Optimal", "PH" },
                values: new object[,]
                {
                    { 1, 1, "Field Alpha", 58, 65, 6.2f },
                    { 2, 2, "Field Beta", 62, 60, 6.5f },
                    { 3, 3, "Field Gamma", 70, 68, 6.8f },
                    { 4, 4, "Field Delta", 45, 60, 5.9f },
                    { 5, 5, "Field Epsilon", 67, 70, 6.3f },
                    { 6, 6, "Field Zeta", 52, 60, 6f }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://graduationprojetct.blob.core.windows.net/product-images/Organic Tomatoes_2520f86d-8700-4b06-bed5-e9e317e71d95_R %283%29.jpg", 1 },
                    { 2, "https://graduationprojetct.blob.core.windows.net/product-images/Cucumbers_d29f0202-cbf9-4f0e-ae62-344521eec15c_R %284%29.jpg", 2 },
                    { 3, "https://graduationprojetct.blob.core.windows.net/product-images/Cucumbers_771c182f-18c0-43b4-af95-281406ed89fe_OIP.jpg", 2 },
                    { 4, "https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_765ca4be-6179-4ce9-bed6-57613481d475_OIP %281%29.jpg", 3 },
                    { 5, "https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_7d5babea-020f-4e79-8552-9450f997853e_primary-430.jpg", 3 },
                    { 6, "https://graduationprojetct.blob.core.windows.net/product-images/Bell Peppers_d561a4c3-5e47-4ec4-9a40-dccc6b7157bc_Bell-Peppers.jpg", 3 },
                    { 7, "https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_b66be9e1-5421-4592-9038-a546c2c49bd6_R %285%29.jpg", 7 },
                    { 8, "https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_affe0646-14b5-4440-9373-823c0aab4132_R %286%29.jpg", 7 },
                    { 9, "https://graduationprojetct.blob.core.windows.net/product-images/Farm Fresh Milk_5d1f9c4f-444c-49d3-8cb0-eb4e1ff19d40_R %287%29.jpg", 7 },
                    { 10, "https://graduationprojetct.blob.core.windows.net/product-images/Strawberries_eefc35b5-e857-4cf5-a5a3-b09fa75f3c6f_R %288%29.jpg", 4 },
                    { 11, "https://graduationprojetct.blob.core.windows.net/product-images/Strawberries_779eca40-dfb3-4c51-9ae4-f6d022bdea1a_R %289%29.jpg", 4 },
                    { 12, "https://graduationprojetct.blob.core.windows.net/product-images/Mangoes_d0c89732-4204-4804-ba7c-d0ef0a822573_download.jpg", 5 },
                    { 13, "https://graduationprojetct.blob.core.windows.net/product-images/Mangoes_0aa7f942-c40f-4f0f-a2d0-f960d599a9d2_OIP %282%29.jpg", 5 },
                    { 14, "https://graduationprojetct.blob.core.windows.net/product-images/Watermelons_f13f305a-8f7d-4bdd-ad67-08982d51bd88_OIP %283%29.jpg", 6 },
                    { 15, "https://graduationprojetct.blob.core.windows.net/product-images/Watermelons_5a90c66a-c7c8-4de4-8ae3-c5d763f63955_OIP %284%29.jpg", 6 },
                    { 16, "https://graduationprojetct.blob.core.windows.net/product-images/Artisan Cheese_a1d3e7ec-afba-4883-812d-30216c3cb4e7_R %2810%29.jpg", 8 },
                    { 17, "https://graduationprojetct.blob.core.windows.net/product-images/Artisan Cheese_26e0102e-b43e-4124-b3af-9d87e6ad5ce5_OIP %285%29.jpg", 8 },
                    { 18, "https://graduationprojetct.blob.core.windows.net/product-images/Natural Yogurt_c5f98e11-0931-43e2-9d9a-fd70f42a5dbd_OIP %286%29.jpg", 9 },
                    { 19, "https://graduationprojetct.blob.core.windows.net/product-images/Natural Yogurt_7337ee02-8893-4ab2-aec7-cb1414df80dd_R %2811%29.jpg", 9 },
                    { 20, "https://graduationprojetct.blob.core.windows.net/product-images/Free-Range Eggs %2812pk%29_2d35c5fc-6d4c-4f8e-aa13-1c16ed674601_OIP %287%29.jpg", 10 },
                    { 21, "https://graduationprojetct.blob.core.windows.net/product-images/Free-Range Eggs %2812pk%29_33b205d9-91da-40ef-9a96-c9a0337b3fe4_OIP %288%29.jpg", 10 },
                    { 22, "https://graduationprojetct.blob.core.windows.net/product-images/Rose Bush_c7bff713-4c6c-4352-869e-c85f673baf1f_R %2812%29.jpg", 11 },
                    { 23, "https://graduationprojetct.blob.core.windows.net/product-images/Rose Bush_edb3d662-5727-4c71-93a5-bb460cddd3c3_OIP %289%29.jpg", 11 },
                    { 24, "https://graduationprojetct.blob.core.windows.net/product-images/Lavender Plant_53ef2c19-0a3b-4114-b178-32c1a6110069_OIP %2810%29.jpg", 12 },
                    { 25, "https://graduationprojetct.blob.core.windows.net/product-images/Tomato Seedlings_e6e9622b-bbc1-4aa6-96b2-297ebb8257f4_IMG_9275.jpg", 13 },
                    { 26, "https://graduationprojetct.blob.core.windows.net/product-images/Cucumber Seedlings_89f422cb-7093-4814-bd2f-0d4ad099cc6e_R %2813%29.jpg", 14 },
                    { 27, "https://graduationprojetct.blob.core.windows.net/product-images/Poultry Feed 20kg_e9e91afb-1a50-4726-bd37-e162ec9ed15a_OIP %2811%29.jpg", 15 },
                    { 28, "https://graduationprojetct.blob.core.windows.net/product-images/Poultry Feed 20kg_2a70c24b-9b7a-4905-af6e-796ab5566709_OIP %2812%29.jpg", 15 },
                    { 29, "https://graduationprojetct.blob.core.windows.net/product-images/Cattle Feed 25kg_c8ec9374-4839-4004-96c1-0054ad698925_OIP %2813%29.jpg", 16 },
                    { 30, "https://graduationprojetct.blob.core.windows.net/product-images/Cattle Feed 25kg_b441f3a3-b774-4efb-bf75-543fa2700a4e_OIP %2814%29.jpg", 16 },
                    { 31, "https://graduationprojetct.blob.core.windows.net/product-images/Pruning Shears_e40f5237-442d-4452-8f32-2883bcfbe8bf_OIP %2815%29.jpg", 17 },
                    { 32, "https://graduationprojetct.blob.core.windows.net/product-images/Pruning Shears_54af077d-62db-4fe4-9bcb-ad0fbf184d15_OIP %2816%29.jpg", 17 },
                    { 33, "https://graduationprojetct.blob.core.windows.net/product-images/Garden Hoe_477a31d4-f9c0-4ec2-bd8f-bc81c5aaeaac_OIP %2817%29.jpg", 18 },
                    { 34, "https://graduationprojetct.blob.core.windows.net/product-images/Compost 10kg_d8e29f75-83a8-4968-992f-343303f0404b_61gvcvZgosL._AC_SL1500_.jpg", 19 },
                    { 35, "https://graduationprojetct.blob.core.windows.net/product-images/Compost 10kg_a02227ba-a1a8-4053-9f95-7c354402c179_R %2814%29.jpg", 19 },
                    { 36, "https://graduationprojetct.blob.core.windows.net/product-images/Worm Castings_e1155a6c-3ce2-4d69-979f-a8840c282f02_OIP %2818%29.jpg", 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EmergencyAlerts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SoilMoistures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SoilMoistures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SoilMoistures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SoilMoistures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SoilMoistures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SoilMoistures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
