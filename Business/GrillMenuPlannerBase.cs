using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using isolutions.GrillAssesment.Client.Model;
using System.Linq;

namespace rebulanyum.GrillOptimizer.Business
{
    /// <summary>The default base class of Grill Menu Planner objects.</summary>
    /// <remarks>This base class provides pre-implemented methods that uses single abstract method. It will be easier to implement the IGrillMenuPlanner interface only by inheriting this class.</remarks>
    public abstract class GrillMenuPlannerBase : GrillOptimizerBusinessBase, IGrillMenuPlanner
    {
        /// <summary>Initializer for this base class.</summary>
        /// <param name="grillConfig">The Grill Configuration that will be used in methods.</param>
        protected GrillMenuPlannerBase(GrillConfiguration grillConfig) : base(grillConfig)
        {
        }

        /// <summary>Plans the given menu.</summary>
        /// <param name="menu">The menu to be planned for grilling.</param>
        /// <returns>The plan for the grilling.</returns>
        /// <remarks>This method is being used by other methods and left as abstract. In order to have the advantage of this base class, just override this method.</remarks>
        public abstract GrillMenuGrillingPlan Plan(GrillMenuModel menu);

        /// <summary>Plans the given menus.</summary>
        /// <param name="menus">The menus to be planned for grilling.</param>
        /// <returns>The plan for the grilling.</returns>
        public virtual GrillMenusGrillingPlan Plan(IEnumerable<GrillMenuModel> menus)
        {
            var bigPlan = new GrillMenusGrillingPlan();

            var menuArr = menus.ToArray();
            for (int i = 0; i < menuArr.Length; i++)
            {
                bigPlan.Plans.Add(null);
            }

#if DEBUG
            for (int index = 0; index < menuArr.Length; index++)
            {
                bigPlan.Plans[index] = Plan(menuArr[index]);
            }
#else
            Parallel.For(0, menuArr.Length, (index) => 
            {
                bigPlan.Plans[index] = Plan(menuArr[index]);
            });
#endif

            return bigPlan;
        }

        /// <summary>Plans the given menu asynchronously.</summary>
        /// <param name="menu">The menu to be planned for grilling.</param>
        /// <returns>The task that represents the plan for the grilling.</returns>
        public virtual async Task<GrillMenuGrillingPlan> PlanAsync(GrillMenuModel menu)
        {
            return Plan(menu);
        }

        /// <summary>Plans the given menus asynchronously.</summary>
        /// <param name="menus">The menus to be planned for grilling.</param>
        /// <returns>The task that represents the plans for the grilling.</returns>
        public virtual async Task<GrillMenusGrillingPlan> PlanAsync(IEnumerable<GrillMenuModel> menus)
        {
            return Plan(menus);
        }
    }
}
