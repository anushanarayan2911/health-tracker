using System;
using System.Collections.Generic;
using System.Text;

namespace Health_Tracker
{
    public class weekMeal
    {
        public string mealName { get; set; }

        public string mealDetails { get; set; }
    }
    public class Meal : weekMeal
    {

        public string dayOfMeal { get; set; }

    }

    
}