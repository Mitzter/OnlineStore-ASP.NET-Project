﻿namespace OnlineStore.Services.Data.ForumServices
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
        
        public async Task<string> CreatePostAsync(PostFormModel model, string posterId)
        {

            Post post = new Post()
            {
                Id = model.Id,
                Title = model.Title,
                Text = model.Text,
                ImageUrl = model.ImageUrl,
                PosterId = Guid.Parse(posterId),
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
                .FirstAsync(p => p.Id == model.PostedAtId);

            string upperUserId = userId.ToUpper();
            Reply reply = new Reply()
            {
                Id = model.Id,
                Message = model.Message,
                UserId = Guid.Parse(upperUserId),
                PostedAtId = model.PostedAtId,
                CreatedOn = DateTime.UtcNow,

            };
                
            post.Replies.Add(reply);
            await this.dbcontext.ForumReplies.AddAsync(reply);
            await this.dbcontext.SaveChangesAsync();

            return reply.Id.ToString();
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
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == postId);

            return new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Text = post.Text,
                ImageUrl = post.ImageUrl,
                Poster = new UserInfoOnPostViewModel
                {
                    NickName = post.Poster.Email
                },
                Replies = post.Replies,

            };
                
        }
    }

}
