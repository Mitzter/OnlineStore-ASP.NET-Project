namespace OnlineStore.Web.ViewModels.ViewModels.ForumViewModels
{
    using OnlineStore.Web.Models.ForumModels;

    public class ForumCategoryViewModel
    {
        public ForumCategoryViewModel()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual IEnumerable<Post> Posts { get; set; } = null!;
    }
}
