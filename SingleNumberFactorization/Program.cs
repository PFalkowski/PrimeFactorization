using PrimeFactorization;
using System;

namespace SingleNumberFactorization
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    var factorizer = new OptimizedPrimeFactorizer();
                    Console.WriteLine("Enter number:");
                    var number = Int32.Parse(Console.ReadLine());
                    var result = factorizer.Factorize(number);
                    Console.WriteLine("Prime factors:");
                    Console.WriteLine(string.Join(' ', result));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
