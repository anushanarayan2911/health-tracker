using System;
using System.Collections.Generic;
using System.Text;

namespace Health_Tracker
{
    public class Meal
    {
        public string mealName { get; set; }
        public string mealDetails { get; set; }

        public string dayOfMeal { get; set; }

    }

    public class weekMeal
    {
        public string IfMonday { get; set; }
        public List<Meal> IfTuesday { get; set; }
        public List<Meal> IfWednesday { get; set; }
        public List<Meal> IfThursday { get; set; }
        public List<Meal> IfFriday { get; set; }
        public List<Meal> IfSaturday { get; set; }
        public List<Meal> IfSunday { get; set; }

    }
}