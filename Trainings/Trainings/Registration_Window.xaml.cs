using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Trainings.Entity;
using Trainings.Model;

namespace Trainings
{
    public partial class Registration_Window : Window
    {
        public Registration_Window()
        {
            InitializeComponent();
        }

        Sportsman sportsman = new Sportsman();
        SportsmanInfo info = new SportsmanInfo();

        private void Button_create_user_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Login_reg.Text) && !string.IsNullOrEmpty(Password_reg.Password) &&
                    !string.IsNullOrEmpty(Password2_reg.Password) && !string.IsNullOrEmpty(Sname_reg.Text) &&
                    !string.IsNullOrEmpty(Name_reg.Text) && !string.IsNullOrEmpty(Telephon_reg.Text) &&
                    !string.IsNullOrEmpty(Age_reg.Text))
                {
                    sportsman.Login = Login_reg.Text;
                    sportsman.Password = Password_reg.Password.GetHashCode().ToString();
                    string password2 = Password2_reg.Password.GetHashCode().ToString();
                    sportsman.Name = Name_reg.Text;
                    sportsman.Sname = Sname_reg.Text;
                    sportsman.Telephone = Telephon_reg.Text;
                    if(sportsman.Gender == null)
                    {
                        throw new Exception("Пол не выбран.");
                    }
                    if (Convert.ToInt32(Age_reg.Text) < 10 || Convert.ToInt32(Age_reg.Text) > 90)
                    {
                        Age_reg.Clear();
                        throw new Exception("Неверно заполнено поле ВОЗРАСТ.");
                    }
                    else
                    {
                        sportsman.Age = Convert.ToInt32(Age_reg.Text);
                    }

                    if (Convert.ToInt32(Height_reg.Text) < 100 || Convert.ToInt32(Height_reg.Text) > 210)
                    {
                        Height_reg.Clear();
                        throw new Exception("Неверные параметры роста.");
                    }

                    else if (Convert.ToInt32(Weight_reg.Text) < 30 || Convert.ToInt32(Weight_reg.Text) > 150)
                    {
                        Weight_reg.Clear();
                        throw new Exception("Неверные параметры веса.");
                    }
                    else
                    {
                        info.Height = Height_reg.Text;
                        info.Weight = Weight_reg.Text;
                    }

                    info.Body_Parametrs = Param_reg.Text;

                    if (MyWorkClass.Registration_Create(sportsman, password2, info))
                        Window_Model.Close_Registration_Window(this);
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

        private void Number_reg_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!(Regex.IsMatch(Age_reg.Text, @"^\d*$")))
                {
                    Age_reg.Clear();
                    throw new Exception("Error!!! Неправильные символы");                    
                }
                else if(!(Regex.IsMatch(Height_reg.Text, @"^\d*$")))
                {
                    Height_reg.Clear();
                    throw new Exception("Error!!! Неправильные символы");
                }
                else if (!(Regex.IsMatch(Weight_reg.Text, @"^\d*$")))
                {
                    Weight_reg.Clear();
                    throw new Exception("Error!!! Неправильные символы");
                }

                else if(!(Regex.IsMatch(Telephon_reg.Text, @"^\d*$")))
                {
                    Telephon_reg.Clear();
                    throw new Exception("Error!!! Неправильные символы");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void String_reg_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!(Regex.IsMatch(Name_reg.Text, @"^[а-яА-ЯёЁa-zA-Z]*$")) || !(Regex.IsMatch(Sname_reg.Text, @"^[а-яА-ЯёЁa-zA-Z]*$")))
                {
                    throw new Exception("Error!!! Неправильные символы");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RadioButton_man_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            sportsman.Gender = "м";
        }

        private void RadioButton_woman_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            sportsman.Gender = "ж";
        }

        private void Param_reg_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // if (!(Regex.IsMatch(Param_reg.Text, @"^[0-9]{1,3}[/][0-9]{1,3}[/][0-9]{1,3}\z")))
                if (!(Regex.IsMatch(Param_reg.Text, @"/^[0-9]{2,3}[{1}[0-9]{2,3}[{1}[0-9]{2,3}$/")))

                {
                    Param_reg.Clear();
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



