using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using isolutions.GrillAssesment.Client.Model;

namespace rebulanyum.GrillOptimizer.Business.Objects
{
    /// <summary>This class is for managing Grill operations.</summary>
    internal class Grill 
    {
        /// <summary>Size of the Grill surface.</summary>
        public readonly Size Size;
        /// <summary>Size of the smallest unit.</summary>
        public readonly int BoxSize;
        
        /// <summary>The items that are placed on the Grill.</summary>
        private List<PlacedGrillItem> Items { get; set; }

        /// <summary>The constructor for Grill object.</summary>
        /// <param name="config">The configuration for the Grill object.</param>
        public Grill(GrillConfiguration config)
        {
            Size = config.GrillSize;
            BoxSize = config.BoxSize;

            Items = new List<PlacedGrillItem>();
        }

        /// <summary>Tries to add the <paramref name="grillItem"/> for the specified <paramref name="quantity"/> times.</summary>
        /// <param name="grillItem">The item to be grilled.</param>
        /// <param name="quantity">The amount of items to be placed on grill.</param>
        /// <returns>The amount of added items.</returns>
        public int AddMenuItem(GrillItem grillItem, int quantity)
        {
            int grillItemIndex;
            for (grillItemIndex = 0; grillItemIndex < quantity; grillItemIndex++)
            {
                PlacedGrillItem placedGrillItem = AddGrillItem(grillItem);

                if (placedGrillItem == null)
                {
                    break;
                }
            }
            return grillItemIndex;
        }

        /// <summary>Tries to add single <paramref name="grillItem"/>.</summary>
        /// <param name="grillItem">The item to be grilled.</param>
        /// <returns>The placed item.</returns>
        private PlacedGrillItem AddGrillItem(GrillItem grillItem)
        {
            var grillItemArea = new Rectangle(Point.Empty, grillItem.Size);
            var grillItemLocations = new GrillAreaEnumerable(this, grillItem.Size);
            PlacedGrillItem placedItem = null;
            foreach (Point grillItemLocation in grillItemLocations)
            {
                grillItemArea.Location = grillItemLocation;
                bool hasAnyIntersectionWithExistingItems = AreaIntersectsWithAnyItem(grillItemArea);
                if (!hasAnyIntersectionWithExistingItems)
                {
                    placedItem = PlacedGrillItem.FromGrillItem(grillItem, grillItemLocation);
                    Items.Add(placedItem);
                    break;
                }
            }

            return placedItem;
        }

        /// <summary>Checks wether the given <paramref name="area"/> intersects with any of the placed grill items.</summary>
        /// <param name="area">The area for checking the availibility.</param>
        /// <returns>The availibility of the given <paramref name="area"/>.</returns>
        private bool AreaIntersectsWithAnyItem(Rectangle area)
        {
            bool isIntersecting = (from pgi in this.Items
                                   where pgi.Area.IntersectsWith(area)
                                   select pgi).Any();
            return isIntersecting;
        }

        /// <summary>Clears the items on the Grill by removing all.</summary>
        public void Clear()
        {
            Items.Clear();
        }
    }
}
