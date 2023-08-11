namespace OnlineStore.Web.ViewModels.ViewModels.ForumViewModels
{
    public class AllPostsViewModel
    {
        public AllPostsViewModel()
        {
            this.AllPosts = new List<PostViewModel>();
        }

        public ICollection<PostViewModel> AllPosts { get; set; }
    }
}
