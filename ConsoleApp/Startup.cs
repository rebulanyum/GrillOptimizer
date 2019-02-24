using isolutions.GrillAssesment.Client;
using isolutions.GrillAssesment.Client.Model;
using Microsoft.Extensions.DependencyInjection;
using rebulanyum.GrillOptimizer.Business;
using System;
using System.Collections.Generic;

namespace rebulanyum.GrillOptimizer.ConsoleApp
{
    /// <summary>The Startup class: This class is for preparing the Dependency Injection for the Application class.</summary>
    public static class Startup
    {
        /// <summary>Dependency Injection cantainer's scope.</summary>
        public static readonly IServiceScope Scope;
        static Startup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IGrillMenuApi, GrillMenuApi>();
            serviceCollection.AddScoped<IGrillMenuPlanner, DefaultGrillMenuPlanner>();
            serviceCollection.AddSingleton(GrillConfiguration.Default);
            Scope = serviceCollection.BuildServiceProvider().CreateScope();
        }

        /// <summary>Main method for the application.</summary>
        static void Main()
        {
            using (Scope)
            {
                var app = new Application(Scope.ServiceProvider);
                app.Run();
            }
        }
    }
}
