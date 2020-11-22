using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChangeLogSystem.Domain.IOC
{
    public static class Dependencies
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            Data.IOC.Dependencies.Register(serviceCollection);

            Assembly assembly = Assembly.GetExecutingAssembly();
            List<Type> models = assembly.GetTypes()
                .Where(t => t.IsPublic && t.IsClass && t.Namespace.Contains("Models")).ToList();

            foreach (Type model in models)
            {
                Type serviceType = model.GetInterface($"I{model.Name}");

                if (serviceType != null)
                {
                    serviceCollection.Add(new ServiceDescriptor(serviceType, model, ServiceLifetime.Transient));
                }
            }

            List<Type> services = assembly.GetTypes()
                .Where(t => t.IsPublic && t.IsClass && t.Namespace.Contains("Services") && t.Name.EndsWith("Services", StringComparison.CurrentCulture)).ToList();

            foreach (Type service in services)
            {
                Type serviceType = service.GetInterface("I" + service.Name);

                if (serviceType != null)
                {
                    serviceCollection.Add(new ServiceDescriptor(serviceType, service, ServiceLifetime.Scoped));
                }
            }

            serviceCollection.AddScoped<Common.ModelManager>();
            serviceCollection.AddScoped<Common.ServiceManager>();
        }
    }
}