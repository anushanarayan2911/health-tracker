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
        string GoalInfo;
        string AchieveBy;
        string Status;
        DateTime Today;
        DateTime OneWeekAway;
        UIElement[] StatusButtonArray = new Button[30];

        public YourGoalsWindow()
        {
            InitializeComponent();
            Today = DateTime.Now;
            OneWeekAway = Today.AddDays(+7);

            GoalsTable.ItemsSource = CommonElements.AddedGoalsView;
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
            Goal selectedRow = button.DataContext as Goal;

            string a = selectedRow.GoalInfo.ToString();
            test.Text = a;
        }
    }
}
