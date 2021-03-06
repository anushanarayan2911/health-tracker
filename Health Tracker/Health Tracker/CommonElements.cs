using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Health_Tracker
{
    public class CommonElements
    {
        public static ObservableCollection<Exercise> AddedExercisesView = new ObservableCollection<Exercise>();
        public static ObservableCollection<Meal> AddedMealsView = new ObservableCollection<Meal>();
        public static ObservableCollection<Goal> AddedGoalsView = new ObservableCollection<Goal>();
        public static ObservableCollection<Goal> CompletedGoalsView = new ObservableCollection<Goal>();

        public static void goBack()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
