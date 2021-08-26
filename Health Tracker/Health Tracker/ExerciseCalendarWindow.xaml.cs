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
    public partial class ExerciseCalendarWindow : Window
    {
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
        IDictionary<string, string> monthNumbers = new Dictionary<string, string>()
        {
            {"01", "January" },
            {"02", "February" },
            {"03", "March"},
            {"04", "April" },
            {"05" , "May" },
            {"06" , "June" },
            {"07" , "July" },
            {"08" , "August" },
            {"09" , "September" },
            {"10" , "October" },
            {"11" , "November" },
            {"12" , "December" }
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

        public ExerciseCalendarWindow()
        {
            InitializeComponent();

            DateTime Now = DateTime.Now;
            string Today = Now.ToString();
            int index = Today.ToString().IndexOf(" ");
            Today = Today.Substring(0, index);

            string currentDay = Now.DayOfWeek.ToString();
            string currentDayNumber = dayNumbers[currentDay].ToString();

            string currentDate = Today.Substring(0, Today.IndexOf("/"));

            string currentMonthNumber = Now.Month.ToString("00");
            string currentMonth = monthNumbers[currentMonthNumber].ToString();
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
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                    CalendarGrid.Children.Add(b);
                }
            }

            foreach (Button ui in CalendarGrid.Children)
            {
                calendarButtonArray[Array.IndexOf(calendarButtonArray, null)] = ui;
            }

            int dateToAdd = 1;
            for (int i = dayOfFirstNumber; i < dayOfFirstNumber + numberOfDays; i++)
            {
                calendarButtonArray[i].Content = dateToAdd.ToString();
                dateToAdd += 1;
            };
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            CommonElements.goBack();
        }
    }
}
