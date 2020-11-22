using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ChangeLogSystem.Data.IOC
{
    public static class Dependencies
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            List<Type> repositories = assembly.GetTypes()
                .Where(t => t.IsPublic
                            && t.IsClass
                            && t.Namespace.Contains("Repositories")
                            && t.Name.EndsWith("Repository", StringComparison.CurrentCulture)).ToList();

            foreach (Type repository in repositories)
            {
                Type repsoitoryType = repository.GetInterface($"I{repository.Name}");

                if (repsoitoryType != null)
                {
                    serviceCollection.Add(new ServiceDescriptor(repsoitoryType, repository, ServiceLifetime.Scoped));
                }
            }

            serviceCollection.AddScoped<Common.RespositoryManager>();
        }
    }
}