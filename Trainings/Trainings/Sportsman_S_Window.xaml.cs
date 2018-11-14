using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Trainings.Context;
using Trainings.Entity;
using Trainings.Model;

namespace Trainings
{
    public partial class Sportsman_S_Window : Window
    {    
        public Sportsman_S_Window()
        {
            InitializeComponent();
        }

        SportsmanEating eat = new SportsmanEating();

        private void UpdateSportsmanInfoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SportsmanInfo info = new SportsmanInfo();
                if (!string.IsNullOrEmpty(Height1.Text) && !string.IsNullOrEmpty(Weight.Text) &&
                    !string.IsNullOrEmpty(Body_Parametrs.Text))
                {
                    info.Id = MyWorkClass.Sportsman.Id;

                    if (Convert.ToInt32(Height1.Text) < 100 || Convert.ToInt32(Height1.Text) > 210)                        
                    {
                        Height1.Clear();
                        throw new Exception("Неверные параметры роста.");                        
                    }

                    else if (Convert.ToInt32(Weight.Text) < 30 || Convert.ToInt32(Weight.Text) > 150)
                    {
                        Weight.Clear();
                        throw new Exception("Неверные параметры веса.");
                    }                    
                    else
                    {
                        info.Height = Height1.Text;
                        info.Weight = Weight.Text;
                    }
                    info.Body_Parametrs = Body_Parametrs.Text;
                    SportsmanInfo s = MyWorkClass.Param(info, MyWorkClass.Sportsman);
                    TextBlock_Height.Text = s.Height;
                    TextBlock_Weight.Text = s.Weight;
                    TextBlock_Body_Parametrs.Text = s.Body_Parametrs;
                    Height1.Clear();
                    Weight.Clear();
                    Body_Parametrs.Clear();
                    HistoryParam.Document.Blocks.Clear();
                    HistoryParam.AppendText(MyWorkClass.ReadFromFile(MyWorkClass.Sportsman));
                }
                else
                {
                    throw new Exception("Поля (Рост, Вес, Параметры) не заполнены!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBlock_Height.Text = MyWorkClass.Sportsman.Info.Height;
                TextBlock_Weight.Text = MyWorkClass.Sportsman.Info.Weight;
                TextBlock_Body_Parametrs.Text = MyWorkClass.Sportsman.Info.Body_Parametrs;
                EatingDataGrid.ItemsSource = MyWorkClass.RenewEating();
                HistoryParam.AppendText(MyWorkClass.ReadFromFile(MyWorkClass.Sportsman));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SportsmanWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Sportsman_Window sportsman_Window = new Sportsman_Window();
            sportsman_Window.Show();
            Close();
        }

        private void CreateSportsmanEatingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                if (!string.IsNullOrEmpty(breakfasttextbox.Text) && !string.IsNullOrEmpty(lunchtextbox.Text) &&
                    !string.IsNullOrEmpty(dinnertextbox.Text))
                {
                    SportsmanEating eating = new SportsmanEating
                    {
                        Id_Sportsman = MyWorkClass.Sportsman.Id,
                        Date = DateTime.Today.Date,
                        Breakfast = breakfasttextbox.Text,
                        Lunch = lunchtextbox.Text,
                        Dinner = dinnertextbox.Text
                    };
                    MyWorkClass.Eating(eating);

                    EatingDataGrid.ItemsSource = MyWorkClass.RenewEating();
                    breakfasttextbox.Clear();
                    lunchtextbox.Clear();
                    dinnertextbox.Clear();
                }
                else
                {
                    throw new Exception("Поля не заполнены!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }       

        private void DeleteSportsmanEatingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                if (eat.Id!= 0)
                {
                    using (var work = new UnitofWork())
                    {
                        work.SportsmanEatingRepository.Delete(eat.Id);                       
                        work.SportsmanEatingRepository.Save();
                    }
                    EatingDataGrid.ItemsSource = MyWorkClass.RenewEating();
                }
                else
                {
                    throw new Exception("Элемент не выбран!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EatingDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                eat = EatingDataGrid.SelectedItem as SportsmanEating;
                if(eat==null)
                {
                    throw new Exception("Позиция не выбрана.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!(Regex.IsMatch(Height1.Text, @"^\d*$")) || !(Regex.IsMatch(Weight.Text, @"^\d*$")))
                {
                    throw new Exception("Error!!! Неправильные символы");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

