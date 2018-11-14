using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Trainings.Context;
using Trainings.Entity;

namespace Trainings.Model
{
    public static class MyWorkClass
    {
        public static Sportsman Sportsman;
        public static Trener Trener;
        public static SportsmanInfo Info;
        public static Training Training;

        public static bool IsExistUser(Sportsman sportsman)
        {
            bool flag = false;
            if (sportsman.Password != null && sportsman.Login != null)
            {
                using (var unitofwork = new UnitofWork())
                {
                    var sport = unitofwork.SportsmanRepository.GetEntities();
                    foreach (var s in sport)
                    {
                        if (s.Login == sportsman.Login && s.Password == sportsman.Password)
                        {
                            flag = true;
                            Sportsman = s;
                        }
                    }
                }
            }
            return flag;
        }

        public static async void Create_Trener()
        {
            try
            {
                using (UnitofWork work = new UnitofWork())
                {
                    Trener tempTrener = new Trener();
                    await new Task(() => tempTrener = work.TrenerRepository.GetEntity(1));

                    if (tempTrener == null)
                    {
                        Trener trener = new Trener()
                        {
                            Id = 1,
                            Login = "trener",
                            Password = "trener",
                            FIO = "Ivanov Ivan"
                        };

                        trener.Password.GetHashCode().ToString();
                        work.TrenerRepository.Create(trener);
                        work.TrenerRepository.Save();
                        Trener = trener;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool Registration_Create(Sportsman sportsman, string password2, SportsmanInfo info)
        {
            bool flag = false;
            try
            {
                Sportsman sport = new Sportsman();
                SportsmanInfo i = new SportsmanInfo();
                if (sportsman.Password == password2)
                {
                    using (UnitofWork work = new UnitofWork())
                    {
                        sport = sportsman;
                        var s = work.SportsmanRepository.GetEntities();
                        foreach (var a in s)
                        {
                            if (a.Login == sport.Login)
                            {
                                flag = true;
                                throw new Exception("Логин уже используется.");
                            }
                        }
                        if (sport.Login != "trener" && !flag)
                        {
                            work.SportsmanRepository.Create(sport);
                            work.SportsmanRepository.Save();
                        }
                        else
                        {
                            throw new Exception("Нельзя использовать логин: trener");
                        }

                    }
                    using (UnitofWork work = new UnitofWork())
                    {
                        i = info;
                        i.Id = sport.Id;
                        work.Sportsman_InfoRepository.Create(i);
                        work.Sportsman_InfoRepository.Save();

                    }
                    CreateFile(info, sport);
                }
                else
                {
                    throw new Exception("Пароли не совпадают.");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static void CreateFile(SportsmanInfo info, Sportsman sport)
        {
            string path = @"...\...\Info\" + sport.Id + "_" + sport.Sname + "_" + sport.Name + "_info.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Дата " + DateTime.Today.Day + " / " + DateTime.Today.Month + " / " + DateTime.Today.Year);
                    sw.WriteLine("Рост:" + info.Height);
                    sw.WriteLine("Вес: " + info.Weight);
                    sw.WriteLine("Параметры: " + info.Body_Parametrs);
                    sw.WriteLine();
                    sw.WriteLine();
                }
            }
        }

        public static List<Training> RenewTraining()
        {
            using (var unitofwork = new UnitofWork())
            {
                List<Training> result = new List<Training>();
                var training = unitofwork.TrainingRepository.GetEntities();
                foreach (var s in training)
                {
                    result.Add(s);
                }
                return result;
            }
        }

        public static List<Training> RenewTrainingSport()
        {
            using (var unitofwork = new UnitofWork())
            {
                List<Training> result = new List<Training>();
                var training = unitofwork.TrainingRepository.GetEntities();
                foreach (var s in training)
                {
                    if (s.Id_Sportsman == Sportsman.Id)
                        result.Add(s);
                }
                return result;
            }
        }

        public static List<Sportsman> RenewSportsman()
        {
            using (var unitofwork = new UnitofWork())
            {
                List<Sportsman> result = new List<Sportsman>();
                var sportsman = unitofwork.SportsmanRepository.GetEntities();
                foreach (var s in sportsman)
                {
                    result.Add(s);
                }
                return result;
            }
        }

        public static string CalendarValue(DateTime dateTime)
        {
            try
            {
                if (dateTime > DateTime.Today.Date)
                {
                    return dateTime.Date.Day.ToString() + "/" + dateTime.Date.Month.ToString();
                }
                else
                {
                    throw new Exception("Неверная дата!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DateTime.Today.Date.Day.ToString() + "/" + DateTime.Today.Date.Month.ToString();
            }
        }

        public static void CreateTraining(Training training)
        {
            try
            {
                using (var work = new UnitofWork())
                {
                    bool l = false;
                    var i = work.SportsmanRepository.GetEntities();
                    var t = work.TrainingRepository.GetEntities();

                    foreach (var r in t)
                    {
                        if (training.Date == r.Date)
                        {
                            throw new Exception("В этот день уже есть тренировка.");
                        }
                    }

                    foreach (var q in i)
                    {
                        if (training.Id_Sportsman == q.Id)
                        { l = true; }
                    }
                    if (l)
                    {
                        work.TrainingRepository.Create(training);
                        work.TrainingRepository.Save();
                    }
                    else throw new Exception("Спортсмен не найден!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteTraining(int i)
        {
            try
            {
                bool f = false;
                using (var work = new UnitofWork())
                {
                    var r = work.TrainingRepository.GetEntities();
                    foreach (var t in r)
                    {
                        if (i == t.Id)
                            f = true;
                    }
                    if (f)
                    {
                        work.TrainingRepository.Delete(i);
                        work.TrainingRepository.Save();
                    }
                    else throw new Exception("Id тренировки не найдено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteSportsman()
        {
            try
            {
                using (var work = new UnitofWork())
                {
                    work.SportsmanRepository.Delete(Sportsman.Id);
                    work.SportsmanEatingRepository.Delete(Sportsman.Id);
                    work.Sportsman_InfoRepository.Delete(Sportsman.Id);
                    work.Sportsman_InfoRepository.Save();
                    work.SportsmanEatingRepository.Save();
                    work.SportsmanRepository.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteSportsman(int i)
        {
            using (var work = new UnitofWork())
            {
                work.SportsmanRepository.Delete(i);
                work.SportsmanEatingRepository.Delete(i);
                work.SportsmanEatingRepository.Save();
                work.SportsmanRepository.Save();
            }
        }

        public static SportsmanInfo Param(SportsmanInfo si, Sportsman sport)
        {
            SportsmanInfo info;
            using (UnitofWork work = new UnitofWork())
            {
                work.Sportsman_InfoRepository.Update(si);
                work.Sportsman_InfoRepository.Save();
                info = work.Sportsman_InfoRepository.GetEntity(si.Id);
            }
            string path = @"...\...\Info\" + sport.Id + "_" + sport.Sname + "_" + sport.Name + "_info.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Дата " + DateTime.Today.Day + " / " + DateTime.Today.Month + " / " + DateTime.Today.Year);
                sw.WriteLine("Рост:" + info.Height);
                sw.WriteLine("Вес: " + info.Weight);
                sw.WriteLine("Параметры: " + info.Body_Parametrs);
                sw.WriteLine();
                sw.WriteLine();
            }
            return info;
        }

        public static string ReadFromFile(Sportsman sport)
        {
            try
            {
                StreamReader file = new StreamReader(@"...\...\Info\" + sport.Id + "_" + sport.Sname + "_" + sport.Name + "_info.txt");
                string text = file.ReadToEnd();
                file.Close();
                return text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void Eating (SportsmanEating eating)
        {
            using (UnitofWork work = new UnitofWork())
            {                
                work.SportsmanEatingRepository.Create(eating);
                work.Sportsman_InfoRepository.Save();
            }
        }

        public static List<SportsmanEating> RenewEating()
        {
            using (var unitofwork = new UnitofWork())
            {
                List<SportsmanEating> result = new List<SportsmanEating>();
                var eating = unitofwork.SportsmanEatingRepository.GetEntities();
                foreach (var e in eating)
                {
                    if (e.Id_Sportsman == Sportsman.Id)
                        result.Add(e);
                }
                return result;
            }
        }

        public static List<SportsmanEating> RenewEatingTrener(DateTime date, Sportsman s)
        {
            try
            {
                using (var unitofwork = new UnitofWork())
                {
                    List<SportsmanEating> result = new List<SportsmanEating>();
                    var eating = unitofwork.SportsmanEatingRepository.GetEntities();
                    foreach (var e in eating)
                    {
                        if (e.Date == date && e.Id_Sportsman == s.Id)
                            result.Add(e);
                    }
                    return result;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        } 
    }
}
