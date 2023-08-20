using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.InputValidator
{
    internal class InputValidator : IInputValidator
    {
        /// <summary>
        /// Validate the input string.
        /// </summary>
        /// <param name="input">An input string</param>
        /// <param name="primesCount">Number of prime numbers to be generated</param>
        /// <returns>An error message if the input string is not valid. Otherwise, returns the parsed number. Here the class validates and also parses the number which breaks single responsiblity
        /// principle. However, in our simple case I considered this as ok.</returns>
        public (bool valid, string errorMessage, int parsedNumber) Validate(string input, int primesCount)
        {
            if (primesCount == 0)
            {
                throw new ArgumentException($"Maximum number of primes can't be 0.", nameof(primesCount));
            }

            if (string.IsNullOrEmpty(input))
            {
                return (false, $"Input can't be empty string", 0);
            }            
            if (!int.TryParse(input, out var parsedInput) || parsedInput < 1 || parsedInput > primesCount)
            {
                return (false, $"Input '{input}' has to be a number between 1 and {primesCount}.", 0);
            }

            return (true, string.Empty, parsedInput);
        }
    }
}
