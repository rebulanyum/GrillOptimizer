using isolutions.GrillAssesment.Client;
using isolutions.GrillAssesment.Client.Model;
using Microsoft.Extensions.DependencyInjection;
using rebulanyum.GrillOptimizer.Business;
using System;
using System.Collections.Generic;

namespace rebulanyum.GrillOptimizer.ConsoleApp
{
    /// <summary>The Application class: It uses the Dependency Injection container and executes the Run method.</summary>
    public class Application
    {
        /// <summary>The Dependency Injection container.</summary>
        public readonly IServiceProvider Services;

        /// <summary>Creates Application instance.</summary>
        /// <param name="services"></param>
        public Application(IServiceProvider services)
        {
            Services = services;
        }

        /// <summary>Executes the Application</summary>
        public void Run()
        {
            var grillMenuApi = Services.GetService<IGrillMenuApi>();
            var grillMenuPlanner = Services.GetService<IGrillMenuPlanner>();

            try
            {
                List<GrillMenuModel> result = grillMenuApi.GetAll();
                var plans = grillMenuPlanner.Plan(result);
                for (int i = 0; i < result.Count; i++)
                {
                    var menu = result[i];
                    var plan = plans.Plans[i];
                    Console.WriteLine("Grilling Menu {0}\t- Rounds {1}", menu.Menu, plan.Rounds);
                }
                Console.WriteLine("Total: {0} menus\t- Rounds {1}", result.Count, plans.Rounds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //Debug.Print("Exception when calling GrillMenuApi.GetAll: " + e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
