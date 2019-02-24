using System;
using System.Collections.Generic;
using System.Drawing;
using isolutions.GrillAssesment.Client.Model;
using rebulanyum.GrillOptimizer.Business.Objects;

namespace rebulanyum.GrillOptimizer.Business
{
    /// <summary>The Grill's configuration class.</summary>
    public class GrillConfiguration
    {
        /// <summary>The pre-defined size of the Grill.</summary>
        public Size GrillSize { get; private set; }

        /// <summary>The smallest unit for the iteration of Grill's surface.</summary>
        /// <remarks>Consider that the Grill consists of many equal squares. All squares will have it's side length with this value. And the business classes will iterate the squares when needed.</remarks>
        public int BoxSize { get; private set; }

        /// <summary>The constructor for the GrillConfiguration</summary>
        /// <param name="grillSize">The size of the Grill.</param>
        /// <param name="boxSize">The smallest unit for the iteration of Grill's surface.</param>
        public GrillConfiguration(Size grillSize, int boxSize)
        {
            GrillSize = grillSize;
            BoxSize = boxSize;
        }

        /// <summary>The default configuration instance: { GrillSize: { Width: 20, Height: 30 }, BoxSize: 1 }</summary>
        public static readonly GrillConfiguration Default = new GrillConfiguration(new Size(20, 30), 1);
    }
}
