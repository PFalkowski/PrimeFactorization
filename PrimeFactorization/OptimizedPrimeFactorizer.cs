using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeFactorization
{
    public class OptimizedPrimeFactorizer : IFactorizer
    {
        public List<int> Factorize(int number)
        {
            if (number < 4) return new List<int> { number };
            List<int> result = new List<int>();
            while (number % 2 == 0)
            {
                result.Add(2);
                number /= 2;
            }
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                while (number % i == 0)
                {
                    result.Add(i);
                    number /= i;
                }
            }
            if (number > 2)
            {
                result.Add(number);
            }
            return result;
        }
    }
}
