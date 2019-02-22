using isolutions.GrillAssesment.Client.Generic;
using isolutions.GrillAssesment.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rebulanyum.GrillOptimizer.Test.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace rebulanyum.GrillOptimizer.Test
{
    internal class SampleData
    {
        static readonly Lazy<List<GrillMenuModel>> _GrillMenus;

        private const string grillMenusManifestResourceName = "GrillMenus";
        public List<GrillMenuModel> GrillMenus { get => _GrillMenus.Value; }
        
        static SampleData()
        {
            _GrillMenus = new Lazy<List<GrillMenuModel>>(() =>
            {
                List<GrillMenuModel> result;

                byte[] data = (byte[])Resources.ResourceManager.GetObject(grillMenusManifestResourceName);
                using (var stream = new MemoryStream(data))
                using (var reader = new StreamReader(stream))
                {
                    var jsonData = reader.ReadToEnd();
                    result = (List<GrillMenuModel>)new isolutions.GrillAssesment.Client.Generic.ApiClient().Deserialize(jsonData, typeof(List<GrillMenuModel>));
                }

                return result;
            });
        }
    }

    [TestClass]
    public class SampleDataTest
    {
        [TestMethod]
        //[TestCategory("TestDevelopment")]
        public void SampleDataCanLoadGrillMenusSuccessfully()
        {
            var sampleData = new SampleData();
            var value = sampleData.GrillMenus;
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Count > 0, "GrillMenus list is empty");
        }
    }
}
