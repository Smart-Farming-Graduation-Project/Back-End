namespace Croppilot.Infrastructure.Data.SeedData
{
    public static class ProductImageSeed
    {
        public static void SeedProductImages(this ModelBuilder modelBuilder)
        {
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
        }
    }
}
