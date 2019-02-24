using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using isolutions.GrillAssesment.Client.Model;

namespace rebulanyum.GrillOptimizer.Business.Objects
{
    /// <summary>Special Enumerable class for enumerating the locations on the Grill as a Grid.</summary>
    internal class GrillAreaEnumerable : IEnumerable<Point>
    {
        /// <summary>The Grill object.</summary>
        private Grill grill;
        /// <summary>The size of the item.</summary>
        private Size grillItemSize;
        /// <summary>The constructor for GrillAreaEnumerable class.</summary>
        /// <param name="grill">The Grill object.</param>
        /// <param name="grillItemSize">The Size of the item.</param>
        public GrillAreaEnumerable(Grill grill, Size grillItemSize)
        {
            this.grill = grill;
            this.grillItemSize = grillItemSize;
        }
        
        public IEnumerator<Point> GetEnumerator()
        {
            return new GrillAreaEnumerator(grill, grillItemSize);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GrillAreaEnumerator(grill, grillItemSize);
        }
    }
}
