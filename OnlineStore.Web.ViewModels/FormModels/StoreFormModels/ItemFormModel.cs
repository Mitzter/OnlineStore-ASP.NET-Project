﻿namespace OnlineStore.Web.ViewModels.FormModels.StoreFormModels
{
    using System.ComponentModel.DataAnnotations;

    public class ItemFormModel
    {

        public ItemFormModel()
        {
            Categories = new HashSet<ItemSelectCategoryFormModel>();
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
        [Range(0.00, 20000,
            ErrorMessage = "Price cannot be negative!")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Range(0.00, 20000,
            ErrorMessage = "Price cannot be negative!")]
        [Display(Name = "Bulk Price")]
        public decimal BulkPrice { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ItemSelectCategoryFormModel> Categories { get; set; }
    }
}