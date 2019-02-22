using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using isolutions.GrillAssesment.Client.Model;
using System.Linq;

namespace rebulanyum.GrillOptimizer.Business
{
    public abstract class GrillOptimizerBusinessBase
    {
        public GrillConfiguration Grill { get; private set; }

        protected GrillOptimizerBusinessBase(GrillConfiguration grill)
        {
            Grill = grill;
        }
    }
}
