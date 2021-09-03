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
        string todayDayOfWeek = DateTime.Now.DayOfWeek.ToString();

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
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }
    }
}
