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
        ObservableCollection<Meal> allMealsView = new ObservableCollection<Meal>();
        public FoodWindow()
        {
            InitializeComponent();
            TodayMeals.ItemsSource = allMealsView;
        }

        public void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        public void SendMealName(object sender, RoutedEventArgs e)
        {
            string name = (string)((CheckBox)sender).Content;
            int index = Array.IndexOf(mealNameArray, null);
            mealNameArray[index] = name;
        }

        public void SendMealInfo(object sender, RoutedEventArgs e)
        {
            int index = Array.IndexOf(mealNameArray, null) - 1;
            if (index < 0)
            {
                index = 0;
            }
            
            string name = mealNameArray[index];
            string mealDetails = (string)UserMealDetails.Text;

            allMealsView.Add(new Meal() { mealName = name, mealDetails = mealDetails });
            
            TodayMeals.Items.Refresh();
            Result.Text = allMealsView[0].mealName.ToString();
        }
    };
}