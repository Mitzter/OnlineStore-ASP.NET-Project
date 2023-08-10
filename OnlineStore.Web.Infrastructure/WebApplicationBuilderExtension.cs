namespace OnlineStore.Web.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using OnlineStore.Web.Models.UserModels;
    using System.Reflection;

    using static Common.GeneralApplicationConstants;

    public static class WebApplicationBuilderExtension
    {
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid Service Type Provided!");
            }

            Type[] serviceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();
            foreach (Type sType in serviceTypes)
            {
                Type? interfaceType = sType
                    .GetInterface($"I{sType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No Interface detected for service :{sType.Name}");
                }

                services.AddScoped(interfaceType, sType);
            }
        }

        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                // Check if the "Administrator" role exists; if not, create it
                if (!await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);
                    await roleManager.CreateAsync(role);
                }

                // Check if the Admin user exists; if not, create and seed it
                ApplicationUser adminUser = await userManager.FindByEmailAsync(email);
                if (adminUser == null)
                {
                    adminUser = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        DisplayName = "Admin"
                    };
                    adminUser.EmailConfirmed = true;
                    string adminPassword = "admin1"; // Replace with the actual password
                    await userManager.CreateAsync(adminUser, adminPassword);
                }

                // Assign the "Administrator" role to the Admin user
                await userManager.AddToRoleAsync(adminUser, AdminRoleName);

            }).GetAwaiter().GetResult();
            return app;
        }
    }
}