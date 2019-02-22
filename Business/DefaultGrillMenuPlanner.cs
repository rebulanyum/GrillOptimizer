using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using isolutions.GrillAssesment.Client.Model;
using System.Linq;

namespace rebulanyum.GrillOptimizer.Business
{
    public class DefaultGrillMenuPlanner : GrillMenuPlannerBase
    {
        public DefaultGrillMenuPlanner(GrillConfiguration grill) : base(grill)
        {
        }

        public override GrillMenuGrillingPlan Plan(GrillMenuModel menu)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
