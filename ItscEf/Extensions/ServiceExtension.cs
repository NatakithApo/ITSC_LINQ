using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ItscEf.Extensions
{
    public static class ServiceExtension
    {
        private static string GetNamespace(string nsString)
        {
            var execAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            return $"{execAssemblyName}.{nsString}";
        }

        private static List<Type> GetTypeOfNameSpace(string nsString )
        {
            return Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(t => t.Namespace == GetNamespace(nsString) && t.IsVisible)
                .ToList();
        }
        public static void AddRepositories(this IServiceCollection service)
        {
            List<Type> repositoryList = GetTypeOfNameSpace(nameof(Repositoies));
            List<Type> repositoryInterfaceList = GetTypeOfNameSpace(string.Format("{0}.{1}", nameof(Repositoies),nameof(Repositoies.Interface)));
            for(int i = 0; i < repositoryList.Count; i++)
            {
                service.AddScoped(repositoryInterfaceList[i], repositoryList[i]);
            }

        }

        public static void AddServices(this IServiceCollection service)
        {
            List<Type> serviceList = GetTypeOfNameSpace(nameof(Services));
            List<Type> serviceInterfaceList = GetTypeOfNameSpace(string.Format("{0}.{1}", nameof(Services), nameof(Services.Interface)));
            for (int i = 0; i < serviceList.Count; i++)
            {
                service.AddScoped(serviceInterfaceList[i],serviceList[i]);
            }

        }
    }
}
