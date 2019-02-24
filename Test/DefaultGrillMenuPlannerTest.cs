using isolutions.GrillAssesment.Client;
using isolutions.GrillAssesment.Client.Generic;
using isolutions.GrillAssesment.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using rebulanyum.GrillOptimizer.Business;
using RestSharp;

namespace rebulanyum.GrillOptimizer.Test
{
    [TestClass]
    public class DefaultGrillMenuPlannerTest
    {
        Mock<IGrillMenuApi> GrillMenuApiMock { get; set; }

        public DefaultGrillMenuPlannerTest()
        {
            GrillMenuApiMock = new Mock<IGrillMenuApi>();
            GrillMenuApiMock.Setup(api => api.GetAll()).Returns(new SampleData().GrillMenus);
        }

        [TestMethod]
        //[TestCategory("TestDevelopment")]
        public void SomeTestMethod()
        {
            var result = GrillMenuApiMock.Object.GetAll();
            var plans = new DefaultGrillMenuPlanner(GrillConfiguration.Default).Plan(result);
            for (int i = 0; i < result.Count; i++)
            {
                var menu = result[i];
                var plan = plans.Plans[i];
                System.Console.WriteLine("Grilling Menu {0}\t- Rounds {1}", menu.Menu, plan.Rounds);
            }
            System.Console.WriteLine("Total: {0} menus\t- Rounds {1}", result.Count, plans.Rounds);
        }
    }
}
