namespace OnlineStore.Web.ViewModels
{
    using OnlineStore.Web.Models.ForumModels;

    public class IndexViewModel
    {

        public IndexViewModel()
        {
            this.Posts = new HashSet<Post>();
        }
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public IEnumerable<Post> Posts { get; set;}

    }
}
