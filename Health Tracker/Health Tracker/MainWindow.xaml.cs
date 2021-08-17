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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FoodButtonClick(object sender, RoutedEventArgs e)
        {
            FoodWindow foodWindow = new FoodWindow();
            this.Visibility = Visibility.Hidden;
            foodWindow.Show();
        }

        private void ExerciseButtonClick(object sender, RoutedEventArgs e)
        {
            ExerciseWindow exerciseWindow = new ExerciseWindow();
            this.Visibility = Visibility.Hidden;
            exerciseWindow.Show();
        }

        private void ExerciseCalendarButtonClick(object sender, RoutedEventArgs e)
        {
            ExerciseCalendarWindow exerciseCalendarWindow = new ExerciseCalendarWindow();
            this.Visibility = Visibility.Hidden;
            exerciseCalendarWindow.Show();
        }

        private void YourDayButtonClick(object sender, RoutedEventArgs e)
        {
            YourDayWindow yourDayWindow = new YourDayWindow();
            this.Visibility = Visibility.Hidden;
            yourDayWindow.Show();
        }

        private void YourGoalsButtonClick(object sender, RoutedEventArgs e)
        {
            YourGoalsWindow yourGoalsWindow = new YourGoalsWindow();
            this.Visibility = Visibility.Hidden;
            yourGoalsWindow.Show();
        }
    }
}
