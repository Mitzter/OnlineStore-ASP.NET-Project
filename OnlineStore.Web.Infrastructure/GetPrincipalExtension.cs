namespace OnlineStore.Web.Infrastructure
{
    using System.Security.Claims;

    public static class GetPrincipalExtension
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
