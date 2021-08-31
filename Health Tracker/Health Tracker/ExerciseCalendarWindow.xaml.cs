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
    public partial class ExerciseCalendarWindow : Window
    {
        #region DateVariables
        IDictionary<string, int> dayNumbers = new Dictionary<string, int>()
        {
            {"Monday", 0 },
            {"Tuesday", 1 },
            {"Wednesday", 2 },
            {"Thursday", 3 },
            {"Friday", 4 },
            {"Saturday", 5 }
            , {"Sunday", 6 } 
        };
        IDictionary<int, string> monthNumbers = new Dictionary<int, string>()
        {
            {1, "January" },
            {2, "February" },
            {3, "March"},
            {4, "April" },
            {5 , "May" },
            {6 , "June" },
            {7 , "July" },
            {8 , "August" },
            {9 , "September" },
            {10 , "October" },
            {11 , "November" },
            {12 , "December" }
        };
        IDictionary<string, int> daysInMonth = new Dictionary<string, int>()
        {
            {"January", 31 },
            {"February", 28 },
            {"March", 31 },
            {"April", 30 },
            {"May", 31 },
            {"June", 30 },
            {"July", 31 },
            {"August", 31 },
            {"September", 30 },
            {"October", 31 },
            {"November", 30 },
            {"December", 31 }
        };

        Button[] calendarButtonArray = new Button[42];
        #endregion
        ObservableCollection<Exercise> toShow = new ObservableCollection<Exercise>();
        public ExerciseCalendarWindow()
        {
            InitializeComponent();

            #region AddDates
            int todayDate = Int32.Parse(DateTime.Now.ToString().Substring(0, 2));

            string currentMonthNumber = DateTime.Now.Month.ToString();
            int currentMonthInt = Int32.Parse(currentMonthNumber);
            string currentMonth = monthNumbers[currentMonthInt].ToString();
            MonthName.Content = currentMonth;

            DateTime firstOfMonth = new DateTime(2021, Int32.Parse(currentMonthNumber), 1);
            string dayOfFirst = firstOfMonth.DayOfWeek.ToString();
            int dayOfFirstNumber = dayNumbers[dayOfFirst];
            int numberOfDays = daysInMonth[currentMonth];

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Button b = new Button();
                    b.Click += new RoutedEventHandler(CalendarButtonClick);
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                    CalendarGrid.Children.Add(b);
                }
            }

            foreach (Button button in CalendarGrid.Children)
            {
                calendarButtonArray[Array.IndexOf(calendarButtonArray, null)] = button;
            }

            #region PreviousMonth
            int previousMonthInt = currentMonthInt - 1;
            string previousMonth = monthNumbers[previousMonthInt];
            int daysInPreviousMonth = daysInMonth[previousMonth];
            int previousMonthStartDate = daysInPreviousMonth - dayOfFirstNumber + 1;
            int dateToAddPreviousMonth = previousMonthStartDate;

            for (int i = 0; i < dayOfFirstNumber; i++)
            {
                calendarButtonArray[i].Content = dateToAddPreviousMonth.ToString();
                dateToAddPreviousMonth += 1;
                calendarButtonArray[i].Opacity = 0.5;
            }
            #endregion

            #region CurrentMonth
            int dateToAddCurrentMonth = 1;
            for (int i = dayOfFirstNumber; i < dayOfFirstNumber + numberOfDays; i++)
            {
                calendarButtonArray[i].Content = dateToAddCurrentMonth.ToString();
               
                if(dateToAddCurrentMonth == todayDate)
                {
                    calendarButtonArray[i].Background = Brushes.Blue;
                }
                dateToAddCurrentMonth += 1;
            };
            #endregion

            #region NextMonth
            int nextMonthInt = currentMonthInt + 1;
            int dateToAddNextMonth = 1;

            for (int i = dayOfFirstNumber + numberOfDays; i < 42; i++)
            {
                calendarButtonArray[i].Content = dateToAddNextMonth.ToString();
                dateToAddNextMonth += 1;
                calendarButtonArray[i].Opacity = 0.5;
            }
            #endregion

            #endregion

        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        protected void CalendarButtonClick(object sender, RoutedEventArgs e)
        {

            int row = Grid.GetRow((Button) sender);
            int col = Grid.GetColumn((Button)sender);

            var dayPair = dayNumbers.FirstOrDefault(x => x.Value == col);
            string day = String.Join(",", dayPair);
            int index = day.IndexOf(",");
            day = day.Substring(1, index - 1);

            foreach(Exercise exercise in CommonElements.AddedExercisesView)
            {
                if (exercise.exerciseFrequency.Contains(day) | exercise.exerciseFrequency == "daily")
                {
                    toShow.Add(exercise);
                }
            }

            ExerciseDetailsPopup.Height = toShow.Count * 100;

            Canvas PopupCanvas = new Canvas();
            PopupCanvas.Background = Brushes.White;

            test.Text = toShow.Count.ToString();

            for (int i = 0; i < toShow.Count; i++)
            {
                TextBlock CurrentExerciseTitle = new TextBlock();
                CurrentExerciseTitle.Text = toShow[i].exerciseName;
                CurrentExerciseTitle.TextDecorations = TextDecorations.Underline;
                CurrentExerciseTitle.Margin = new Thickness(100, i * 100, 0, 0);
                PopupCanvas.Children.Add(CurrentExerciseTitle);

                Label CurrentExerciseDetailsLabel = new Label();
                CurrentExerciseDetailsLabel.Content = "Details:";
                CurrentExerciseDetailsLabel.Margin = new Thickness(10, i * 100 + 20, 0, 0);
                PopupCanvas.Children.Add(CurrentExerciseDetailsLabel);

                TextBlock CurrentExerciseDetails = new TextBlock();
                CurrentExerciseDetails.Text = toShow[i].exerciseDetails;
                CurrentExerciseDetails.Margin = new Thickness(65, i * 100 + 25, 0, 0);
                PopupCanvas.Children.Add(CurrentExerciseDetails);

                Label CurrentExerciseTimeLabel = new Label();
                CurrentExerciseTimeLabel.Content = "Time:";
                CurrentExerciseTimeLabel.Margin = new Thickness(10, i * 100 + 40, 0, 0);
                PopupCanvas.Children.Add(CurrentExerciseTimeLabel);

                TextBlock CurrentExerciseTime = new TextBlock();
                CurrentExerciseTime.Text = toShow[i].exerciseTime;
                CurrentExerciseTime.Margin = new Thickness(65, i * 100 + 45, 0, 0);
                PopupCanvas.Children.Add(CurrentExerciseTime);
            }

            ExerciseDetailsPopup.Child = PopupCanvas;
            ExerciseDetailsPopup.IsOpen = true;
        }
    }
}
