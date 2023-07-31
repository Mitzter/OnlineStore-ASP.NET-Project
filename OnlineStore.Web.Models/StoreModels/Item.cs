namespace OnlineStore.Web.Models.StoreModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Item
    {
        public Item()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ItemNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal BulkPrice { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public virtual ItemCategory Category { get; set; } = null!;

        public bool IsActive { get; set; }

        public int QuantityBought { get; set; }
    }
}