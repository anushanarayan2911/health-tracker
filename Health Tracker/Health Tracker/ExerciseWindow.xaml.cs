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
    public partial class ExerciseWindow : Window
    {
        public string exerciseName;
        public string exerciseDetails;
        public string[] exerciseFrequency = new string[30];
        public string exerciseStartTime;
        public string exerciseEndTime;
        public ExerciseWindow()
        {
            InitializeComponent();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        private void SendExerciseInfo(object sender, RoutedEventArgs e)
        {

        }

        private void FrequencyDropDownMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string userFrequencyFull = FrequencyDropDownMenu.SelectedValue.ToString();
            string userFrequency = userFrequencyFull.Substring(userFrequencyFull.IndexOf(" ") + 1);

            
            switch (userFrequency)
            {
                case "Daily":
                    exerciseFrequency[0] = "daily";
                    break;

                case "Weekly":
                    DaysOfWeekCheckbox.Visibility = Visibility.Hidden;
                    DaysOfWeekButton.Visibility = Visibility.Visible;
                    break;

                case "Custom":
                    DaysOfWeekButton.Visibility = Visibility.Hidden;
                    DaysOfWeekCheckbox.Visibility = Visibility.Visible;
                    break;
            }
            
        }

        private void SendDayName(object sender, RoutedEventArgs e)
        {
            string dayName = (string)((RadioButton)sender).Content;
            exerciseFrequency[0] = dayName;
            test.Text = String.Join(" ", exerciseFrequency);
        }

        private void SendDayNameMulti(object sender, RoutedEventArgs e)
        {
            string dayName = (string)((CheckBox)sender).Content;
            exerciseFrequency[Array.IndexOf(exerciseFrequency, null)] = dayName;
        }
    }
}
