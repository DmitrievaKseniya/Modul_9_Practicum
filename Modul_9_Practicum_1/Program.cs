using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exception[] arrException = { new ArgumentException(), new FormatException(), new MyException("тест моего исключения"), new NotSupportedException(), new TimeoutException() };

            foreach (Exception ex in arrException)
            {
                try
                {
                    throw ex;
                }
                catch
                {
                    Console.WriteLine($"Выведено исключение: {ex.GetType()} тест: {ex.Message}");
                }
            }
        }
    }

    public class MyException : ArgumentException
    { 
        public MyException() 
        {

        }

        public MyException(string message) : base(message) 
        {

        }
    }
}
