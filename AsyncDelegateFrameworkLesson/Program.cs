using System;
using System.Threading;

namespace AsyncDelegatesLesson
{
    class Program
    {
        delegate int MyAction();
        private static Func<int, int> action;
        static void Main(string[] args)
        {
            action = new Func<int, int>(CalculateSophisticNumber);
            //action();
            var res = action.BeginInvoke(1234, ProcessResult, null);  
            //while(!res.IsCompleted)
            //{
            //    Console.WriteLine("Идёт работа, ждем");
            //    Thread.Sleep(500);
            //}
            Console.WriteLine("Главный поток завершил работу");
            Console.ReadLine();
        }
        private static int CalculateSophisticNumber(int number)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - выполняет работу");
            Thread.Sleep(5000);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - закончил работу");
            return number;
        }
        private static void ProcessResult(IAsyncResult result)
        {
            Console.WriteLine(action.EndInvoke(result));
        }
    }
}
