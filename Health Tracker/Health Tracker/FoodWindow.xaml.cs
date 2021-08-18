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

namespace Health_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FoodWindow : Window
    {
        string[] mealNameArray = new String[10];
        string[] mealInfoArray = new string[10];
        public FoodWindow()
        {
            InitializeComponent();
        }

        public void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        private void SendMealName(object sender, RoutedEventArgs e)
        {
            string mealName = (string)((CheckBox)sender).Content;
            int index = Array.IndexOf(mealNameArray, null);
            mealNameArray[index] = mealName;
        }

        private void SendMealInfo(object sender, RoutedEventArgs e)
        {
            string mealInfo = (string)UserMealDetails.Text;
            int index = Array.IndexOf(mealInfoArray, null);
            mealInfoArray[index] = mealInfo;
            Result.Text = string.Join(" ", mealInfoArray).ToString();
        }
    };
}
