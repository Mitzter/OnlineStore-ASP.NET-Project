namespace OnlineStore.Web.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

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
    }
}