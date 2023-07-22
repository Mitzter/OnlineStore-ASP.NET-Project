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

    public class ForumService : IForumService
    {
        private OnlineStoreDbContext dbcontext;

        public ForumService(OnlineStoreDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        
        public async Task<string> CreatePostAsync(PostFormModel model)
        {
               
            Post post = new Post()
            {
                Id = model.Id,
                Title = model.Title,
                Text = model.Text,
                ImageUrl = model.ImageUrl,
                Poster= model.Poster,
                CreatedOn = DateTime.Now,
                CategoryId = model.CategoryId,
            };

            await this.dbcontext.ForumPosts.AddAsync(post);
            await this.dbcontext.SaveChangesAsync();

            return post.Id.ToString();
        }

        public async Task<string> GetPostByIdAsync(string id)
        {
            Post post = await this.dbcontext
                .ForumPosts
                .FirstAsync(p => p.Id.ToString() == id);
            return post.Id.ToString();
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
                .FirstAsync(fc => fc.Id.ToString() == categoryId);

            return new ForumCategoryViewModel()
            {
                Id = forumCategory.Id,
                Name = forumCategory.Name,
                Posts = forumCategory.Posts,
            };
        }

        public Task<string> GetUserIdAsync()
        {
            throw new NotImplementedException();
        }
    }

}
