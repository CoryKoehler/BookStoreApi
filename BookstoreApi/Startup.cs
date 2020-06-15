using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BookstoreApi.EventFlow;
using EventFlow.EventStores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookstoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            var cosmosDbEventStoreUri = "mongodb://concept-proofing-cosmos:Gmn1baqAVpvLl6CZ8MzzW9eB40ZFwyncsW53xiQBmWQrdYKX6wPD3tv6uoMDHc2HAZp2eyq47ZL1RvrKYKsR9g==@concept-proofing-cosmos.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb";
            var cosmosDbEventStoreDatabase = "Events";

            containerBuilder.RegisterAssemblyModules(
                AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.StartsWith("Book", StringComparison.InvariantCulture)).ToArray());
            containerBuilder.AddEventFlow(cosmosDbEventStoreUri, cosmosDbEventStoreDatabase, GetType().Assembly);

            containerBuilder.RegisterType<MongoDbEventPersistenceInitializer>().As<IMongoDbEventPersistenceInitializer>()
                .SingleInstance();

            containerBuilder.RegisterType<MongoDbEventPersistence>().As<IEventPersistence>();
            containerBuilder.RegisterInstance(Configuration).As<IConfiguration>().SingleInstance();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.ApplicationServices.GetAutofacRoot().Resolve<IMongoDbEventPersistenceInitializer>().Initialize(false).Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
