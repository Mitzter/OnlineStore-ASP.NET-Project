namespace OnlineStore.Web.Models.ForumModels
{
    using System.ComponentModel.DataAnnotations;

    public  class ForumCategory
    {
        public ForumCategory()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        public IEnumerable<Post> Posts { get; set; }
    }
}
