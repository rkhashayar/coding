using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your number would be?");
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(CalculateEvenFibo(number).ToString());
            Console.ReadLine();
        }

        public static long CalculateEvenFibo(long n)
        {
            long fib1 = 1;
            long fib2 = 1;
            long result = 0;
            long summed = 0;

            while (result < n)
            {
                if (result % 2 == 0)
                {
                    summed += result;
                }
                result = fib1 + fib2;
                fib1 = fib2;
                fib2 = result;
            }
            return summed;
        }
    }
}
