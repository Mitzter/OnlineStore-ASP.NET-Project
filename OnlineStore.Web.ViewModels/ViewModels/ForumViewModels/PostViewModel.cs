namespace OnlineStore.Web.ViewModels.ViewModels.ForumViewModels
{
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.UserModels;

    public class PostViewModel
    {
        public PostViewModel()
        {
            this.Replies = new HashSet<Reply>();
        }
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Text { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public Guid UserId { get; set; }

        public virtual ApplicationUser Poster { get; set; } = null!;
        public virtual IEnumerable<Reply> Replies { get; set; } = null!;
    }
}
