using System;
using System.Collections.Generic;
using isolutions.GrillAssesment.Client.Model;

namespace rebulanyum.GrillOptimizer.Business
{
    /// <summary>This class represents the plan generated for grilling the menu.</summary>
    public class GrillMenuGrillingPlan
    {
        /// <summary>Rounds to be needed for grilling the whole menu on the Grill.</summary>
        public ushort Rounds { get; set; }

        /// <summary>The total time (in seconds) passed for Grilling the whole menu.</summary>
        public uint ElapsedTime { get; set; }
    }
}
