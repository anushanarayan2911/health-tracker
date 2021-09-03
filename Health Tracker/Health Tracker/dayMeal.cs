using System;
using System.Collections.Generic;
using System.Text;

namespace Health_Tracker
{
    public class dayMeal
    {
        public string mealDetails { get; set; }
    }
    public class weekMeal : dayMeal
    {
        public string mealName { get; set; }

    }
    public class Meal : weekMeal
    {

        public string dayOfMeal { get; set; }

    }

    
}