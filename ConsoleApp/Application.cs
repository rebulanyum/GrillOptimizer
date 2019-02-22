using isolutions.GrillAssesment.Client;
using isolutions.GrillAssesment.Client.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace rebulanyum.GrillOptimizer.ConsoleApp
{
    public class Application
    {
        public readonly IServiceProvider Services;
        public Application(IServiceProvider services)
        {
            Services = services;
        }

        public void Run(string[] args)
        {
            var grillMenuApi = Services.GetService<IGrillMenuApi>();

            try
            {
                List<GrillMenuModel> result = grillMenuApi.GetAll();
                //TODO
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //Debug.Print("Exception when calling GrillMenuApi.GetAll: " + e.Message);
            }
        }
    }
}
