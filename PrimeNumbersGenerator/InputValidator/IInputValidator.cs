using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.InputValidator
{
    public interface IInputValidator
    {
        (bool valid, string errorMessage, int parsedNumber) Validate(string input, int maxNumberOfPrimes);
    }
}
