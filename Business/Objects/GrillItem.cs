using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using isolutions.GrillAssesment.Client.Model;

namespace rebulanyum.GrillOptimizer.Business.Objects
{
    /// <summary>The GrillItem class represent the item on a Grill.</summary>
    internal class GrillItem
    {
        /// <summary>The size of the item.</summary>
        public Size Size { get; private set; }
        /// <summary>The time needed to cook the item.</summary>
        public TimeSpan CookingTime { get; private set; }
        /// <summary>The constructor for GrillItem class.</summary>
        /// <param name="size">The size of the item.</param>
        /// <param name="cookingTime">The time needed to cook the item.</param>
        public GrillItem(Size size, TimeSpan cookingTime)
        {
            Size = size;
            CookingTime = cookingTime;
        }
    }
}
