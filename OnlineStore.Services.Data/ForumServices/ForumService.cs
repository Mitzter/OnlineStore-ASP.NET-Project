namespace OnlineStore.Services.Data.ForumServices
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data._0_Interfaces.ForumInterfaces;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.ViewModels.FormModels.ForumFormModels;
    using OnlineStore.Web.ViewModels.ViewModels.ForumViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using static OnlineStore.Web.Infrastructure.GetPrincipalExtension;
    using OnlineStore.Web.Models.UserModels;

    public class ForumService : IForumService
    {
        private readonly OnlineStoreDbContext dbcontext;

        public ForumService(OnlineStoreDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task ChangePostStatusAsync(string id, int status)
        {
            

            Post? post = await this.dbcontext
                .ForumPosts
                .FirstOrDefaultAsync(p => p.Id.ToString() == id);

            bool changeStatus = true;
            if (status != 0)
            {
                changeStatus = false;
            }

            post.IsActive = changeStatus;
            await this.dbcontext.SaveChangesAsync();
        }

        public async Task<string> CreatePostAsync(PostFormModel model, string posterId)
        {
            var user = await this.dbcontext
                .Users.FirstAsync(u => u.Id == Guid.Parse(posterId));
            
            Post post = new Post()
            {
                Id = model.Id,
                Title = model.Title,
                Text = model.Text,
                ImageUrl = model.ImageUrl,
                PosterId = user.Id,
                Poster = user,
                CreatedOn = DateTime.UtcNow,
                CategoryId = model.CategoryId,
                Replies = (ICollection<Reply>)model.Replies,
            };

            await this.dbcontext.ForumPosts.AddAsync(post);
            await this.dbcontext.SaveChangesAsync();

            return post.Id.ToString();
        }

        public async Task<string> CreateReplyAsync(ReplyFormModel model, string userId)
        {
            Post post = await this.dbcontext
                .ForumPosts
                .Include(p => p.Replies)
                .ThenInclude(r => r.User)
                .FirstAsync(p => p.Id == model.PostedAtId);

            var user = await this.dbcontext
                .Users.FirstAsync(u => u.Id == Guid.Parse(userId));

            Reply reply = new Reply()
            {
                Id = model.Id,
                Message = model.Message,
                UserId = user.Id,
                User = user,
                PostedAtId = model.PostedAtId,
                PostedAt = post,
                CreatedOn = DateTime.UtcNow,

            };
            
            
            post.Replies.Add(reply);
            await this.dbcontext.ForumReplies.AddAsync(reply);
            await this.dbcontext.SaveChangesAsync();

            return reply.Id.ToString();
        }

        public async Task<Post> FindPostById(int id)
        {
            Post post = await this.dbcontext
                .ForumPosts
                .FirstAsync(p => p.Id == id);

           
            return post;
        }

        public async Task<AllPostsViewModel> GetAllPostsAsync()
        {
            ICollection<Post> posts = await this.dbcontext
                .ForumPosts
                .Include(p => p.Poster)
                .Include(p => p.Replies)
                .ThenInclude(r => r.User)
                .ToListAsync();

            List<PostViewModel> postsVM = new List<PostViewModel>();
            PostViewModel singlePostVM;

            foreach (var post in posts)
            {
                singlePostVM = new PostViewModel()
                {
                    Id = post.Id,
                    CreatedAt = post.CreatedOn,
                    ImageUrl = post.ImageUrl,
                    Poster = post.Poster,
                    Replies = post.Replies,
                    Text = post.Text,
                    Title = post.Title,
                    IsActive = post.IsActive,
                };

                postsVM.Add(singlePostVM);
            }

            return new AllPostsViewModel()
            {
                AllPosts = postsVM
            };
        }

        public async Task<IEnumerable<PostViewModel>> GetLatestForumPostsAsync()
        {
            var latestPosts = await this.dbcontext.ForumPosts
                .OrderByDescending(p => p.CreatedOn)
                .Take(10)
                .Select(post => new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    CreatedAt = post.CreatedOn,
                    Replies = post.Replies,
                    IsActive = post.IsActive,

                })
                .ToListAsync();

            return latestPosts;
        }

        public async Task<int> GetPostByIdAsync(string id)
        {
            Post post = await this.dbcontext
                .ForumPosts
                .FirstAsync(p => p.Id.ToString() == id);
            return post.Id;
        }

        public async Task<IEnumerable<ReplyFormModel>> GetPostRepliesAsync(string postId)
        {
            IEnumerable<ReplyFormModel> replies = await this.dbcontext
                .ForumReplies
                .Select(r => new ReplyFormModel()
                {
                    Id = r.Id,
                    Message = r.Message,
                    PostedAtId = int.Parse(postId),
                    PostedAt = r.PostedAt,
                    PosterId = r.UserId,
                    User = r.User,
                    CreatedOn = DateTime.UtcNow
                }).ToListAsync();

            return replies;
                
        }

        public async Task<ForumCategoryViewModel> GetSelectedCategoryViewAsync(string categoryId)
        {
            ForumCategory forumCategory = await this.dbcontext
                .ForumCategories
                .Include(c => c.Posts)
                .ThenInclude(p => p.Replies)
                .FirstAsync(fc => fc.Id.ToString() == categoryId);

            return new ForumCategoryViewModel()
            {
                Id = forumCategory.Id,
                Name = forumCategory.Name,
                Posts = forumCategory.Posts,
            };
        }

        public async Task<IEnumerable<Post>> TopPostsAsync()
        {
            IEnumerable<Post> posts = await this.dbcontext
                .ForumPosts
                .OrderBy(p => p.RepliesCount)
                .Take(5)
                .ToArrayAsync();

            return posts;
        }

        public async Task<PostViewModel> ViewPostAsync(string postId)
        {

            Post post = await dbcontext
                .ForumPosts
                .Include(p => p.Poster)
                .Include(p => p.Replies)
                .ThenInclude(r => r.User)
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == postId);

            return new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Text = post.Text,
                ImageUrl = post.ImageUrl,
                Poster = post.Poster,
                Replies = post.Replies,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
            };
                
        }
    }

}
