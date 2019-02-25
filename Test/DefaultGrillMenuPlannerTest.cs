using isolutions.GrillAssesment.Client;
using isolutions.GrillAssesment.Client.Generic;
using isolutions.GrillAssesment.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using rebulanyum.GrillOptimizer.Business;
using rebulanyum.GrillOptimizer.Business.Objects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void Requires2RoundsWhenGrillIsFilledOnFirstRound()
        {
            var result = (from menu in GrillMenuApiMock.Object.GetAll()
                          where menu.Id.GetValueOrDefault() == System.Guid.Parse("99a08d4b-8e20-4811-beee-1b56ac545f90")
                          select menu).SingleOrDefault();
            var planner = new DefaultGrillMenuPlanner(GrillConfiguration.Default);
            GrillMenuGrillingPlan plan = planner.Plan(result);
            Assert.AreEqual(plan.Rounds, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        //[TestCategory("TestDevelopment")]
        public void ThrowsExceptionWhenMenuItemIsOversized()
        {
            var config = GrillConfiguration.Default;

            var menu = new GrillMenuModel()
            {
                Items = new List<GrillMenuItemModel>()
                {
                new GrillMenuItemModel() { Id = Guid.NewGuid(), Width = config.GrillSize.Width + 1, Length = config.GrillSize.Height + 1, Name = "Oversized Menu 1", Quantity = 1 }
                }
            };

            var planner = new DefaultGrillMenuPlanner(config);

            GrillMenuGrillingPlan plan = planner.Plan(menu);
        }
    }
}
