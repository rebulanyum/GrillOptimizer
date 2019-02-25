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
            Dictionary<GrillItem, int> newMenu = ValidateAndCreateMenu(menu);

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

                TimeSpan maxTimeSpan = new TimeSpan(0, 0, 0);
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

        private Dictionary<GrillItem, int> ValidateAndCreateMenu(GrillMenuModel menu)
        {
            var newMenu = new Dictionary<GrillItem, int>();
            foreach (var grillMenuItem in menu.Items ?? new List<GrillMenuItemModel>())
            {
                int quantity = grillMenuItem.Quantity.GetValueOrDefault(0);
                if (quantity <= 0)
                    continue;

                int width = grillMenuItem.Width.GetValueOrDefault(0);
                if (width <= 0)
                    throw new BusinessException("The Width of the GrillMenuItemModel with the id {0} is not set.", grillMenuItem.Id.Value);
                int length = grillMenuItem.Length.GetValueOrDefault(0); ;
                if (length <= 0)
                    throw new BusinessException("The Length of the GrillMenuItemModel with the id {0} is not set.", grillMenuItem.Id.Value);

                if (width > GrillConfiguration.GrillSize.Width || length > GrillConfiguration.GrillSize.Height)
                    throw new BusinessException("The Size of the GrillMenuItemModel exceeds the Grill.", grillMenuItem.Id.Value);

                TimeSpan duration;
                TimeSpan.TryParseExact(grillMenuItem.Duration, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out duration);
                var size = new Size(width, length);
                newMenu.Add(new GrillItem(size, duration), quantity);
            }

            return newMenu;
        }
    }
}
