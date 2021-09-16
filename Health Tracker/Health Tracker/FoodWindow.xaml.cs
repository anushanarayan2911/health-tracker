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

        List<Meal> OrderedList;

        ObservableCollection<weekMeal> MondayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> TuesdayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> WednesdayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> ThursdayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> FridayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> SaturdayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> SundayMealsView = new ObservableCollection<weekMeal>();

        public FoodWindow()
        {
            InitializeComponent();
            AddedMeals.ItemsSource = CommonElements.AddedMealsView;
            MondayCol.ItemsSource = MondayMealsView;
            TuesdayCol.ItemsSource = TuesdayMealsView;
            WednesdayCol.ItemsSource = WednesdayMealsView;
            ThursdayCol.ItemsSource = ThursdayMealsView;
            FridayCol.ItemsSource = FridayMealsView;
            SaturdayCol.ItemsSource = SaturdayMealsView;
            SundayCol.ItemsSource = SundayMealsView;
        }

        public void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        private void AddMealClick(object sender, RoutedEventArgs e)
        {
            AddMealButton.Visibility = Visibility.Hidden;
            AddMealLabel.Visibility = Visibility.Hidden;

            MondayCol.Visibility = Visibility.Hidden;
            TuesdayCol.Visibility = Visibility.Hidden;
            WednesdayCol.Visibility = Visibility.Hidden;
            ThursdayCol.Visibility = Visibility.Hidden;
            FridayCol.Visibility = Visibility.Hidden;
            SaturdayCol.Visibility = Visibility.Hidden;
            SundayCol.Visibility = Visibility.Hidden;

            Canvas.SetTop(ViewMealsButton, 20);
            Canvas.SetLeft(ViewMealsButton, 95);
            Canvas.SetTop(ViewMealsLabel, 40);
            Canvas.SetLeft(ViewMealsLabel, 80);

            AddMealsTitle.Visibility = Visibility.Visible;

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
            SnackBox.Visibility = Visibility.Visible;

            MealDetailsLabel.Visibility = Visibility.Visible;
            MealDetailsInput.Visibility = Visibility.Visible;

            OKButton.Visibility = Visibility.Visible;
            AddedMeals.Visibility = Visibility.Visible;
        }

        private void SendDayName(object sender, RoutedEventArgs e)
        {
            string day = (string)((RadioButton)sender).Content;
            int index = Array.IndexOf(mealDayArray, null);
            mealDayArray[index] = day;
        }

        public void SendMealName(object sender, RoutedEventArgs e)
        {
            string name = (string)((RadioButton)sender).Content;
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

            CommonElements.AddedMealsView.Add(new Meal() { mealName = name, mealDetails = mealDetails, dayOfMeal = day});
            
            AddedMeals.Items.Refresh();
        }

        private void ViewMealsClick(object sender, RoutedEventArgs e)
        {
            MondayCol.Visibility = Visibility.Visible;
            TuesdayCol.Visibility = Visibility.Visible;
            WednesdayCol.Visibility = Visibility.Visible;
            ThursdayCol.Visibility = Visibility.Visible;
            FridayCol.Visibility = Visibility.Visible;
            SaturdayCol.Visibility = Visibility.Visible;
            SundayCol.Visibility = Visibility.Visible;

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

            AddedMeals.Visibility = Visibility.Hidden;

            OrderedList = CommonElements.AddedMealsView.OrderBy(x => x.dayOfMeal).ToList();
            
            foreach (Meal m in OrderedList)
            {
                switch(m.dayOfMeal)
                {
                    case "Monday":
                        
                        string[] existingMondayMeals = new string[30];
                        foreach (weekMeal w in MondayMealsView)
                        {
                            existingMondayMeals[Array.IndexOf(existingMondayMeals, null)] = w.mealDetails;
                        }
                        
                        if (!existingMondayMeals.Contains(m.mealDetails))
                        {
                            MondayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;
                    
                    case "Tuesday":

                        string[] existingTuesdayMeals = new string[30];
                        foreach (weekMeal w in TuesdayMealsView)
                        {
                            existingTuesdayMeals[Array.IndexOf(existingTuesdayMeals, null)] = w.mealDetails;
                        }

                        if (!existingTuesdayMeals.Contains(m.mealDetails))
                        {
                            TuesdayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;

                    case "Wednesday":

                        string[] existingWednesdayMeals = new string[30];
                        foreach (weekMeal w in WednesdayMealsView)
                        {
                            existingWednesdayMeals[Array.IndexOf(existingWednesdayMeals, null)] = w.mealDetails;
                        }

                        if (!existingWednesdayMeals.Contains(m.mealDetails))
                        {
                            WednesdayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;

                    case "Thursday":

                        string[] existingThursdayMeals = new string[30];
                        foreach (weekMeal w in ThursdayMealsView)
                        {
                            existingThursdayMeals[Array.IndexOf(existingThursdayMeals, null)] = w.mealDetails;
                        }

                        if (!existingThursdayMeals.Contains(m.mealDetails))
                        {
                            ThursdayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;

                    case "Friday":

                        string[] existingFridayMeals = new string[30];
                        foreach (weekMeal w in FridayMealsView)
                        {
                            existingFridayMeals[Array.IndexOf(existingFridayMeals, null)] = w.mealDetails;
                        }

                        if (!existingFridayMeals.Contains(m.mealDetails))
                        {
                            FridayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;

                    case "Saturday":

                        string[] existingSaturdayMeals = new string[30];
                        foreach (weekMeal w in SaturdayMealsView)
                        {
                            existingSaturdayMeals[Array.IndexOf(existingSaturdayMeals, null)] = w.mealDetails;
                        }

                        if (!existingSaturdayMeals.Contains(m.mealDetails))
                        {
                            SaturdayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;

                    case "Sunday":

                        string[] existingSundayMeals = new string[30];
                        foreach (weekMeal w in SundayMealsView)
                        {
                            existingSundayMeals[Array.IndexOf(existingSundayMeals, null)] = w.mealDetails;
                        }

                        if (!existingSundayMeals.Contains(m.mealDetails))
                        {
                            SundayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;
                }
            }

            MondayCol.Items.Refresh();
            TuesdayCol.Items.Refresh();
            WednesdayCol.Items.Refresh();
            ThursdayCol.Items.Refresh();
            FridayCol.Items.Refresh();
            SaturdayCol.Items.Refresh();
            SundayCol.Items.Refresh();
        }

        
    };
}