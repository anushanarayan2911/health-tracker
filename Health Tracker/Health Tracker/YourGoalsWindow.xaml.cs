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
    public partial class YourGoalsWindow : Window
    {
        string GoalInfo;
        string AchieveBy;
        string Status;
        DateTime Today;

        public YourGoalsWindow()
        {
            InitializeComponent();

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

            int NumOfRows = CommonElements.AddedGoalsView.Count;

            StatusCol.Height = NumOfRows * 19;

            for (int i = 0; i < NumOfRows; i++)
            {
                StatusCol.RowDefinitions.Add(new RowDefinition());
            }

            for (int j = 0; j < StatusCol.RowDefinitions.Count; j++)
            {
                StatusCol.RowDefinitions[j].Height = new GridLength(19);

                Button b = new Button();
                b.Click += new RoutedEventHandler(StatusButtonClick);
                b.Height = 19;
                b.Margin = new Thickness(0, 0, 0, 0);
                b.BorderThickness = new Thickness(0);
                Grid.SetColumn(b, 0);
                Grid.SetRow(b, j);
                StatusCol.Children.Add(b);
            }
            
        }

        private void StatusButtonClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
