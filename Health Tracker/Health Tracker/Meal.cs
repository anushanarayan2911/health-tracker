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
        public string IfTuesday { get; set; }
        public string IfWednesday { get; set; }
        public string IfThursday { get; set; }
        public string IfFriday { get; set; }
        public string IfSaturday { get; set; }
        public string IfSunday { get; set; }


    }
}