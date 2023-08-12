using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Web.Data;
namespace OnlineStore.Web
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Services.Data;
    using OnlineStore.Services.Data.Interfaces.StoreInterfaces;
    using OnlineStore.Services.Mapping;
    using OnlineStore.Web.Data;
    using OnlineStore.Web.Infrastructure;
    using OnlineStore.Web.Models;
    using OnlineStore.Web.Models.UserModels;
    using System.Reflection;
    using static Common.GeneralApplicationConstants;
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
                //options.SignIn.RequireConfirmedAccount =
                //       builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                //options.Password.RequireLowercase =
                //    builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                //options.Password.RequireUppercase =
                //    builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                //options.Password.RequireNonAlphanumeric =
                //    builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                //options.Password.RequiredLength =
                //    builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<OnlineStoreDbContext>();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            builder.Services.AddApplicationServices(typeof(IItemService));

            WebApplication app = builder.Build();

            app.UseSession();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            using var scope = app.Services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            if (app.Environment.IsDevelopment())
            {
                
                app.SeedAdministrator(DevelopmentAdminEmail);
            }
            

            app.UseEndpoints(config =>
            {
               
                config.MapControllerRoute(
                name: "areas",
                pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}");

                config.MapControllerRoute(
                name: "default",
                pattern: "/{controller=Home}/{action=Index}/{id?}/");
               
                config.MapDefaultControllerRoute();
                config.MapRazorPages();
                
            });
            
            app.Run();
        }
    }
}