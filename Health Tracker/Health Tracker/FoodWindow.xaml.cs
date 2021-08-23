using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Health_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FoodWindow : Window
    {
        string[] mealNameArray = new String[30];
        string[] mealDayArray = new String[30];
        ObservableCollection<Meal> addedMealsView = new ObservableCollection<Meal>();
        ObservableCollection<weekMeal> weekMealsView = new ObservableCollection<weekMeal>();
        List<Meal> OrderedList;
        public FoodWindow()
        {
            InitializeComponent();
            AddedMeals.ItemsSource = addedMealsView;
            WeekMeals.ItemsSource = weekMealsView;
        }

        public void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        private void AddMealClick(object sender, RoutedEventArgs e)
        {
            AddMealButton.Visibility = Visibility.Hidden;
            WeekMeals.Visibility = Visibility.Hidden;
            hi.Visibility = Visibility.Hidden;
            ViewMealsButton.Visibility = Visibility.Visible;
            ViewMealsButton.Margin = new Thickness(-95, -40, 0, 0); 

            ChooseDay.Visibility = Visibility.Visible;
            MondayBox.Visibility = Visibility.Visible;
            TuesdayBox.Visibility = Visibility.Visible;
            WednesdayBox.Visibility = Visibility.Visible;
            ThursdayBox.Visibility = Visibility.Visible;
            FridayBox.Visibility = Visibility.Visible;
            SaturdayBox.Visibility = Visibility.Visible;
            SundayBox.Visibility = Visibility.Visible;

            ChooseMeal.Visibility = Visibility.Visible;
            BreakfastBox.Visibility = Visibility.Visible;
            LunchBox.Visibility = Visibility.Visible;
            DinnerBox.Visibility = Visibility.Visible;

            MealDetailsLabel.Visibility = Visibility.Visible;
            MealDetailsInput.Visibility = Visibility.Visible;

            OKButton.Visibility = Visibility.Visible;
            Result.Visibility = Visibility.Visible;
            AddedMeals.Visibility = Visibility.Visible;
        }

        private void SendDayName(object sender, RoutedEventArgs e)
        {
            string day = (string)((CheckBox)sender).Content;
            int index = Array.IndexOf(mealDayArray, null);
            mealDayArray[index] = day;
        }

        public void SendMealName(object sender, RoutedEventArgs e)
        {
            string name = (string)((CheckBox)sender).Content;
            int index = Array.IndexOf(mealNameArray, null);
            mealNameArray[index] = name;
        }

        public void SendMealInfo(object sender, RoutedEventArgs e)
        {
            int nameIndex = Array.IndexOf(mealNameArray, null) - 1;
            if (nameIndex < 0)
            {
                nameIndex = 0;
            }

            int dayIndex = Array.IndexOf(mealDayArray, null) - 1;
            if (dayIndex < 0)
            {
                dayIndex = 0;
            }

            string name = mealNameArray[nameIndex];
            string day = mealDayArray[dayIndex];
            string mealDetails = (string)MealDetailsInput.Text;

            addedMealsView.Add(new Meal() { mealName = name, mealDetails = mealDetails, dayOfMeal = day});
            
            AddedMeals.Items.Refresh();
        }

        private void ViewMealsClick(object sender, RoutedEventArgs e)
        {
            WeekMeals.Visibility = Visibility.Visible;
            hi.Visibility = Visibility.Visible;
            AddMealButton.Visibility = Visibility.Visible;
            AddMealButton.Margin = new Thickness(-90, -10, 0, 0);
            ViewMealsButton.Visibility = Visibility.Hidden;

            ChooseDay.Visibility = Visibility.Hidden;
            MondayBox.Visibility = Visibility.Hidden;
            TuesdayBox.Visibility = Visibility.Hidden;
            WednesdayBox.Visibility = Visibility.Hidden;
            ThursdayBox.Visibility = Visibility.Hidden;
            FridayBox.Visibility = Visibility.Hidden;
            SaturdayBox.Visibility = Visibility.Hidden;
            SundayBox.Visibility = Visibility.Hidden;

            ChooseMeal.Visibility = Visibility.Hidden;
            BreakfastBox.Visibility = Visibility.Hidden;
            LunchBox.Visibility = Visibility.Hidden;
            DinnerBox.Visibility = Visibility.Hidden;

            MealDetailsLabel.Visibility = Visibility.Hidden;
            MealDetailsInput.Visibility = Visibility.Hidden;

            OKButton.Visibility = Visibility.Hidden;
            Result.Visibility = Visibility.Hidden;
            AddedMeals.Visibility = Visibility.Hidden;

            OrderedList = addedMealsView.OrderBy(x => x.dayOfMeal).ToList();

            List<string> MondayList = new List<string>();
            List<Meal> TuesdayList = new List<Meal>();
            List<Meal> WednesdayList = new List<Meal>();
            List<Meal> ThursdayList = new List<Meal>();
            List<Meal> FridayList = new List<Meal>();
            List<Meal> SaturdayList = new List<Meal>();
            List<Meal> SundayList = new List<Meal>();
            
            foreach (Meal m in OrderedList)
            {
                switch(m.dayOfMeal)
                {
                    case "Monday":

                        string[] existingMondayMeals = new string[30];
                        //MondayList.Add(m.mealDetails);
                        foreach (weekMeal w in weekMealsView)
                        {
                            existingMondayMeals[Array.IndexOf(existingMondayMeals, null)] = w.IfMonday;
                        }
                        
                        if (!existingMondayMeals.Contains(m.mealDetails))
                        {
                            weekMealsView.Add(new weekMeal { IfMonday = m.mealDetails });
                        }
                        break;

                    case "Tuesday":

                        string[] existingTuesdayMeals = new string[30];
                        foreach (weekMeal w in weekMealsView)
                        {
                            existingTuesdayMeals[Array.IndexOf(existingTuesdayMeals, null)] = w.IfTuesday;
                        }

                        if (!existingTuesdayMeals.Contains(m.mealDetails))
                        {
                            weekMealsView.Add(new weekMeal { IfTuesday = m.mealDetails });
                        }
                        break;

                    case "Wednesday":

                        string[] existingWednesdayMeals = new string[30];
                        foreach (weekMeal w in weekMealsView)
                        {
                            existingWednesdayMeals[Array.IndexOf(existingWednesdayMeals, null)] = w.IfWednesday;
                        }

                        if (!existingWednesdayMeals.Contains(m.mealDetails))
                        {
                            weekMealsView.Add(new weekMeal { IfWednesday = m.mealDetails });
                        }
                        break;

                    case "Thursday":

                        string[] existingThursdayMeals = new string[30];
                        foreach (weekMeal w in weekMealsView)
                        {
                            existingThursdayMeals[Array.IndexOf(existingThursdayMeals, null)] = w.IfThursday;
                        }

                        if (!existingThursdayMeals.Contains(m.mealDetails))
                        {
                            weekMealsView.Add(new weekMeal { IfThursday = m.mealDetails });
                        }
                        break;

                    case "Friday":

                        string[] existingFridayMeals = new string[30];
                        foreach (weekMeal w in weekMealsView)
                        {
                            existingFridayMeals[Array.IndexOf(existingFridayMeals, null)] = w.IfFriday;
                        }

                        if (!existingFridayMeals.Contains(m.mealDetails))
                        {
                            weekMealsView.Add(new weekMeal { IfFriday = m.mealDetails });
                        }
                        break;

                    case "Saturday":

                        string[] existingSaturdayMeals = new string[30];
                        foreach (weekMeal w in weekMealsView)
                        {
                            existingSaturdayMeals[Array.IndexOf(existingSaturdayMeals, null)] = w.IfSaturday;
                        }

                        if (!existingSaturdayMeals.Contains(m.mealDetails))
                        {
                            weekMealsView.Add(new weekMeal { IfSaturday = m.mealDetails });
                        }
                        break;

                    case "Sunday":

                        string[] existingSundayMeals = new string[30];
                        foreach (weekMeal w in weekMealsView)
                        {
                            existingSundayMeals[Array.IndexOf(existingSundayMeals, null)] = w.IfSunday;
                        }

                        if (!existingSundayMeals.Contains(m.mealDetails))
                        {
                            weekMealsView.Add(new weekMeal { IfSunday = m.mealDetails });
                        }
                        break;
                }
            }

            WeekMeals.Items.Refresh();
            
        }

        
    };
}