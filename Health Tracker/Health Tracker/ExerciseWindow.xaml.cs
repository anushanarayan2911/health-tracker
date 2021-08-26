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
        ObservableCollection<Exercise> AddedExercisesView = new ObservableCollection<Exercise>();

        public ExerciseWindow()
        {
            InitializeComponent();
            AddedExercises.ItemsSource = AddedExercisesView;
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

            AddedExercisesView.Add(new Exercise { exerciseName = exerciseTitle, exerciseDetails = exerciseDetails, exerciseFrequency = exerciseFrequency, exerciseStartTime = StartTime, exerciseEndTime = EndTime });

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

        private void StartTimeDropDownMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string startTimeFull = StartTimeDropDownMenu.SelectedValue.ToString();
            StartTime = startTimeFull.Substring(startTimeFull.IndexOf(" ") + 1);
        }

        private void EndTimeDropDownMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string endTimeFull = EndTimeDropDownMenu.SelectedValue.ToString();
            EndTime = endTimeFull.Substring(endTimeFull.IndexOf(" ") + 1);
        }
    }
}
