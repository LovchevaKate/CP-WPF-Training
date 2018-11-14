using System.Windows;
using Trainings.Model;

namespace Trainings
{
    public partial class Sportsman_Window : Window
    {
        public Sportsman_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TrainingsDataGrid.ItemsSource = MyWorkClass.RenewTrainingSport();
        }

        private void Open_Sportsman_S_WindowButton_Click(object sender, RoutedEventArgs e)
        {
            Window_Model.Open_Sportsman_S_Window(this);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            MyWorkClass.Sportsman = null;
            Close();
        }
    }
}


