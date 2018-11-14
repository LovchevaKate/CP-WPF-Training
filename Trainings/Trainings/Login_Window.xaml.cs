using System;
using System.Windows;
using System.Windows.Controls;
using Trainings.Model;

namespace Trainings
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }
        
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Window_Model.Open_Registration_Window(this);
        }
        
        private void Input_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Login.Text) && !string.IsNullOrEmpty(PasswordBox.Password) &&
                    !string.IsNullOrWhiteSpace(Login.Text) && !string.IsNullOrWhiteSpace(PasswordBox.Password))
                {
                    string _login = Login.Text;
                    string _password = PasswordBox.Password.GetHashCode().ToString();
                    bool b = Window_Model.Input(_login, _password, this);
                    if(!b)
                    {
                        Login.Clear();
                        PasswordBox.Clear();
                    }
                }
                else
                {
                    throw new Exception("Поля не заполнены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyWorkClass.Create_Trener();
        }
    }
}




