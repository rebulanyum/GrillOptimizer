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
        }
    }
}
