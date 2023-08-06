﻿namespace OnlineStore.Web.Models.StoreModels
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Item;

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
        [MaxLength(ItemDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
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

        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}