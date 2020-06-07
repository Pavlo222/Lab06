using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab06_1
{
    interface Books
    {
        void massort(ref int[] a, int n);
        void names(string namebook, string year, int n, out int[] mas);
    }
    public class Book: Books
    {

        //поля класу
        public Book()
        {
            //конструктор без параметрів
        }
        public string autor { get; set; }
        public string namebook { get; set; }
        public string publication { get; set; }
        public string year { get; set; }
        public void massort(ref int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int max = a[i];
                for (int j = i; j < n; j++)
                {
                    if (a[j] >= max)
                    {
                        max = a[j];
                    }
                }
                int nom;
                for (int j = i; j < n; j++)
                {
                    if (a[j] == max)
                    {
                        nom = a[i];
                        a[i] = a[j];
                        a[j] = nom;
                    }
                }
            }
        }
        public void names(string namebook, string year, int n, out int[] mas)
        {
            mas = new int[n];
            int i = 0, d = 0, l;
            string f = "";
            bool Tru = false;
            foreach (char nmes in namebook)
            {
                d = 0;
                if (nmes == '|')
                {
                    d = 1;
                    i++;
                }
                if (d == 0)
                {
                    f = f + nmes.ToString();
                }
                if (d == 1)
                {
                    string nams = " ";
                    foreach (char nam in f)
                    {
                        l = 0;
                        if (!Char.IsLetter(nam))
                        {
                            l = 1;
                        }
                        if (l == 0)
                        {
                            nams = nams + nam.ToString();
                        }
                        if (l == 1)
                        {
                            if (nams == " програмування" || nams == " Програмування")
                            {
                                Tru = true;
                            }
                            nams = " ";
                        }
                    }
                    f = " ";
                }
                if (Tru)
                {
                    int ai = 0;
                    string y = "";
                    int a = 0;
                    foreach (char ter in year)
                    {
                        a = 0;
                        if (ter == '|')
                        {
                            a = 1;
                            ai++;
                        }
                        if (a == 0)
                        {
                            y = y + ter.ToString();
                        }
                        if (a == 1)
                        {
                            if (ai == i)
                            {
                                mas[ai - 1] = (int.Parse(y)) * 100 + ai - 1;
                            }
                            y = "";
                        }
                    }
                }
                Tru = false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Кiлькiсть записiв: ");
            int n = int.Parse(Console.ReadLine());
            int[] myear = new int[n];
            Book book = new Book();
            bool True = true;
            string s = "";
            for (int i = 0; i < n; i++)
            {
                Console.Write("\nАвтор: ");
                book.autor = book.autor + Console.ReadLine() + " |";
                Console.Write("Назва книги: ");
                book.namebook = book.namebook + Console.ReadLine() + " |";
                Console.Write("Видавництво: ");
                book.publication = book.publication + Console.ReadLine() + " |";
                Console.Write("Рiк: ");
                True = true;
                while (True)
                {
                    int asy = 0;
                    s = Console.ReadLine();
                    foreach (char asd in s)
                    {
                        if (Char.IsNumber(asd))
                        {
                            asy++;
                        }
                    }
                    if (asy == s.Length)
                    {
                        True = false;
                    }
                    else
                    {
                        Console.WriteLine("Введiть число ");
                    }
                }
                book.year = book.year + s + "|";
            }
            book.names(book.namebook, book.year, n, out myear);
            book.massort(ref myear, n);
            Console.WriteLine("\n");
            foreach (int vb in myear)
            {
                if (vb != 0)
                {
                    int ai = 0;
                    Console.Write("\nАвтор: ");
                    foreach (var aut in book.autor)
                    {
                        int a = 0;
                        if (aut == '|')
                        {
                            a = 1;
                            ai++;
                        }
                        if (a == 0 && ai == vb % 100)
                        {
                            Console.Write(aut);
                        }
                    }
                    Console.Write("\nНазва: ");
                    ai = 0;
                    foreach (var aut in book.namebook)
                    {
                        int a = 0;
                        if (aut == '|')
                        {
                            a = 1;
                            ai++;
                        }
                        if (a == 0 && ai == vb % 100)
                        {
                            Console.Write(aut);
                        }
                    }
                    ai = 0;
                    Console.Write("\nВиробництво: ");
                    foreach (var aut in book.publication)
                    {
                        int a = 0;
                        if (aut == '|')
                        {
                            a = 1;
                            ai++;
                        }
                        if (a == 0 && ai == vb % 100)
                        {
                            Console.Write(aut);
                        }
                    }
                    ai = 0;
                    Console.Write("\nРiк: ");
                    foreach (var aut in book.year)
                    {
                        int a = 0;
                        if (aut == '|')
                        {
                            a = 1;
                            ai++;
                        }
                        if (a == 0 && ai == vb % 100)
                        {
                            Console.Write(aut);
                        }
                    }
                    Console.Write("\n");
                }
            }
        }
    }
}
