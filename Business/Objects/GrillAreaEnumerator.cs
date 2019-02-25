using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using isolutions.GrillAssesment.Client.Model;

namespace rebulanyum.GrillOptimizer.Business.Objects
{
    /// <summary>The enumerator class of the Grill's locations.</summary>
    internal class GrillAreaEnumerator : IEnumerator<Point>
    {
        private Rectangle grillArea, grillItemArea;
        private int boxSize;
        public GrillAreaEnumerator(Grill grill, Size grillItemSize)
        {
            this.grillArea = new Rectangle(Point.Empty, grill.Size);
            this.grillItemArea = new Rectangle(Point.Empty, grillItemSize);
            this.boxSize = grill.BoxSize;

            if (!this.grillArea.Contains(grillItemArea))
            {
                throw new ArgumentOutOfRangeException(nameof(grillItemSize), "The Grill cannot contain this Grill Item because Grill Item is oversized inside the Grill.");
            }
            this.grillItemArea.Offset(-this.boxSize, 0);
        }
        public Point Current => grillItemArea.Location;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            // Get the current area
            Rectangle newGrillItemArea = grillItemArea;
            // Increase the current area's location on X-Axis
            newGrillItemArea.X += boxSize;
            // If the new area doesn't overflow on the grill.
            if (grillArea.Contains(newGrillItemArea))
            {
                grillItemArea = newGrillItemArea;
            }
            else
            {
                newGrillItemArea.X = 0; // Move the X-Axis to the beginning
                newGrillItemArea.Y += boxSize; // Increase the current area's location on Y-Axis
                // If the new area doesn't overflow on the grill.
                if (grillArea.Contains(newGrillItemArea))
                {
                    grillItemArea = newGrillItemArea;
                }
                else
                {   // The grill's locations are ended: no where to place the item.
                    return false; 
                }
            }
            // The item can be placed into current location.
            return true;
        }

        public void Reset()
        {
            this.grillItemArea.Location = Point.Empty;
            this.grillItemArea.Offset(-this.boxSize, 0);
        }
    }
}
