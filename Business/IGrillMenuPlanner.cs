using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using isolutions.GrillAssesment.Client.Model;

namespace rebulanyum.GrillOptimizer.Business
{
    public interface IGrillMenuPlanner
    {
        GrillMenuGrillingPlan Plan(GrillMenuModel menu);

        GrillMenusGrillingPlan Plan(IEnumerable<GrillMenuModel> menus);

        Task<GrillMenuGrillingPlan> PlanAsync(GrillMenuModel menu);

        Task<GrillMenusGrillingPlan> PlanAsync(IEnumerable<GrillMenuModel> menus);
    }
    
}
