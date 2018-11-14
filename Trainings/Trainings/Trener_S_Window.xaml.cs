using System;
using System.Windows;
using System.Windows.Controls;
using Trainings.Model;

namespace Trainings
{
    public partial class Trener_S_Window : Window
    {        
        public Trener_S_Window()
        {
            InitializeComponent();
               
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Name.Text = MyWorkClass.Sportsman.Name;
            Sname.Text = MyWorkClass.Sportsman.Sname;
            Age.Text = MyWorkClass.Sportsman.Age.ToString();
            Telephone.Text = MyWorkClass.Sportsman.Telephone;
            Gender.Text = MyWorkClass.Sportsman.Gender;
            Height.Text = MyWorkClass.Sportsman.Info.Height;
            Weight.Text = MyWorkClass.Sportsman.Info.Weight;
            Body_Parametrs.Text = MyWorkClass.Sportsman.Info.Body_Parametrs;
            HistoryParam.AppendText(MyWorkClass.ReadFromFile(MyWorkClass.Sportsman));
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime date = Date.SelectedDate.Value;
                if (date > DateTime.Today.Date)
                {
                    throw new Exception("Нельзя просмотреть питание для выбранной даты.");
                }
                else
                {
                    EatingDataGrid.ItemsSource = MyWorkClass.RenewEatingTrener(date, MyWorkClass.Sportsman);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TrenerWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Trener_Window trener_Window = new Trener_Window();
            trener_Window.Show();
            MyWorkClass.Sportsman = null;
            Close();
        }
    }
}


