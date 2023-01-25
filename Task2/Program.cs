﻿using System;
using System.Linq;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortSurname sortSurname = new SortSurname();
            sortSurname.SortSurnameEvent += SortSurname;
            try
            {
                sortSurname.Read();
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение");
            }
        }

        static void SortSurname(int numberSort, string[] arrSurname)
        {

            switch (numberSort)
            {
                case 1: arrSurname = arrSurname.OrderBy(x => x).ToArray();
                    Console.WriteLine("Массив фамилий отсортирован от А до Я:");
                    break;
                case 2:
                    arrSurname = arrSurname.OrderByDescending(x => x).ToArray();
                    Console.WriteLine("Массив фамилий отсортирован от Я до А:");
                    break;
            }
            Console.WriteLine(String.Join("\r\n", arrSurname));
        }
    }

    class SortSurname
    {
        public delegate void SortSurnameDelegate(int numberSort, string[] arrSurname);
        public event SortSurnameDelegate SortSurnameEvent;

        public void Read()
        {
            string[] arrSurname = new string[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Введите фамилию {i + 1}");
                arrSurname[i] = Console.ReadLine();
            }
            Console.WriteLine("Введите последовательность сортировки: либо 1(от А до Я), либо 2(от Я до А)");

            int numberSort = Int32.Parse(Console.ReadLine());

            if (numberSort != 1 && numberSort != 2) throw new FormatException();

            SortSurnameEntered(numberSort, arrSurname);
        }

        protected virtual void SortSurnameEntered(int numberSort, string[] arrSurname)
        {
            SortSurnameEvent?.Invoke(numberSort, arrSurname);
        }
    }
}
