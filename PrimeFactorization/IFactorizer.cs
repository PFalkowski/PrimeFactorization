using System;
using System.Collections.Generic;

namespace PrimeFactorization
{
    public interface IFactorizer
    {
        List<int> Factorize(int number);
    }
}
