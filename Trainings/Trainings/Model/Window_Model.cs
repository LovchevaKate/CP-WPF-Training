using System;
using System.Windows;
using Trainings.Context;
using Trainings.Entity;

namespace Trainings.Model
{
    public static class Window_Model
    {
        public static bool Input(string _login, string _password, MainWindow window)
        {
            bool b = true;
            string pass = "trener";
            try
            {                
                if (_login == "trener" && pass.GetHashCode().ToString()==_password)
                {
                    using (var unitofwork = new UnitofWork())
                    {
                        Trener trener = unitofwork.TrenerRepository.GetEntity(1);
                        MyWorkClass.Trener = trener;

                        if (trener.Login == _login && trener.Password.GetHashCode().ToString() == _password)
                        {
                            Trener_Window trener_Window = new Trener_Window();
                            trener_Window.Show();
                            window.Close();
                        }
                        else
                        {
                            throw new Exception("Тренер не создан");
                        }
                    }
                }
                else
                {
                    Sportsman sportsman = new Sportsman() { Login = _login, Password = _password };

                    bool flag = MyWorkClass.IsExistUser(sportsman);
                    if (flag)
                    {
                        Sportsman_Window sportsman_Window = new Sportsman_Window();
                        sportsman_Window.Show();
                        window.Close();
                    }
                    else
                    {
                        b = false;
                        throw new Exception("Неверный логин или пароль.");
                    }                   
                }
                return b;
            }
            catch (Exception ex)
            {
                b = false;
                MessageBox.Show(ex.Message);
                return b;
            }
        }

        public static void Open_Registration_Window(MainWindow window)
        {
            Registration_Window registration_window = new Registration_Window();
            registration_window.Show();
            window.Close();
        }

        public static void Close_Registration_Window(Registration_Window window)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            window.Close();
        }

        public static void Open_Sportsman_S_Window(Sportsman_Window window)
        {
            Sportsman_S_Window sportsman_s_window = new Sportsman_S_Window();
            sportsman_s_window.Show();
            window.Close();
        }
    }
}
