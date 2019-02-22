using System;
using System.Collections.Generic;
using System.Linq;

namespace rebulanyum.GrillOptimizer.Business
{
    public class GrillMenusGrillingPlan
    {
        public IList<GrillMenuGrillingPlan> Plans { get; }

        public uint Rounds
        {
            get
            {
                return (uint)Plans.Sum(gmgp => gmgp.Rounds);
            }
        }

        public double ElapsedTime
        {
            get
            {
                return Plans.Sum(gmgp => gmgp.ElapsedTime);
            }
        }

        public GrillMenusGrillingPlan()
        {
            Plans = new List<GrillMenuGrillingPlan>();
        }
    }
}
