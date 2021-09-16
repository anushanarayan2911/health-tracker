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
    public partial class YourDayWindow : Window
    {
        ObservableCollection<dayMeal> BreakfastView = new ObservableCollection<dayMeal>();
        ObservableCollection<dayMeal> LunchView = new ObservableCollection<dayMeal>();
        ObservableCollection<dayMeal> DinnerView = new ObservableCollection<dayMeal>();
        ObservableCollection<dayMeal> SnackView = new ObservableCollection<dayMeal>();
        ObservableCollection<Exercise> ExerciseView = new ObservableCollection<Exercise>();
        string todayDayOfWeek = DateTime.Now.DayOfWeek.ToString();
        DateTime todayDate = DateTime.Now;

        public YourDayWindow()
        {
            InitializeComponent();

            #region Meals
            BreakfastCol.ItemsSource = BreakfastView;
            LunchCol.ItemsSource = LunchView;
            DinnerCol.ItemsSource = DinnerView;
            SnackCol.ItemsSource = SnackView;

            foreach (Meal meal in CommonElements.AddedMealsView)
            {
                if (meal.dayOfMeal == todayDayOfWeek)
                {
                    switch (meal.mealName)
                    {
                        case "Breakfast":
                            BreakfastView.Add(new dayMeal
                            {
                                mealDetails = meal.mealDetails,
                            });
                            break;

                        case "Lunch":
                            LunchView.Add(new dayMeal
                            {
                                mealDetails = meal.mealDetails,
                            });
                            break;

                        case "Dinner":
                            DinnerView.Add(new dayMeal
                            {
                                mealDetails = meal.mealDetails,
                            });
                            break;

                        case "Snack":
                            SnackView.Add(new dayMeal
                            {
                                mealDetails = meal.mealDetails,
                            });
                            break;
                    }
                }
            }

            BreakfastCol.Items.Refresh();
            LunchCol.Items.Refresh();
            DinnerCol.Items.Refresh();
            SnackCol.Items.Refresh();
            #endregion

            #region Exercises
            ExercisesTable.ItemsSource = ExerciseView;

            foreach (Exercise exercise in CommonElements.AddedExercisesView)
            {
                DateTime StartDate = Convert.ToDateTime(exercise.exerciseDate.Substring(0, 10));
                DateTime EndDate = Convert.ToDateTime(exercise.exerciseDate.Substring(13, 10));

                if (StartDate <= todayDate & todayDate <= EndDate)
                {
                    if (exercise.exerciseFrequency.Contains(todayDayOfWeek) || exercise.exerciseFrequency == "daily")
                    {
                        ExerciseView.Add(new Exercise
                        {
                            exerciseName = exercise.exerciseName,
                            exerciseDetails = exercise.exerciseDetails,
                            exerciseTime = exercise.exerciseTime
                        });
                    }
                }
            }

            ExercisesTable.Items.Refresh();
            #endregion
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        private void OpenFoodWindow(object sender, RoutedEventArgs e)
        {
            FoodWindow foodWindow = new FoodWindow();
            this.Visibility = Visibility.Hidden;
            foodWindow.Show();
        }

        private void OpenExerciseWindow(object sender, RoutedEventArgs e)
        {
            ExerciseWindow exerciseWindow = new ExerciseWindow();
            this.Visibility = Visibility.Hidden;
            exerciseWindow.Show();
        }

        private void OpenExerciseCalendarWindow(object sender, RoutedEventArgs e)
        {
            ExerciseCalendarWindow exerciseCalendarWindow = new ExerciseCalendarWindow();
            this.Visibility = Visibility.Hidden;
            exerciseCalendarWindow.Show();
        }

        private void OpenYourGoalsWindow(object sender, RoutedEventArgs e)
        {
            YourGoalsWindow yourGoalsWindow = new YourGoalsWindow();
            this.Visibility = Visibility.Hidden;
            yourGoalsWindow.Show();
        }
    }
}
