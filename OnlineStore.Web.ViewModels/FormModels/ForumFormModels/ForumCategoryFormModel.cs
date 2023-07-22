namespace OnlineStore.Web.ViewModels.FormModels.ForumFormModels
{
    using OnlineStore.Web.Models.ForumModels;

    public class ForumCategoryFormModel
    {

        public ForumCategoryFormModel()
        {
            this.Posts = new HashSet<Post>();
        }
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Post> Posts { get; set; }    
    }
}
