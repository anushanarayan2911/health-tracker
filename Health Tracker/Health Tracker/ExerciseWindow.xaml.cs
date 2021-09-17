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
        #region StartVariables
        public string[] Frequencies = new string[30];
        public string StartTime;
        public string EndTime;
        public string StartDate;
        public string EndDate;
        #endregion

        public ExerciseWindow()
        {
            InitializeComponent();
            AddedExercises.ItemsSource = CommonElements.AddedExercisesView;
            OKButton.Background.Opacity = 0.5;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        private void SendExerciseInfo(object sender, RoutedEventArgs e)
        {

            #region GetInputs
            string ExerciseTitle= ExerciseTitleInput.Text;
            string ExerciseDetails = ExerciseDetailsInput.Text;
            string ExerciseFrequency = String.Join(", ", Frequencies).ToString();
            StartTime = ExerciseStartTimeInput.Text;
            EndTime = ExerciseEndTimeInput.Text;
            StartDate = ExerciseStartDateInput.Text;
            EndDate = ExerciseEndDateInput.Text;
            
            for (int i = 0; i < ExerciseFrequency.Length; i++)
            {
                if (ExerciseFrequency.Substring(i, 3) == ", ,")
                {
                    ExerciseFrequency = ExerciseFrequency.Substring(0, i);
                    break;
                }
            }
            #endregion

            #region ClearInputFields
            ExerciseTitleInput.Clear();
            ExerciseDetailsInput.Clear();
            ExerciseStartTimeInput.Clear();
            ExerciseEndTimeInput.Clear();
            ExerciseStartDateInput.SelectedDate = null;
            ExerciseEndDateInput.SelectedDate = null;
            #endregion

            #region AddToObservableCollection
            CommonElements.AddedExercisesView.Add(new Exercise { 
                exerciseName = ExerciseTitle, 
                exerciseDetails = ExerciseDetails,
                exerciseFrequency = ExerciseFrequency,
                exerciseTime = StartTime + " - " + EndTime,
                exerciseDate = StartDate + " - " + EndDate
            });
            #endregion

            #region ClearFrequencies
            foreach (string s in Frequencies)
            {
                Frequencies[Array.IndexOf(Frequencies, s)] = null;
            }
            #endregion
        }

        private void FrequencyDropDownMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string UserFrequencyFull = FrequencyDropDownMenu.SelectedValue.ToString();
            string UserFrequency = UserFrequencyFull.Substring(UserFrequencyFull.IndexOf(" ") + 1);

            
            switch (UserFrequency)
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
            string DayName = (string)((RadioButton)sender).Content;
            Frequencies[0] = DayName;
        }

        private void SendDayNameMulti(object sender, RoutedEventArgs e)
        {
            string DayName = (string)((CheckBox)sender).Content;
            Frequencies[Array.IndexOf(Frequencies, null)] = DayName;
        }

        private void OpenFoodWindow(object sender, RoutedEventArgs e)
        {
            FoodWindow foodWindow = new FoodWindow();
            this.Visibility = Visibility.Hidden;
            foodWindow.Show();
        }

        private void OpenExerciseCalendarWindow(object sender, RoutedEventArgs e)
        {
            ExerciseCalendarWindow exerciseCalendarWindow = new ExerciseCalendarWindow();
            this.Visibility = Visibility.Hidden;
            exerciseCalendarWindow.Show();
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
    }
}
