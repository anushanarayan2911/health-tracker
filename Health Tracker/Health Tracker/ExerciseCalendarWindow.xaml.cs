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
        IDictionary<string, int> DayNumbers = new Dictionary<string, int>()
        {
            {"Monday", 0 },
            {"Tuesday", 1 },
            {"Wednesday", 2 },
            {"Thursday", 3 },
            {"Friday", 4 },
            {"Saturday", 5 }
            , {"Sunday", 6 } 
        };
        IDictionary<int, string> MonthNumbers = new Dictionary<int, string>()
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
        IDictionary<string, int> DaysInMonth = new Dictionary<string, int>()
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

        int TodayDate;
        string CurrentMonthNumber;
        int CurrentMonthInt;
        string CurrentMonth;

        DateTime FirstOfMonth;
        string DayOfFirst;
        int DayOfFirstNumber;
        int NumberOfDays;

        Button[] CalendarButtonArray = new Button[42];
        #endregion

        ObservableCollection<Exercise> ToShow = new ObservableCollection<Exercise>();
        Canvas PopupCanvas = new Canvas();
        public ExerciseCalendarWindow()
        {
            InitializeComponent();

            #region AddDates

            #region StartVariables
            TodayDate = Int32.Parse(DateTime.Now.ToString().Substring(0, 2));

            CurrentMonthNumber = DateTime.Now.Month.ToString();
            CurrentMonthInt = Int32.Parse(CurrentMonthNumber);
            CurrentMonth = MonthNumbers[CurrentMonthInt].ToString();
            MonthName.Content = CurrentMonth;

            FirstOfMonth = new DateTime(2021, Int32.Parse(CurrentMonthNumber), 1);
            DayOfFirst = FirstOfMonth.DayOfWeek.ToString();
            DayOfFirstNumber = DayNumbers[DayOfFirst];
            NumberOfDays = DaysInMonth[CurrentMonth];
            #endregion

            #region AddButtons
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Button b = new Button();
                    b.Click += new RoutedEventHandler(CalendarButtonClick);
                    b.Background = Brushes.White;
                    b.BorderBrush = new SolidColorBrush(Color.FromRgb(25, 149, 159));
                    b.BorderThickness = new Thickness(1);
                    b.BorderBrush.Opacity = 0.5;
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                    CalendarGrid.Children.Add(b);
                }
            }

            foreach (Button button in CalendarGrid.Children)
            {
                CalendarButtonArray[Array.IndexOf(CalendarButtonArray, null)] = button;
            }
            #endregion

            #region PreviousMonth
            int PreviousMonthInt = CurrentMonthInt - 1;
            string PreviousMonth = MonthNumbers[PreviousMonthInt];
            int DaysInPreviousMonth = DaysInMonth[PreviousMonth];
            int PreviousMonthStartDate = DaysInPreviousMonth - DayOfFirstNumber + 1;
            int DateToAddPreviousMonth = PreviousMonthStartDate;

            for (int i = 0; i < DayOfFirstNumber; i++)
            {
                CalendarButtonArray[i].Content = DateToAddPreviousMonth.ToString();
                DateToAddPreviousMonth += 1;
                CalendarButtonArray[i].Opacity = 0.5;
            }
            #endregion

            #region CurrentMonth
            int DateToAddCurrentMonth = 1;
            for (int i = DayOfFirstNumber; i < DayOfFirstNumber + NumberOfDays; i++)
            {
                CalendarButtonArray[i].Content = DateToAddCurrentMonth.ToString();
               
                if(DateToAddCurrentMonth == TodayDate)
                {
                    CalendarButtonArray[i].Background = new SolidColorBrush(Color.FromRgb(25, 149, 159));
                    CalendarButtonArray[i].Background.Opacity = 0.5;
                }
                DateToAddCurrentMonth += 1;
            };
            #endregion

            #region NextMonth
            int NextMonthInt = CurrentMonthInt + 1;
            int DateToAddNextMonth = 1;

            for (int i = DayOfFirstNumber + NumberOfDays; i < 42; i++)
            {
                CalendarButtonArray[i].Content = DateToAddNextMonth.ToString();
                DateToAddNextMonth += 1;
                CalendarButtonArray[i].Opacity = 0.5;
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

            #region GetWhichButtonWasClicked
            int Row = Grid.GetRow((Button) sender);
            int Col = Grid.GetColumn((Button)sender);

            var DayPair = DayNumbers.FirstOrDefault(x => x.Value == Col);
            string Day = String.Join(",", DayPair);
            int index = Day.IndexOf(",");
            Day = Day.Substring(1, index - 1);

            #endregion

            #region GetWhichExercisesToShow
            foreach (Exercise exercise in CommonElements.AddedExercisesView)
            {
                if (exercise.exerciseFrequency.Contains(Day) | exercise.exerciseFrequency == "daily")
                {
                    DateTime ExerciseStartDate = Convert.ToDateTime(exercise.exerciseDate.Substring(0, 10));
                    DateTime ExerciseEndDate = Convert.ToDateTime(exercise.exerciseDate.Substring(13, 10));

                    DateTime CellDate = Convert.ToDateTime(((Button)sender).Content.ToString() + "/" + CurrentMonthNumber + "/" + "2021");
                    
                    if (ExerciseStartDate <= CellDate & CellDate <= ExerciseEndDate)
                    {
                        if (!ToShow.Contains(exercise))
                        {
                            ToShow.Add(exercise);
                        }  
                    }
                }
            }
            #endregion

            #region ExercisePopup
            ExerciseDetailsPopup.Height = ToShow.Count * 100;

            PopupCanvas.Background = new SolidColorBrush(Color.FromRgb(25, 149, 159));

            for (int i = 0; i < ToShow.Count; i++)
            {
                #region AddExerciseElementsToPopup
                TextBlock CurrentExerciseTitle = new TextBlock();
                CurrentExerciseTitle.Text = ToShow[i].exerciseName;
                CurrentExerciseTitle.TextDecorations = TextDecorations.Underline;
                CurrentExerciseTitle.FontFamily = new FontFamily("Runda");
                CurrentExerciseTitle.Uid = "CurrentExerciseTitle";
                CurrentExerciseTitle.Margin = new Thickness(100, i * 100, 0, 0);
                PopupCanvas.Children.Add(CurrentExerciseTitle);

                Label CurrentExerciseDetailsLabel = new Label();
                CurrentExerciseDetailsLabel.Content = "Details:";
                CurrentExerciseDetailsLabel.FontFamily = new FontFamily("Runda Light");
                CurrentExerciseDetailsLabel.Uid = "CurrentExerciseDetailsLabel";
                CurrentExerciseDetailsLabel.Margin = new Thickness(10, i * 100 + 20, 0, 0);
                PopupCanvas.Children.Add(CurrentExerciseDetailsLabel);

                TextBlock CurrentExerciseDetails = new TextBlock();
                CurrentExerciseDetails.Text = ToShow[i].exerciseDetails;
                CurrentExerciseDetails.FontFamily = new FontFamily("Runda Light");
                CurrentExerciseDetails.Uid = "CurrentExerciseDetails";
                CurrentExerciseDetails.Margin = new Thickness(65, i * 100 + 25, 0, 0);
                PopupCanvas.Children.Add(CurrentExerciseDetails);

                Label CurrentExerciseTimeLabel = new Label();
                CurrentExerciseTimeLabel.Content = "Time:";
                CurrentExerciseTimeLabel.FontFamily = new FontFamily("Runda Light");
                CurrentExerciseTimeLabel.Uid = "CurrentExerciseTimeLabel";
                CurrentExerciseTimeLabel.Margin = new Thickness(10, i * 100 + 40, 0, 0);
                PopupCanvas.Children.Add(CurrentExerciseTimeLabel);

                TextBlock CurrentExerciseTime = new TextBlock();
                CurrentExerciseTime.Text = ToShow[i].exerciseTime;
                CurrentExerciseTime.FontFamily = new FontFamily("Runda Light");
                CurrentExerciseTime.Uid = "CurrentExerciseTime";
                CurrentExerciseTime.Margin = new Thickness(65, i * 100 + 45, 0, 0);
                PopupCanvas.Children.Add(CurrentExerciseTime);
                #endregion
            }

            #region AddQuitButtonToPopup
            Button QuitButton = new Button();
            QuitButton.Content = new Image {
                Source = new BitmapImage(new Uri("C:/Users/anush/source/repos/health-tracker/Images/Close.png"))
            };
            QuitButton.Click += new RoutedEventHandler(QuitButtonClick);
            QuitButton.Width = 10;
            QuitButton.Background = null;
            QuitButton.BorderThickness = new Thickness(0);
            QuitButton.Margin = new Thickness(190, 0, 0, 0);
            PopupCanvas.Children.Add(QuitButton);
            #endregion

            ExerciseDetailsPopup.Child = PopupCanvas;
            ExerciseDetailsPopup.IsOpen = true;
            #endregion
        }

        public void QuitButtonClick(object sender, RoutedEventArgs e)
        {
            ExerciseDetailsPopup.IsOpen = false;
            PopupCanvas.Children.Clear();
            ToShow.Clear();
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
