using isolutions.GrillAssesment.Client;
using isolutions.GrillAssesment.Client.Model;
using Microsoft.Extensions.DependencyInjection;
using rebulanyum.GrillOptimizer.Business;
using System;
using System.Collections.Generic;

namespace rebulanyum.GrillOptimizer.ConsoleApp
{
    public static class Startup
    {
        public static readonly IServiceScope Scope;
        static Startup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IGrillMenuApi, GrillMenuApi>();
            serviceCollection.AddScoped<IGrillMenuPlanner, DefaultGrillMenuPlanner>();
            serviceCollection.AddSingleton(GrillConfiguration.Default);
            Scope = serviceCollection.BuildServiceProvider().CreateScope();
        }

        static void Main(string[] args)
        {
            using (Scope)
            {
                var app = new Application(Scope.ServiceProvider);
                app.Run(args);
            }
        }
    }
}
