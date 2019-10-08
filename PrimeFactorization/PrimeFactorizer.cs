using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeFactorization
{
    public class NaivePrimeFactorizer : IFactorizer
    {
        public List<int> Factorize(int composite)
        {
            List<int> result = new List<int>();

            for (int i = 2; composite > 1; ++i)
            {
                if (composite % i == 0)
                {
                    while (composite % i == 0)
                    {
                        composite /= i;
                        result.Add(i);
                    }
                }
            }
            return result;
        }
    }
}
