using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using isolutions.GrillAssesment.Client.Model;
using System.Linq;
using rebulanyum.GrillOptimizer.Business.Objects;
using System.Drawing;
using System.Globalization;

namespace rebulanyum.GrillOptimizer.Business
{
    /// <summary>This class is the implementation of GrillMenuPlannerBase.</summary>
    public class DefaultGrillMenuPlanner : GrillMenuPlannerBase
    {
        /// <summary>Constructor for DefaultGrillMenuPlanner object.</summary>
        /// <param name="grillConfig">The Grill Configuration that will be used in methods.</param>
        public DefaultGrillMenuPlanner(GrillConfiguration grillConfig) : base(grillConfig)
        {
        }

        /// <summary>Plans the given menu.</summary>
        /// <param name="menu">The menu to be planned for grilling.</param>
        /// <returns>The plan for the grilling.</returns>
        /// <remarks>This method plans the grilling of the menu.</remarks>
        public override GrillMenuGrillingPlan Plan(GrillMenuModel menu)
        {
            var plan = new GrillMenuGrillingPlan();

            var grill = new Grill(GrillConfiguration);

            // Convert given GrillMenuModel instance into Dictionary<GrillItem, int>
            var newMenu = new Dictionary<GrillItem, int>();
            foreach (var grillMenuItem in menu.Items)
            {
                if (grillMenuItem.Quantity.Value > 0)
                {
                    var duration = TimeSpan.ParseExact(grillMenuItem.Duration, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
                    var size = new Size(grillMenuItem.Width.Value, grillMenuItem.Length.Value);
                    newMenu.Add(new GrillItem(size, duration), grillMenuItem.Quantity.Value);
                }
            }
            
            while (true)
            {
                var newMenuItems = (from newMenuItem in newMenu.Keys
                                    where newMenu[newMenuItem] != 0
                                    select newMenuItem).ToArray();
                // Loop will continue if there are items to be added; otherwise, it will break
                if (!newMenuItems.Any())
                {
                    break;
                }

                TimeSpan maxTimeSpan = new TimeSpan(0,0,0);
                // Iterate on items with quantity > 0 and add them to to grill
                foreach (var grillItem in newMenuItems)
                {
                    int addedCount = grill.AddMenuItem(grillItem, newMenu[grillItem]);
                    // We may not be able to place every item since grill size is limited.
                    newMenu[grillItem] -= addedCount;
                    if (grillItem.CookingTime > maxTimeSpan)
                    {
                        maxTimeSpan = grillItem.CookingTime;
                    }
                }
                // Apply the results to the plan.
                plan.Rounds++;
                plan.ElapsedTime += (uint)maxTimeSpan.TotalSeconds;
                // Clear the grill for the new round.
                grill.Clear();
            }

            return plan;
        }
    }
}
