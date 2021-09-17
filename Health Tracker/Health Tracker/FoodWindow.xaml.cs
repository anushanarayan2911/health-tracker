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
        #region StartVariables
        string[] MealNameArray = new String[30];
        string[] MealDayArray = new String[30];

        List<Meal> OrderedList;

        ObservableCollection<weekMeal> MondayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> TuesdayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> WednesdayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> ThursdayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> FridayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> SaturdayMealsView = new ObservableCollection<weekMeal>();
        ObservableCollection<weekMeal> SundayMealsView = new ObservableCollection<weekMeal>();
        #endregion

        public FoodWindow()
        {
            InitializeComponent();

            #region SetItemsSource
            AddedMeals.ItemsSource = CommonElements.AddedMealsView;
            MondayCol.ItemsSource = MondayMealsView;
            TuesdayCol.ItemsSource = TuesdayMealsView;
            WednesdayCol.ItemsSource = WednesdayMealsView;
            ThursdayCol.ItemsSource = ThursdayMealsView;
            FridayCol.ItemsSource = FridayMealsView;
            SaturdayCol.ItemsSource = SaturdayMealsView;
            SundayCol.ItemsSource = SundayMealsView;
            #endregion

        }

        public void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        private void AddMealClick(object sender, RoutedEventArgs e)
        {
            #region HideElements
            AddMealButton.Visibility = Visibility.Hidden;
            AddMealLabel.Visibility = Visibility.Hidden;

            ViewMealsTitle.Visibility = Visibility.Hidden;
            MondayCol.Visibility = Visibility.Hidden;
            TuesdayCol.Visibility = Visibility.Hidden;
            WednesdayCol.Visibility = Visibility.Hidden;
            ThursdayCol.Visibility = Visibility.Hidden;
            FridayCol.Visibility = Visibility.Hidden;
            SaturdayCol.Visibility = Visibility.Hidden;
            SundayCol.Visibility = Visibility.Hidden;
            #endregion

            #region ShowElements
            ViewMealsButton.Visibility = Visibility.Visible;
            ViewMealsLabel.Visibility = Visibility.Visible;
            Canvas.SetTop(ViewMealsButton, 0);
            Canvas.SetLeft(ViewMealsButton, 95);
            Canvas.SetTop(ViewMealsLabel, 30);
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
            #endregion
        }

        private void SendDayName(object sender, RoutedEventArgs e)
        {
            string Day = (string)((RadioButton)sender).Content;
            int Index = Array.IndexOf(MealDayArray, null);
            MealDayArray[Index] = Day;
        }

        public void SendMealName(object sender, RoutedEventArgs e)
        {
            string Name = (string)((RadioButton)sender).Content;
            int Index = Array.IndexOf(MealNameArray, null);
            MealNameArray[Index] = Name;
        }

        public void SendMealInfo(object sender, RoutedEventArgs e)
        {
            int NameIndex = Array.IndexOf(MealNameArray, null) - 1;
            if (NameIndex < 0)
            {
                NameIndex = 0;
            }

            int DayIndex = Array.IndexOf(MealDayArray, null) - 1;
            if (DayIndex < 0)
            {
                DayIndex = 0;
            }

            string Name = MealNameArray[NameIndex];
            string MealDetails = (string)MealDetailsInput.Text;
            string Day = MealDayArray[DayIndex];
            
            CommonElements.AddedMealsView.Add(new Meal() { 
                mealName = Name, 
                mealDetails = MealDetails, 
                dayOfMeal = Day 
            });

            MealDetailsInput.Clear();
            AddedMeals.Items.Refresh();
        }

        private void ViewMealsClick(object sender, RoutedEventArgs e)
        {
            #region HideElements
            ViewMealsLabel.Visibility = Visibility.Hidden;
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
            AddMealsTitle.Visibility = Visibility.Hidden;
            #endregion

            #region ShowElements
            ViewMealsTitle.Visibility = Visibility.Visible;
            MondayCol.Visibility = Visibility.Visible;
            TuesdayCol.Visibility = Visibility.Visible;
            WednesdayCol.Visibility = Visibility.Visible;
            ThursdayCol.Visibility = Visibility.Visible;
            FridayCol.Visibility = Visibility.Visible;
            SaturdayCol.Visibility = Visibility.Visible;
            SundayCol.Visibility = Visibility.Visible;

            AddMealButton.Visibility = Visibility.Visible;
            AddMealLabel.Visibility = Visibility.Visible;

            Canvas.SetTop(AddMealButton, 0);
            Canvas.SetLeft(AddMealButton, 70);
            Canvas.SetTop(AddMealLabel, 30);
            Canvas.SetLeft(AddMealLabel, 55);
            #endregion

            #region CategoriseMeals
            OrderedList = CommonElements.AddedMealsView.OrderBy(x => x.dayOfMeal).ToList();
            
            foreach (Meal m in OrderedList)
            {
                switch(m.dayOfMeal)
                {
                    case "Monday":
                        
                        string[] ExistingMondayMeals = new string[30];
                        foreach (weekMeal w in MondayMealsView)
                        {
                            ExistingMondayMeals[Array.IndexOf(ExistingMondayMeals, null)] = w.mealDetails;
                        }
                        
                        if (!ExistingMondayMeals.Contains(m.mealDetails))
                        {
                            MondayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;
                    
                    case "Tuesday":

                        string[] ExistingTuesdayMeals = new string[30];
                        foreach (weekMeal w in TuesdayMealsView)
                        {
                            ExistingTuesdayMeals[Array.IndexOf(ExistingTuesdayMeals, null)] = w.mealDetails;
                        }

                        if (!ExistingTuesdayMeals.Contains(m.mealDetails))
                        {
                            TuesdayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;

                    case "Wednesday":

                        string[] ExistingWednesdayMeals = new string[30];
                        foreach (weekMeal w in WednesdayMealsView)
                        {
                            ExistingWednesdayMeals[Array.IndexOf(ExistingWednesdayMeals, null)] = w.mealDetails;
                        }

                        if (!ExistingWednesdayMeals.Contains(m.mealDetails))
                        {
                            WednesdayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;

                    case "Thursday":

                        string[] ExistingThursdayMeals = new string[30];
                        foreach (weekMeal w in ThursdayMealsView)
                        {
                            ExistingThursdayMeals[Array.IndexOf(ExistingThursdayMeals, null)] = w.mealDetails;
                        }

                        if (!ExistingThursdayMeals.Contains(m.mealDetails))
                        {
                            ThursdayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;

                    case "Friday":

                        string[] ExistingFridayMeals = new string[30];
                        foreach (weekMeal w in FridayMealsView)
                        {
                            ExistingFridayMeals[Array.IndexOf(ExistingFridayMeals, null)] = w.mealDetails;
                        }

                        if (!ExistingFridayMeals.Contains(m.mealDetails))
                        {
                            FridayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;

                    case "Saturday":

                        string[] ExistingSaturdayMeals = new string[30];
                        foreach (weekMeal w in SaturdayMealsView)
                        {
                            ExistingSaturdayMeals[Array.IndexOf(ExistingSaturdayMeals, null)] = w.mealDetails;
                        }

                        if (!ExistingSaturdayMeals.Contains(m.mealDetails))
                        {
                            SaturdayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;

                    case "Sunday":

                        string[] ExistingSundayMeals = new string[30];
                        foreach (weekMeal w in SundayMealsView)
                        {
                            ExistingSundayMeals[Array.IndexOf(ExistingSundayMeals, null)] = w.mealDetails;
                        }

                        if (!ExistingSundayMeals.Contains(m.mealDetails))
                        {
                            SundayMealsView.Add(new weekMeal { mealName = m.mealName, mealDetails = m.mealDetails });
                        }
                        break;
                }
            }
            #endregion

            #region RefreshData
            MondayCol.Items.Refresh();
            TuesdayCol.Items.Refresh();
            WednesdayCol.Items.Refresh();
            ThursdayCol.Items.Refresh();
            FridayCol.Items.Refresh();
            SaturdayCol.Items.Refresh();
            SundayCol.Items.Refresh();
            #endregion
        }

        private void OpenExerciseWindow(object sender, RoutedEventArgs e)
        {
            ExerciseWindow exerciseWindow = new ExerciseWindow();
            this.Visibility = Visibility.Hidden;
            exerciseWindow.Show();
        }

        private void OpenYourDayWindow(object sender, RoutedEventArgs e)
        {
            YourDayWindow yourDayWindow = new YourDayWindow();
            this.Visibility = Visibility.Hidden;
            yourDayWindow.Show();
        }

        private void OpenYourGoalsWindow(object sender, RoutedEventArgs e)
        {
            YourGoalsWindow yourGoalsWindow = new YourGoalsWindow();
            this.Visibility = Visibility.Hidden;
            yourGoalsWindow.Show();
        }

        private void OpenExerciseCalendarWindow(object sender, RoutedEventArgs e)
        {
            ExerciseCalendarWindow exerciseCalendarWindow = new ExerciseCalendarWindow();
            this.Visibility = Visibility.Hidden;
            exerciseCalendarWindow.Show();
        }
    };
}