namespace OnlineStore.Web.ViewModels.ViewModels.ForumViewModels
{
    using OnlineStore.Web.ViewModels.FormModels.ForumFormModels;

    public class ForumMainViewModel
    {
        public IEnumerable<ForumCategoryFormModel> Categories { get; set; } = null!;
        public IEnumerable<PostViewModel> LatestPosts { get; set; } = null!;
    }

}
