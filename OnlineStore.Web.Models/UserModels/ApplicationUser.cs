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
        }

        
        public virtual ICollection<Post> Posts { get; set; }
        
        public virtual ICollection<Reply> Replies { get; set; }

        public virtual List<Item> BoughtItems { get; set; }


    }
}
