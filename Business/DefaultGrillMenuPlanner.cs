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
                if (!newMenuItems.Any())
                {
                    break;
                }

                TimeSpan maxTimeSpan = new TimeSpan(0,0,0);
                foreach (var grillItem in newMenuItems)
                {
                    int addedCount = grill.AddMenuItem(grillItem, newMenu[grillItem]);

                    newMenu[grillItem] -= addedCount;
                    if (grillItem.CookingTime > maxTimeSpan)
                    {
                        maxTimeSpan = grillItem.CookingTime;
                    }
                }
                plan.Rounds++;
                plan.ElapsedTime += (uint)maxTimeSpan.TotalSeconds;

                grill.Clear();
            }

            return plan;
        }
    }
}
