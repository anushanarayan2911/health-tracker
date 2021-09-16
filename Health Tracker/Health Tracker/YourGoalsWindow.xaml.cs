﻿using System;
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
        string GoalInfo;
        string AchieveBy;
        string Status;
        DateTime Today;
        DateTime OneWeekAway;
        Canvas StatusPopupCanvas = new Canvas();

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
        }

        private void StatusButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Goal SelectedRow = button.DataContext as Goal;

            string GoalInfo = SelectedRow.GoalInfo.ToString();
            DateTime AchieveBy = Convert.ToDateTime(SelectedRow.AchieveBy.ToString());
            string Status = FormatStatusPopup(AchieveBy)[0].ToString();
            StatusPopupCanvas.Background = (Brush) FormatStatusPopup(AchieveBy)[1];

            #region AddElementsToStatusPopup
            TextBlock GoalInfoTextBlock = new TextBlock();
            GoalInfoTextBlock.Text = GoalInfo;
            GoalInfoTextBlock.TextDecorations = TextDecorations.Underline;
            GoalInfoTextBlock.Margin = new Thickness(150, 0, 0, 0);
            GoalInfoTextBlock.Uid = "GoalInfoTextBlock";
            StatusPopupCanvas.Children.Add(GoalInfoTextBlock);

            Label AchieveByLabel = new Label();
            AchieveByLabel.Content = "Achieve By: ";
            AchieveByLabel.Margin = new Thickness(0, 30, 0, 0);
            StatusPopupCanvas.Children.Add(AchieveByLabel);

            TextBlock AchieveByTextBlock = new TextBlock();
            AchieveByTextBlock.Text = AchieveBy.ToString();
            AchieveByTextBlock.Uid = "AchieveByTextBlock";
            AchieveByTextBlock.Margin = new Thickness(75, 35, 0, 0);
            StatusPopupCanvas.Children.Add(AchieveByTextBlock);

            Label StatusLabel = new Label();
            StatusLabel.Content = "Status";
            StatusLabel.Margin = new Thickness(0, 60, 0, 0);
            StatusPopupCanvas.Children.Add(StatusLabel);

            TextBlock StatusTextBlock = new TextBlock();
            StatusTextBlock.Text = Status;
            StatusTextBlock.Margin = new Thickness(75, 65, 0, 0);
            StatusTextBlock.Uid = "StatusTextBlock";
            StatusPopupCanvas.Children.Add(StatusTextBlock);

            Button CompletedButton = new Button();
            CompletedButton.Content = "Complete";
            CompletedButton.Click += new RoutedEventHandler(CompletedButtonClick);
            CompletedButton.Height = 30;
            CompletedButton.Width = 70;
            CompletedButton.Margin = new Thickness(0, 120, 0, 0);
            StatusPopupCanvas.Children.Add(CompletedButton);

            Button ChangeAchieveByButton = new Button();
            ChangeAchieveByButton.Content = "Change Achieve By";
            ChangeAchieveByButton.Click += new RoutedEventHandler(ChangeAchieveByButtonClick);
            ChangeAchieveByButton.Height = 30;
            ChangeAchieveByButton.Width = 120;
            ChangeAchieveByButton.Margin = new Thickness(100, 120, 0, 0);
            StatusPopupCanvas.Children.Add(ChangeAchieveByButton);

            Button DeleteGoalButton = new Button();
            DeleteGoalButton.Content = "Delete";
            DeleteGoalButton.Click += new RoutedEventHandler(DeleteGoalButtonClick);
            DeleteGoalButton.Height = 30;
            DeleteGoalButton.Width = 50;
            DeleteGoalButton.Margin = new Thickness(250, 120, 0, 0);
            StatusPopupCanvas.Children.Add(DeleteGoalButton);

            Button ExitButton = new Button();
            ExitButton.Content = "X";
            ExitButton.Click += new RoutedEventHandler(ExitButtonClick);
            ExitButton.Height = 30;
            ExitButton.Width = 15;
            ExitButton.Margin = new Thickness(285, 0, 0, 0);
            StatusPopupCanvas.Children.Add(ExitButton);

            #endregion
            StatusPopup.Child = StatusPopupCanvas;
            StatusPopup.IsOpen = true;
        }

        private void CompletedButtonClick(object sender, RoutedEventArgs e)
        {
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

            Goal GoalToAdd = CommonElements.AddedGoalsView[GoalIndex];
            CommonElements.CompletedGoalsView.Add(GoalToAdd);

            CommonElements.AddedGoalsView.Remove(CommonElements.AddedGoalsView.Where(i => i.GoalInfo == GoalInfo).Single());
            StatusPopupCanvas.Children.Clear();
            StatusPopup.IsOpen = false;
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

            int ChangeAchieveByCalendarIndex = 0;
            foreach(UIElement child in StatusPopupCanvas.Children)
            {
                if (child.Uid == "ChangeAchieveByCalendar")
                {
                    ChangeAchieveByCalendarIndex = StatusPopupCanvas.Children.IndexOf(child);
                }
            }
            StatusPopupCanvas.Children.Remove(StatusPopupCanvas.Children[ChangeAchieveByCalendarIndex]);

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
                StatusPopupCanvas.Background = Brushes.Green;

            }
            else if (date > Today && date < OneWeekAway)
            {
                Status = "You're getting close!";
                StatusPopupCanvas.Background = Brushes.Orange;

            }
            else if (date < Today)
            {
                Status = "You're late!";
                StatusPopupCanvas.Background = Brushes.Red;

            }

            
            return new object[] { Status, StatusPopupCanvas.Background };
        }
    }
}
