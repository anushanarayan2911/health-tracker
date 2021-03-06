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
using System.Data;

namespace Health_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class YourGoalsWindow : Window
    {
        #region StartVariables
        string GoalInfo;
        string AchieveBy;
        string Status;
        DateTime Today;
        DateTime OneWeekAway;
        Canvas StatusPopupCanvas = new Canvas();
        #endregion

        public YourGoalsWindow()
        {
            InitializeComponent();

            Today = DateTime.Now;
            OneWeekAway = Today.AddDays(+7);

            GoalsTable.ItemsSource = CommonElements.AddedGoalsView;
            CompletedGoalsTable.ItemsSource = CommonElements.CompletedGoalsView;

            OKButton.Background.Opacity = 0.5;
            ViewCompletedGoalsButton.Background.Opacity = 0.5;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }

        private void OKButtonClick(object sender, RoutedEventArgs e)
        {
            GoalInfo = AddGoalInput.Text;
            AchieveBy = AchieveByDate.Text.ToString();
            Status = "unfinished";

            CommonElements.AddedGoalsView.Add(new Goal {
                GoalInfo = GoalInfo,
                AchieveBy = AchieveBy,
                Status = Status
            });

            AddGoalInput.Clear();
            AchieveByDate.SelectedDate = null;
        }

        private void StatusButtonClick(object sender, RoutedEventArgs e)
        {
            #region GetGoal
            Button b = sender as Button;
            Goal SelectedRow = b.DataContext as Goal;

            string GoalInfo = SelectedRow.GoalInfo.ToString();
            DateTime AchieveBy = Convert.ToDateTime(SelectedRow.AchieveBy.ToString());
            #endregion

            #region StatusPopup

            string Status = FormatStatusPopup(AchieveBy)[0].ToString();
            StatusPopupCanvas.Background = (Brush) FormatStatusPopup(AchieveBy)[1];

            #region AddElementsToStatusPopup

            #region GoalInfoTextBlock
            TextBlock GoalInfoTextBlock = new TextBlock();
            GoalInfoTextBlock.Text = GoalInfo;
            GoalInfoTextBlock.TextDecorations = TextDecorations.Underline;
            GoalInfoTextBlock.FontFamily = new FontFamily("Runda");
            GoalInfoTextBlock.Uid = "GoalInfoTextBlock";
            GoalInfoTextBlock.Margin = new Thickness(150, 0, 0, 0);
            GoalInfoTextBlock.Uid = "GoalInfoTextBlock";
            StatusPopupCanvas.Children.Add(GoalInfoTextBlock);
            #endregion

            #region AchieveByLabel
            Label AchieveByLabel = new Label();
            AchieveByLabel.Content = "Achieve By: ";
            AchieveByLabel.FontFamily = new FontFamily("Runda Light");
            AchieveByLabel.Uid = "AchieveByLabel";
            AchieveByLabel.Margin = new Thickness(0, 30, 0, 0);
            StatusPopupCanvas.Children.Add(AchieveByLabel);
            #endregion

            #region AchieveByTextBlock

            TextBlock AchieveByTextBlock = new TextBlock();
            AchieveByTextBlock.Text = AchieveBy.ToString().Substring(0, 10);
            AchieveByTextBlock.FontFamily = new FontFamily("Runda Light");
            AchieveByTextBlock.Uid = "AchieveByTextBlock";
            AchieveByTextBlock.Margin = new Thickness(75, 35, 0, 0);
            StatusPopupCanvas.Children.Add(AchieveByTextBlock);
            #endregion

            #region StatusLabel
            Label StatusLabel = new Label();
            StatusLabel.Content = "Status";
            StatusLabel.FontFamily = new FontFamily("Runda Light");
            StatusLabel.Uid = "StatusLabel";
            StatusLabel.Margin = new Thickness(0, 60, 0, 0);
            StatusPopupCanvas.Children.Add(StatusLabel);
            #endregion

            #region StatusTextBlock
            TextBlock StatusTextBlock = new TextBlock();
            StatusTextBlock.Text = Status;
            StatusTextBlock.FontFamily = new FontFamily("Runda Light");
            StatusTextBlock.Uid = "StatusTextBlock";
            StatusTextBlock.Margin = new Thickness(75, 65, 0, 0);
            StatusPopupCanvas.Children.Add(StatusTextBlock);
            #endregion

            #region CompletedButton
            Button CompletedButton = new Button();
            CompletedButton.Content = new Image
            {
                Source = new BitmapImage(new Uri("C:/Users/anush/source/repos/health-tracker/Images/CompleteGoal.png"))
            };
            CompletedButton.Click += new RoutedEventHandler(CompletedButtonClick);
            CompletedButton.Height = 30;
            CompletedButton.Width = 70;
            CompletedButton.Background = null;
            CompletedButton.BorderThickness = new Thickness(0);
            CompletedButton.Margin = new Thickness(0, 120, 0, 0);
            StatusPopupCanvas.Children.Add(CompletedButton);
            #endregion

            #region ChangeAchieveByButton
            Button ChangeAchieveByButton = new Button();
            ChangeAchieveByButton.Content = new Image
            {
                Source = new BitmapImage(new Uri("C:/Users/anush/source/repos/health-tracker/Images/ChangeAchieveBy.png"))
            };
            ChangeAchieveByButton.Click += new RoutedEventHandler(ChangeAchieveByButtonClick);
            ChangeAchieveByButton.Height = 30;
            ChangeAchieveByButton.Width = 120;
            ChangeAchieveByButton.Background = null;
            ChangeAchieveByButton.BorderThickness = new Thickness(0);
            ChangeAchieveByButton.Margin = new Thickness(90, 120, 0, 0);
            StatusPopupCanvas.Children.Add(ChangeAchieveByButton);
            #endregion

            #region DeleteGoalButton
            Button DeleteGoalButton = new Button();
            DeleteGoalButton.Content = new Image
            {
                Source = new BitmapImage(new Uri("C:/Users/anush/source/repos/health-tracker/Images/DeleteGoal.png"))
            }; 
            DeleteGoalButton.Click += new RoutedEventHandler(DeleteGoalButtonClick);
            DeleteGoalButton.Height = 30;
            DeleteGoalButton.Width = 50;
            DeleteGoalButton.Background = null;
            DeleteGoalButton.BorderThickness = new Thickness(0);
            DeleteGoalButton.Margin = new Thickness(260, 120, 0, 0);
            StatusPopupCanvas.Children.Add(DeleteGoalButton);
            #endregion

            #region ExitButton
            Button ExitButton = new Button();
            ExitButton.Content = new Image
            {
                Source = new BitmapImage(new Uri("C:/Users/anush/source/repos/health-tracker/Images/Close.png"))
            }; ;
            ExitButton.Click += new RoutedEventHandler(ExitButtonClick);
            ExitButton.Height = 15;
            ExitButton.Width = 15;
            ExitButton.Background = null;
            ExitButton.BorderThickness = new Thickness(0);
            ExitButton.Margin = new Thickness(285, 0, 0, 0);
            StatusPopupCanvas.Children.Add(ExitButton);
            #endregion

            #endregion

            StatusPopup.Child = StatusPopupCanvas;
            StatusPopup.IsOpen = true;
            #endregion

        }

        private void CompletedButtonClick(object sender, RoutedEventArgs e)
        {
            #region GetGoalIndex
            int GoalInfoTextBlockIndex = 0;
            foreach (UIElement child in StatusPopupCanvas.Children)
            {
                if (child.Uid == "GoalInfoTextBlock")
                {
                    GoalInfoTextBlockIndex = StatusPopupCanvas.Children.IndexOf(child);
                }
            }

            string GoalInfo = ((TextBlock)StatusPopupCanvas.Children[GoalInfoTextBlockIndex]).Text.ToString();
            int GoalIndex = 0;
            foreach (Goal goal in CommonElements.AddedGoalsView)
            {
                if (goal.GoalInfo == GoalInfo)
                {
                    GoalIndex = CommonElements.AddedGoalsView.IndexOf(goal);
                }
            }
            #endregion

            #region AddGoal

            Goal GoalToAdd = CommonElements.AddedGoalsView[GoalIndex];
            CommonElements.CompletedGoalsView.Add(GoalToAdd);

            #endregion

            #region RemoveCompletedGoals
            CommonElements.AddedGoalsView.Remove(CommonElements.AddedGoalsView.Where(i => i.GoalInfo == GoalInfo).Single());
            StatusPopupCanvas.Children.Clear();
            StatusPopup.IsOpen = false;
            #endregion

        }

        private void ChangeAchieveByButtonClick(object sender, RoutedEventArgs e)
        {
            Calendar ChangeAchieveByCalendar = new Calendar();
            ChangeAchieveByCalendar.Uid = "ChangeAchieveByCalendar";
            ChangeAchieveByCalendar.SelectedDatesChanged += new EventHandler<SelectionChangedEventArgs>(ChangeAchieveByCalendarClick);  
            ChangeAchieveByCalendar.Margin = new Thickness(20, 20, 0, 0);
            StatusPopupCanvas.Children.Add(ChangeAchieveByCalendar);
        }

        private void DeleteGoalButtonClick(object sender, RoutedEventArgs e)
        {
            int GoalInfoTextBlockIndex = 0;
            foreach (UIElement child in StatusPopupCanvas.Children)
            {
                if (child.Uid == "GoalInfoTextBlock")
                {
                    GoalInfoTextBlockIndex = StatusPopupCanvas.Children.IndexOf(child);
                }
            }

            string GoalInfo = ((TextBlock) StatusPopupCanvas.Children[GoalInfoTextBlockIndex]).Text.ToString();
            CommonElements.AddedGoalsView.Remove(CommonElements.AddedGoalsView.Where(i => i.GoalInfo == GoalInfo).Single());
            StatusPopupCanvas.Children.Clear();
            StatusPopup.IsOpen = false;
            
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            StatusPopupCanvas.Children.Clear();
            StatusPopup.IsOpen = false;
        }

        private void ChangeAchieveByCalendarClick(object sender, RoutedEventArgs e)
        {
            #region GetGoal
            int GoalInfoTextBlockIndex = 0;
            foreach (UIElement child in StatusPopupCanvas.Children)
            {
                if (child.Uid == "GoalInfoTextBlock")
                {
                    GoalInfoTextBlockIndex = StatusPopupCanvas.Children.IndexOf(child);
                }
            }

            string GoalInfo = ((TextBlock)StatusPopupCanvas.Children[GoalInfoTextBlockIndex]).Text.ToString();
            int GoalIndex = CommonElements.AddedGoalsView.IndexOf(CommonElements.AddedGoalsView.Where(i => i.GoalInfo == GoalInfo).FirstOrDefault());
            CommonElements.AddedGoalsView[GoalIndex].AchieveBy = sender.ToString().Substring(0, 10);
            #endregion

            #region Close Calendar
            int ChangeAchieveByCalendarIndex = 0;
            foreach(UIElement child in StatusPopupCanvas.Children)
            {
                if (child.Uid == "ChangeAchieveByCalendar")
                {
                    ChangeAchieveByCalendarIndex = StatusPopupCanvas.Children.IndexOf(child);
                }
            }
            StatusPopupCanvas.Children.Remove(StatusPopupCanvas.Children[ChangeAchieveByCalendarIndex]);
            #endregion

            #region ChangeAchieveByDate

            int AchieveByTextBlockIndex = 0;
            foreach(UIElement child in StatusPopupCanvas.Children)
            {
                if (child.Uid == "AchieveByTextBlock")
                {
                    AchieveByTextBlockIndex = StatusPopupCanvas.Children.IndexOf(child);
                }
            }

            StatusPopupCanvas.Children.Remove(StatusPopupCanvas.Children[AchieveByTextBlockIndex]);
            TextBlock AchieveByTextBlock = new TextBlock();
            AchieveByTextBlock.Text = sender.ToString().Substring(0, 10);
            AchieveByTextBlock.Uid = "AchieveByTextBlock";
            AchieveByTextBlock.Margin = new Thickness(75, 35, 0, 0);
            StatusPopupCanvas.Children.Insert(AchieveByTextBlockIndex, AchieveByTextBlock);
            #endregion

            #region ChangeStatus
            int StatusTextBlockIndex = 0;
            foreach (UIElement child in StatusPopupCanvas.Children)
            {
                if (child.Uid == "StatusTextBlock")
                {
                    StatusTextBlockIndex = StatusPopupCanvas.Children.IndexOf(child);
                }
            }

            StatusPopupCanvas.Children.Remove(StatusPopupCanvas.Children[StatusTextBlockIndex]);
            DateTime NewAchieveByDate = Convert.ToDateTime(sender.ToString().Substring(0, 10));
            TextBlock StatusTextBlock = new TextBlock();
            StatusTextBlock.Text = FormatStatusPopup(NewAchieveByDate)[0].ToString();
            StatusTextBlock.Uid = "StatusTextBlock";
            StatusTextBlock.Margin = new Thickness(75, 65, 0, 0);
            StatusPopupCanvas.Children.Insert(StatusTextBlockIndex, StatusTextBlock);
                
            StatusPopupCanvas.Background = (Brush)FormatStatusPopup(NewAchieveByDate)[1];
            #endregion

            GoalsTable.Items.Refresh();
        }

        private void ViewCompletedGoals(object sender, RoutedEventArgs e)
        {
            ViewCompletedGoalsPopup.IsOpen = true;
        }

        private void CloseCompletedGoalsPopup(object sender, RoutedEventArgs e)
        {
            ViewCompletedGoalsPopup.IsOpen = false;
        }

        private object[] FormatStatusPopup(DateTime date)
        {
            if (date > OneWeekAway)
            {
                Status = "You've got time!";
                StatusPopupCanvas.Background = new SolidColorBrush(Color.FromRgb(117, 219, 182));
                StatusPopupCanvas.Background.Opacity = 0.75;

            }
            else if (date > Today && date < OneWeekAway)
            {
                Status = "You're getting close!";
                StatusPopupCanvas.Background = new SolidColorBrush(Color.FromRgb(216, 135, 72));
                StatusPopupCanvas.Background.Opacity = 0.75;

            }
            else if (date < Today)
            {
                Status = "You're late!";
                StatusPopupCanvas.Background = new SolidColorBrush(Color.FromRgb(243, 70, 70));
                StatusPopupCanvas.Background.Opacity = 0.75;

            }

            
            return new object[] { Status, StatusPopupCanvas.Background };
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
    }
}
