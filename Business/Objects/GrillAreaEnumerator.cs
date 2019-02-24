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
            Rectangle newGrillItemArea = grillItemArea;

            newGrillItemArea.X += boxSize;
            if (grillArea.Contains(newGrillItemArea))
            {
                grillItemArea = newGrillItemArea;
            }
            else
            {
                newGrillItemArea.X = 0;
                newGrillItemArea.Y += boxSize;
                if (grillArea.Contains(newGrillItemArea))
                {
                    grillItemArea = newGrillItemArea;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public void Reset()
        {
            grillItemArea.Location = Point.Empty;
        }
    }
}
