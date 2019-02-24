using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using isolutions.GrillAssesment.Client.Model;

namespace rebulanyum.GrillOptimizer.Business.Objects
{
    /// <summary>The class that represents the placed item on the Grill surface.</summary>
    internal class PlacedGrillItem : GrillItem
    {
        /// <summary>The location of the item on Grill.</summary>
        public Point Location { get; private set; }
        /// <summary>The area of the item on Grill.</summary>
        public Rectangle Area { get; private set; }
        /// <summary>The constructor for PlacedGrillItem class.</summary>
        /// <param name="size">The size of the item.</param>
        /// <param name="cookingTime">The time needed to cook the item.</param>
        /// <param name="location">The location of the item on Grill.</param>
        public PlacedGrillItem(Size size, TimeSpan cookingTime, Point location) : base(size, cookingTime)
        {
            Location = location;
            Area = new Rectangle(Location, Size);
        }
        /// <summary>Creates the object from existing <paramref name="grillItem"/> object.</summary>
        /// <param name="grillItem">The item that will be placed on Grill.</param>
        /// <param name="location">The new location of <paramref name="grillItem"/> on Grill.</param>
        /// <returns>The created object.</returns>
        public static PlacedGrillItem FromGrillItem(GrillItem grillItem, Point location)
        {
            return new PlacedGrillItem(grillItem.Size, grillItem.CookingTime, location);
        }
    }
}
