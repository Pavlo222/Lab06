using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;

namespace Lab06_2
{
    interface Stop
    {
        void EditDate(List<Hour> Date);
        void DelDate(List<Hour> Date);
    }
    abstract public class TramvayStop: Stop
    {
        public string Name { get; set; }
        public string ListNumberRoute { get; set; }
        
        public void DelDate(List<Hour> Date)
        {
            Console.Clear();
            Hour hour = new Hour();
            ShowTable(Date);
            Console.WriteLine("Введiть порятковий номер поля якого ви хочете видалити: ");
            int Num = Convert.ToInt32(Console.ReadLine());
            int hj = 0;

            foreach (Hour g in Date)
            {
                hj++;
                if (hj == Num)
                {
                    hour = g;
                }
            }
            if (hour.Name != "")
            {
                Console.WriteLine();
                Date.Remove(hour);
            }
        }
        public void EditDate(List<Hour> Date)
        {
            Console.Clear();
            Hour.ShowTable(Date);
            Console.WriteLine("Введiть порятковий номер поля якого ви хочете редагувати: ");
            int Nam = Convert.ToInt32(Console.ReadLine());
            Hour Choosen = new Hour();
            Choosen.Name = "";
            int ij = 0;
            foreach (Hour g in Date)
            {
                ij++;
                if (ij == Nam)
                {
                    Choosen = g;
                    break;
                }
            }
            if (Choosen.Name != "")
            {
                Console.WriteLine();
                Console.WriteLine("1)Редагування назви\n2)Редагування списка номерiв маршрутiв\n3)Редагування кiлькiстi пасажирiв\n4)Редагування коментарiв");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine("\nВведiть нове значення:");
                try
                {
                    if (key == '1')
                    {
                        Choosen.Name = Console.ReadLine();
                    }
                    if (key == '2')
                    {

                        Choosen.ListNumberRoute = Console.ReadLine();
                    }
                    if (key == '3')
                    {
                        Choosen.NumberPassegers = Convert.ToInt32(Console.ReadLine());

                    }
                    if (key == '4')
                    {
                        Choosen.Comentar = Console.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine("Нове значення задано не коректно");
                }

            }
            else
            {
                Console.WriteLine("Не має.");
            }

        }
        public static string PS(int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s += " ";
            }
            return s;
        }
        public static void AddNew(List<Hour> Date)
        {
            Console.Clear();
            Console.WriteLine("Режим додавання: ");
            Hour neww = new Hour();
            Console.WriteLine("Введiть назву: ");
            neww.Name = Console.ReadLine();
            Console.WriteLine("Введiть список номерiв маршрутiв: ");
            neww.ListNumberRoute = Console.ReadLine();
            Console.WriteLine("Введiть кiлькiсть пасажирiв");
            neww.NumberPassegers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть коментар");
            neww.Comentar = Console.ReadLine();
            Date.Add(neww);
        }
        public static void ShowTable(List<Hour> Hour)
        {
            Console.Clear();
            int MaxLNR = 26;
            int MaxN = 12;
            int MaxNP = 21;
            int MaxC = 30;
            int nom = 0;
            Console.WriteLine("|   №  |   Назва    | Список номерiв маршрутiв | Кiлькiсть пасажирiв |           Коментар           |");//дністровська| 15,43,32 | 40| добре/
            foreach (Hour h in Hour)
            {
                nom++;
                int nn = MaxN - Convert.ToString(h.Name.Trim()).Length;
                int nlnr = MaxLNR - h.ListNumberRoute.Count();
                int nnp = MaxNP - Convert.ToString(h.NumberPassegers).Length;
                int nc = MaxC - Convert.ToString(h.Comentar).Length;
                Console.Write("| {0,5}", nom);
                Console.WriteLine("|" + Convert.ToString(h.Name.Trim()) + PS(nn) + "|" + h.ListNumberRoute + PS(nlnr) + "|" +
                 Convert.ToString(h.NumberPassegers) + PS(nnp) + "|" + Convert.ToString(h.Comentar) + PS(nc) + "|");
            }
        }
        public static void SaveDate(List<Hour> Date, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (Hour h in Date)
                {
                    sw.WriteLine(h.Name.Trim() + "|" + h.ListNumberRoute + "|" + h.NumberPassegers + "|" + h.Comentar + "│");
                }
            }
        }
        public abstract void MinNumPass(List<Hour> Date);
        public abstract void LongCom(List<Hour> Date);
        public abstract int AllNumPass(List<Hour> Date);
    }
    public class Hour : TramvayStop
    {
        public int NumberPassegers { get; set; }
        public string Comentar { get; set; }
        public override void MinNumPass(List<Hour> Date)
        {
            Console.Clear();
            Console.WriteLine("Година з найменшою кiлькiстю пасажирiв: ");
            int MaxLNR = 26;
            int MaxN = 12;
            int MaxNP = 21;
            int MaxC = 30;
            int nom = 0;
            int Min = Date[0].NumberPassegers;
            foreach (Hour gs in Date)
            {
                if (gs.NumberPassegers < Min)
                {
                    Min = gs.NumberPassegers;
                }
            }
            Console.WriteLine("|   №  |   Назва    | Список номерiв маршрутiв | Кiлькiсть пасажирiв |           Коментар           |");//дністровська| 15,43,32 | 40| добре/
            foreach (Hour h in Date)
            {
                nom++;
                if (Min == h.NumberPassegers)
                {
                    int nn = MaxN - Convert.ToString(h.Name.Trim()).Length;
                    int nlnr = MaxLNR - h.ListNumberRoute.Count();
                    int nnp = MaxNP - Convert.ToString(h.NumberPassegers).Length;
                    int nc = MaxC - Convert.ToString(h.Comentar).Length;
                    Console.Write("| {0,5}", nom);
                    Console.WriteLine("|" + Convert.ToString(h.Name.Trim()) + Hour.PS(nn) + "|" + h.ListNumberRoute + Hour.PS(nlnr) + "|" +
                     Convert.ToString(h.NumberPassegers) + Hour.PS(nnp) + "|" + Convert.ToString(h.Comentar) + Hour.PS(nc) + "|");
                }
            }
        }
        public override void LongCom(List<Hour> Date)
        {
            int IndexMax = 0;
            foreach (Hour hour in Date)
            {
                if (hour.Comentar.Length > Date[IndexMax].Comentar.Length)
                {
                    IndexMax = Date.IndexOf(hour);
                }
            }
            Console.WriteLine("Найдовший коментар: {0}", Date[IndexMax].Comentar);
        }
        public override int AllNumPass(List<Hour> Date)
        {
            int ANP = 0;
            foreach (Hour hour in Date)
            {
                ANP += hour.NumberPassegers;
            }
            return ANP;

        }
    }
    class Program
    {
        public static List<Hour> ReadDate(string path)
        {
            List<Hour> hour = new List<Hour>();
            string text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                foreach (char ae in sr.ReadToEnd())
                {
                    if (!char.IsControl(ae))
                    {
                        text = text + ae;
                    }
                }
            }
            string[] Dates = text.Split('│');
            foreach (string s in Dates)
            {
                string[] MetaDete = s.Split('|');
                if (MetaDete.Length == 4)
                {
                    Hour h = new Hour
                    {
                        Name = MetaDete[0],
                        ListNumberRoute = MetaDete[1],
                        NumberPassegers = Convert.ToInt32(MetaDete[2]),
                        Comentar = MetaDete[3]
                    };
                    hour.Add(h);
                }
            }
            return hour;
        }
        static void Main(string[] args)
        {
            Lab5_1();
            Console.WriteLine((Char)Console.ReadKey().KeyChar);
        }
        static void Lab5_1()
        {
            string path = "";
            Hour h = new Hour();
            List<Hour> hours = new List<Hour>();
            Console.WriteLine("Ввести шлях до файлу '' або створити новий файл");
            path = Console.ReadLine();
            try
            {
                hours = ReadDate(path);
            }
            catch
            {
                path = "TramvayStop.txt";
            }
            bool True = true;
            while (True)
            {
                Console.Clear();
                Console.WriteLine("Головне меню:\na-додавання записiв;\ne-редагування записiв;\nd– знищення записiв;\np-виведення iнформацiї з файла на екран;\ns-загальна кiлькiсть пасажирiв;\nb-година з найменшою кiлькiстю пасажирiв;\nc-найдовший коментар;\nx-вихiд;");
                var press = Console.ReadKey().Key;
                if (press.ToString() == "X")
                {
                    True = false;
                }
                if (press.ToString() == "E")
                {
                    Console.WriteLine();
                    h.EditDate(hours);
                    TramvayStop.SaveDate(hours, path);
                }
                if (press.ToString() == "D")
                {
                    Console.WriteLine();
                    h.DelDate(hours);
                    TramvayStop.SaveDate(hours, path);
                }
                if (press.ToString() == "A")
                {
                    Console.WriteLine();
                    TramvayStop.AddNew(hours);
                    TramvayStop.SaveDate(hours, path);
                }
                if (press.ToString() == "P")
                {
                    Console.WriteLine();
                    TramvayStop.ShowTable(hours);
                    Console.WriteLine("Натиснiть будьяку кнопку для повернення в головне меню");
                    Console.ReadKey();
                }
                if (press.ToString() == "S")
                {
                    TramvayStop.ShowTable(hours);
                    Console.WriteLine();
                    int anp = 0;
                    anp = hours[0].AllNumPass(hours);
                    Console.WriteLine("Загальна кiлькiсть пасажирiв: " + anp.ToString());
                    Console.WriteLine("Натиснiть будьяку кнопку для повернення в головне меню");
                    Console.ReadKey();
                }
                if (press.ToString() == "B")
                {
                    Console.WriteLine();
                    hours[0].MinNumPass(hours);
                    Console.WriteLine("Натиснiть будьяку кнопку для повернення в головне меню");
                    Console.ReadKey();
                }
                if (press.ToString() == "C")
                {
                    TramvayStop.ShowTable(hours);
                    Console.WriteLine();
                    hours[0].LongCom(hours);
                    Console.WriteLine("Натиснiть будьяку кнопку для повернення в головне меню");
                    Console.ReadKey();
                }
            }
        }
    }
}
