using Generator.OutputGenerator;
using PrimeNumberGenerator.InputValidator;

// Limit the count of prime numbers -> we output to the console so doesn't make sense to allow millions or even thousands
const int constMaxPrimeNumberCount = 150;

Console.WriteLine($"Prime numbers multiplication table generator");
Console.WriteLine($"Please input a number between 1 and {constMaxPrimeNumberCount}");

var input = Console.ReadLine();

IInputValidator inputValidator = new InputValidator();

var validationResult = inputValidator.Validate(input, constMaxPrimeNumberCount);

// If not valid number -> exit
if (!validationResult.valid)
{
    Console.WriteLine(validationResult.errorMessage);
    return;
}

var primeNumberGenerator = new PrimeNumberGenerator.PrimeNumberGenerator.PrimeNumberGenerator();

// Generate primes
var primes = primeNumberGenerator.GeneratePrimes(validationResult.parsedNumber);

var outputGenerator = new OutputGenerator();

// Generate output
var multiplicationMatrix = outputGenerator.GenerateOutput(primes);

// Print the output
Console.WriteLine("Output:");
Console.WriteLine(multiplicationMatrix);
