using OnlineStore.Web.Models.UserModels;

public static class ProfileImageFunctions
{
    public static string GetProfileImage(ApplicationUser user)
    {
        if (user.PictureSource == null)
        {
            return "/images/default-user-picture.png";
        }
        else
        {
            string base64Image = Convert.ToBase64String(user.PictureSource);
            string imageSrc = $"data:image/png;base64,{base64Image}";
            return imageSrc;
        }
    }
}