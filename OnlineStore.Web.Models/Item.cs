namespace OnlineStore.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        public Item()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(10)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal BulkPrice { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}