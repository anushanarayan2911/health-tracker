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
    public partial class ExerciseWindow : Window
    {
        public string[] Frequencies = new string[30];
        public string StartTime;
        public string EndTime;
        public string StartDate;
        public string EndDate;

        public ExerciseWindow()
        {
            InitializeComponent();
            AddedExercises.ItemsSource = CommonElements.AddedExercisesView;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        private void SendExerciseInfo(object sender, RoutedEventArgs e)
        {
            string exerciseTitle = ExerciseTitleInput.Text;
            string exerciseDetails = ExerciseDetailsInput.Text;
            string exerciseFrequency = String.Join(", ", Frequencies).ToString();
            StartTime = ExerciseStartTimeInput.Text;
            EndTime = ExerciseEndTimeInput.Text;
            StartDate = ExerciseStartDateInput.Text;
            EndDate = ExerciseEndDateInput.Text;

            for (int i = 0; i < exerciseFrequency.Length; i++)
            {
                if (exerciseFrequency.Substring(i, 3) == ", ,")
                {
                    exerciseFrequency = exerciseFrequency.Substring(0, i);
                    break;
                }
            }

            CommonElements.AddedExercisesView.Add(new Exercise { 
                exerciseName = exerciseTitle, 
                exerciseDetails = exerciseDetails,
                exerciseFrequency = exerciseFrequency,
                exerciseTime = StartTime + " - " + EndTime,
                exerciseDate = StartDate + " - " + EndDate
            });

            foreach(string s in Frequencies)
            {
                Frequencies[Array.IndexOf(Frequencies, s)] = null;
            }
        }

        private void FrequencyDropDownMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string userFrequencyFull = FrequencyDropDownMenu.SelectedValue.ToString();
            string userFrequency = userFrequencyFull.Substring(userFrequencyFull.IndexOf(" ") + 1);

            
            switch (userFrequency)
            {
                case "Daily":
                    Frequencies[0] = "daily";
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
            Frequencies[0] = dayName;
        }

        private void SendDayNameMulti(object sender, RoutedEventArgs e)
        {
            string dayName = (string)((CheckBox)sender).Content;
            Frequencies[Array.IndexOf(Frequencies, null)] = dayName;
        }
    }
}
