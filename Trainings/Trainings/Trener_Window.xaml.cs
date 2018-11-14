using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Trainings.Entity;
using Trainings.Model;

namespace Trainings
{
    public partial class Trener_Window : Window
    {
        public Trener_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SportsmanDataGrid.ItemsSource = MyWorkClass.RenewSportsman();
            TrainingsDataGrid.ItemsSource = MyWorkClass.RenewTraining();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime selectedDate = calendar.SelectedDate.Value;
                if (selectedDate < DateTime.Today.Date)
                {
                    throw new Exception("Неверная дата");
                   
                }
                else if(selectedDate==DateTime.Today.Date)
                {
                    throw new Exception("На сегодня тренировку нельзя поставить!");
                }
                else
                {
                    DateAdd.Text = MyWorkClass.CalendarValue(selectedDate);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(DateAdd.Text) && !string.IsNullOrEmpty(IdAdd.Text))
                {
                    Training trainingentity = new Training
                    {
                        Date = Convert.ToDateTime(DateAdd.Text),
                        Id_Sportsman = Convert.ToInt32(IdAdd.Text),
                        Id_Trener = MyWorkClass.Trener.Id
                    };

                    MyWorkClass.CreateTraining(trainingentity);

                    TrainingsDataGrid.ItemsSource = MyWorkClass.RenewTraining();
                    DateAdd.Clear();
                    IdAdd.Clear();
                }
                else
                {
                    throw new Exception("Поля Id Спортсмена и Дата не заполнены!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DateAdd.Clear();
                IdAdd.Clear();
            }
        }

        private void SportsmanDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MyWorkClass.Sportsman = SportsmanDataGrid.SelectedItem as Sportsman;
                if (MyWorkClass.Sportsman == null)
                {
                    throw new Exception("Спортсмен не выбран.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InfoSportsmanButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MyWorkClass.Sportsman != null)
                {
                    Trener_S_Window window = new Trener_S_Window();
                    window.Show();
                    Close();
                }
                else
                {
                    throw new Exception("Спортсмен не выбран!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MyWorkClass.Training!=null)
                {
                    MyWorkClass.DeleteTraining(MyWorkClass.Training.Id);
                    TrainingsDataGrid.ItemsSource = MyWorkClass.RenewTraining();
                }
                else
                {
                    throw new Exception("Тренировка для удаления не выбрана.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteSportsmanButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MyWorkClass.Sportsman!= null)
                {
                    MyWorkClass.DeleteSportsman();                    
                    TrainingsDataGrid.ItemsSource = MyWorkClass.RenewTraining();
                    SportsmanDataGrid.ItemsSource = MyWorkClass.RenewSportsman();
                    MyWorkClass.Sportsman = null;
                }
                else
                {
                    throw new Exception("Спортсмен не выбран!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            Close();
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!(Regex.IsMatch(IdAdd.Text, @"^\d*$")))
                {                   
                    throw new Exception("Error!!! Неправильные символы");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TrainingsDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MyWorkClass.Training = TrainingsDataGrid.SelectedItem as Training;
                if (MyWorkClass.Training == null)
                {
                    throw new Exception("Тренировка не выбрана.");
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


