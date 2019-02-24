using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using isolutions.GrillAssesment.Client.Model;
using System.Linq;
using rebulanyum.GrillOptimizer.Business.Objects;

namespace rebulanyum.GrillOptimizer.Business
{
    /// <summary>Default base class for business classes related with Grill operations.</summary>
    public abstract class GrillOptimizerBusinessBase
    {
        /// <summary>The Grill Configuration object.</summary>
        public GrillConfiguration GrillConfiguration { get; private set; }

        /// <summary>Initializer for this base class.</summary>
        /// <param name="grillConfig">The Grill Configuration that will be used in methods.</param>
        protected GrillOptimizerBusinessBase(GrillConfiguration grillConfig)
        {
            GrillConfiguration = grillConfig;
        }
    }
}
