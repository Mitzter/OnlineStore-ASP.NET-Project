namespace OnlineStore.Web.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineStore.Web.Models.StoreModels;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            

            builder.HasData(this.GenerateCategories());
        }

        private ItemCategory[] GenerateCategories()
        {
            ICollection<ItemCategory> categories = new HashSet<ItemCategory>();

            ItemCategory category;
            category = new ItemCategory()
            {
                Id = 1,
                Name = "Spray"
            };
            categories.Add(category);
            category = new ItemCategory()
            {
                Id = 2,
                Name = "Consumable"
            };
            categories.Add(category);
            category = new ItemCategory()
            {
                Id = 3,
                Name = "Part"
            };
            categories.Add(category);
            category = new ItemCategory()
            {
                Id = 4,
                Name = "Accessory"
            };
            categories.Add(category);
            category = new ItemCategory()
            {
                Id = 5,
                Name = "Cosmetic"
            };
            categories.Add(category);
            category = new ItemCategory()
            {
                Id = 6,
                Name = "Tool"
            };
            categories.Add(category);

            return categories.ToArray();


        }
    }
}
