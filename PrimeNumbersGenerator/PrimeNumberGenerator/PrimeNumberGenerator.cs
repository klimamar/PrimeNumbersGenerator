namespace PrimeNumberGenerator.PrimeNumberGenerator
{
    public class PrimeNumberGenerator : IPrimeNumberGenerator
    {

        public IEnumerable<int> GeneratePrimes(int n)
        {
            if (n < 1)
            {
                return Enumerable.Empty<int>();
            }

            var primes = new List<int>(n) { 2 };
            int num = 3;
            while (primes.Count < n) 
            {
                bool isPrime = true;
                for (var i = 0; i < primes.Count; i++)
                {
                    if (num % primes[i] == 0)                               
                    {
                        isPrime = false; 
                        break; 
                    }
                }
                if (isPrime) 
                {
                    primes.Add(num); 
                }
                num += 2; 
            }

            return primes;
        }
    }
}

