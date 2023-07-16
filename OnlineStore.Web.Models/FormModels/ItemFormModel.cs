namespace OnlineStore.Web.Models.FormModels
{
    using System.ComponentModel.DataAnnotations;

    public class ItemFormModel
    {

        public ItemFormModel()
        {
            this.Categories = new HashSet<ItemSelectCategoryFormModel>();
        }
        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(500)]

        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(255)]

        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Bulk Price")]
        public decimal BulkPrice { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ItemSelectCategoryFormModel> Categories { get; set; }
    }
}
