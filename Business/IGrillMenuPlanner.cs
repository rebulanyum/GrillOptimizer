using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using isolutions.GrillAssesment.Client.Model;

namespace rebulanyum.GrillOptimizer.Business
{
    /// <summary>This interface defines the business methods for planning the Grilling for menus.</summary>
    public interface IGrillMenuPlanner
    {
        /// <summary>Plans the given menu.</summary>
        /// <param name="menu">The menu to be planned for grilling.</param>
        /// <returns>The plan for the grilling.</returns>
        GrillMenuGrillingPlan Plan(GrillMenuModel menu);
        /// <summary>Plans the given menus.</summary>
        /// <param name="menus">The menus to be planned for grilling.</param>
        /// <returns>The plan for the grilling.</returns>
        GrillMenusGrillingPlan Plan(IEnumerable<GrillMenuModel> menus);
        /// <summary>Plans the given menu asynchronously.</summary>
        /// <param name="menu">The menu to be planned for grilling.</param>
        /// <returns>The task that represents the plan for the grilling.</returns>
        Task<GrillMenuGrillingPlan> PlanAsync(GrillMenuModel menu);
        /// <summary>Plans the given menus asynchronously.</summary>
        /// <param name="menus">The menus to be planned for grilling.</param>
        /// <returns>The task that represents the plans for the grilling.</returns>
        Task<GrillMenusGrillingPlan> PlanAsync(IEnumerable<GrillMenuModel> menus);
    }
    
}
