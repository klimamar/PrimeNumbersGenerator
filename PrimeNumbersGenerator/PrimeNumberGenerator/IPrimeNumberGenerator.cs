using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.PrimeNumberGenerator
{
    public interface IPrimeNumberGenerator
    {
        IEnumerable<int> GeneratePrimes(int n);
    }
}
