namespace OnlineStore.Web.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineStore.Web.Models.ForumModels;
    using System;

    public class ForumEntityConfiguration : IEntityTypeConfiguration<ForumCategory>
    {
        public void Configure(EntityTypeBuilder<ForumCategory> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private ForumCategory[] GenerateCategories()
        {
            ICollection<ForumCategory> categories = new HashSet<ForumCategory>();

            ForumCategory category;
            category = new ForumCategory()
            {
                Id = 1,
                Name = "General"
            };
            categories.Add(category);

            category = new ForumCategory()
            {
                Id = 2,
                Name = "Off-topic Lounge"
            };
            categories.Add(category);

            category = new ForumCategory()
            {
                Id = 3,
                Name = "Questions and Support"
            };
            categories.Add(category);

            category = new ForumCategory()
            {
                Id = 4,
                Name = "Reports"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
