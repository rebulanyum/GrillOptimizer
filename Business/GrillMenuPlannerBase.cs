using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using isolutions.GrillAssesment.Client.Model;
using System.Linq;

namespace rebulanyum.GrillOptimizer.Business
{
    public abstract class GrillMenuPlannerBase : GrillOptimizerBusinessBase, IGrillMenuPlanner
    {
        public GrillMenuPlannerBase(GrillConfiguration grill) : base(grill)
        {
        }
        public abstract GrillMenuGrillingPlan Plan(GrillMenuModel menu);

        public virtual GrillMenusGrillingPlan Plan(IEnumerable<GrillMenuModel> menus)
        {
            var bigPlan = new GrillMenusGrillingPlan();

            var menuArr = menus.ToArray();
            for (int i = 0; i < menuArr.Length; i++)
            {
                bigPlan.Plans.Add(null);
            }

            Parallel.For(0, menuArr.Length, (index) =>
            {
                bigPlan.Plans[index] = Plan(menuArr[index]);
            });

            return bigPlan;
        }

        public virtual async Task<GrillMenuGrillingPlan> PlanAsync(GrillMenuModel menu)
        {
            return Plan(menu);
        }

        public virtual async Task<GrillMenusGrillingPlan> PlanAsync(IEnumerable<GrillMenuModel> menus)
        {
            return Plan(menus);
        }
    }
}
