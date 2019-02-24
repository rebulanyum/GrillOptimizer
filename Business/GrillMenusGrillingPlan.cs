using System;
using System.Collections.Generic;
using System.Linq;

namespace rebulanyum.GrillOptimizer.Business
{
    /// <summary>This class represents the plan generated for grilling multiple menus.</summary>
    public class GrillMenusGrillingPlan
    {
        /// <summary>Generated plans for grilling the menus.</summary>
        public IList<GrillMenuGrillingPlan> Plans { get; }

        /// <summary>Rounds to be needed for grilling the whole menu on the Grill.</summary>
        public uint Rounds
        {
            get
            {
                return (uint)Plans.Sum(gmgp => gmgp.Rounds);
            }
        }

        /// <summary>The total time (in seconds) passed for Grilling the whole menu.</summary>
        public ulong ElapsedTime
        {
            get
            {
                return (ulong)Plans.Sum(gmgp => gmgp.ElapsedTime);
            }
        }

        /// <summary>Constructor for GrillMenusGrillingPlan objects.</summary>
        public GrillMenusGrillingPlan()
        {
            Plans = new List<GrillMenuGrillingPlan>();
        }
    }
}
