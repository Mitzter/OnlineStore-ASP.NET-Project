namespace OnlineStore.Services.Data._0_Interfaces.ForumInterfaces
{
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.ViewModels.FormModels.ForumFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.ForumViewModels;

    public interface IForumService
    {
        Task<int> GetPostByIdAsync(string id);
        Task<string> CreatePostAsync(PostFormModel model, string userId);

        Task<string> CreateReplyAsync(ReplyFormModel model, string userId);
        Task<ForumCategoryViewModel> GetSelectedCategoryViewAsync(string categoryId);

        Task<IEnumerable<ReplyFormModel>> GetPostRepliesAsync(string postId);

        Task<PostViewModel> ViewPostAsync(string postId);

        Task<IEnumerable<Post>> TopPostsAsync();

        Task<Post> FindPostById(int id);

        Task<IEnumerable<PostViewModel>> GetLatestForumPostsAsync();
    }
}
