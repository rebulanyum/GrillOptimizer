using System;
using System.Collections.Generic;
using System.Drawing;
using isolutions.GrillAssesment.Client.Model;

namespace rebulanyum.GrillOptimizer.Business
{
    public class GrillConfiguration
    {
        public SizeF GrillSize { get; set; }

        public static readonly GrillConfiguration Default = new GrillConfiguration() { GrillSize = new SizeF(20, 30) };
    }
}
