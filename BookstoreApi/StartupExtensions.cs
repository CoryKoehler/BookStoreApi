using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using EventFlow;
using EventFlow.Autofac.Extensions;
using EventFlow.Extensions;
using EventFlow.MongoDB.Extensions;
using Microsoft.Extensions.DependencyModel;
using Newtonsoft.Json;

namespace BookstoreApi
{
    public static class StartupExtensions
    {
        public static ContainerBuilder AddEventFlow(this ContainerBuilder containerBuilder,
           string cosmosDbEventStoreUri, string cosmosDbEventStoreDatabase, Assembly assembly)
        {
            var container = EventFlowOptions.New
                .Configure(c => c.IsAsynchronousSubscribersEnabled = true)
                .UseAutofacContainerBuilder(containerBuilder)
                .UseLibLog(LibLogProviders.Serilog)
                .ConfigureMongoDb(cosmosDbEventStoreUri, cosmosDbEventStoreDatabase)
                .UseMongoDbEventStore()
                .UseMongoDbSnapshotStore()
                .ConfigureJson(options => options.Configure(settings =>
                {
                    settings.TypeNameHandling = TypeNameHandling.Auto;
                    settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                }
                ))
                .AddDefaults(assembly)
                .ConfigureOptimisticConcurrentcyRetry(20, TimeSpan.FromMilliseconds(1));

            var domainAssemblies = GetDomainAssembliesForEventFlow();
            foreach (var domainAssembly in domainAssemblies)
            {
                container.AddDefaults(domainAssembly);
            }

            return containerBuilder;
        }

        private static Assembly[] GetDomainAssembliesForEventFlow()
        {
            return DependencyContext.Default.RuntimeLibraries
                .Where(x => x.Name.StartsWith("Book", StringComparison.InvariantCulture))
                .Select(x => Assembly.Load(new AssemblyName(x.Name)))
                .ToArray();
        }
    }
}
