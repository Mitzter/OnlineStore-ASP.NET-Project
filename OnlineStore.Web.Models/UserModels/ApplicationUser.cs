namespace OnlineStore.Web.Models.UserModels
{
    using Microsoft.AspNetCore.Identity;
    using OnlineStore.Web.Models.ForumModels;
    using OnlineStore.Web.Models.StoreModels;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.Posts = new HashSet<Post>();
            this.Replies = new HashSet<Reply>();
            this.BoughtItems = new HashSet<Item>();
        }

        public virtual ICollection<Post> Posts { get; set; }
        
        public virtual ICollection<Reply> Replies { get; set; }

        public virtual ICollection<Item> BoughtItems { get; set; }


    }
}
