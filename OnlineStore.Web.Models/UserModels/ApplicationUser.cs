﻿namespace OnlineStore.Web.Models.UserModels
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
            this.Orders = new HashSet<Order>();
        }

        public string? DisplayName { get; set; }

        public byte[]? PictureSource { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public virtual List<Item>? BoughtItems { get; set; }

        public virtual ICollection<Order> Orders { get; set; }



    }
}
