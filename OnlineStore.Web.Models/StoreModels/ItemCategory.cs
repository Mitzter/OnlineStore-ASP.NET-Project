namespace OnlineStore.Web.Models.StoreModels
{
    using System.ComponentModel.DataAnnotations;

    public class ItemCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        public IEnumerable<Item> Items { get; set; } = new HashSet<Item>();
    }
}
