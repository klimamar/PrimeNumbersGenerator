using System.Text;

namespace Generator.OutputGenerator
{
    public class OutputGenerator : IOutputGenerator
    {
        public string GenerateOutput(IEnumerable<int> primeNumbers)
        {
            var maxPrimeNumber = primeNumbers.Last();
            var numberOfDigits = (maxPrimeNumber*maxPrimeNumber).ToString().Length+1;

            var result = new StringBuilder();
            GenerateHeader(primeNumbers, numberOfDigits, result);
            
            foreach (var primeNumber in primeNumbers)
            {
                result.AppendLine();
                GenerateRow(primeNumber, primeNumbers, numberOfDigits, result);                
            }

            return result.ToString();
        }                

        public string PaddNumber(ulong number, int maxPaddedLength)
        {
            return number.ToString().PadLeft(maxPaddedLength, ' ');
        }

        public void GenerateHeader(IEnumerable<int> primeNumbers, int maxPaddedLength, StringBuilder stringBuilder)
        {
            stringBuilder.Append("".PadLeft(maxPaddedLength, ' '));            
            GenerateStringFromNumbers(1, primeNumbers, maxPaddedLength, stringBuilder);
        }

        public void GenerateRow(int rowNumber, IEnumerable<int> primeNumbers, int maxPaddedLength, StringBuilder stringBuilder)
        {
            stringBuilder.Append(rowNumber.ToString().PadLeft(maxPaddedLength, ' '));
            GenerateStringFromNumbers(rowNumber, primeNumbers, maxPaddedLength, stringBuilder);
        }

        public void GenerateStringFromNumbers(int rowNumber, IEnumerable<int> primeNumbers, int maxPaddedLength, StringBuilder stringBuilder)
        {
            foreach (uint primeNumber in primeNumbers)
            {
                stringBuilder.Append(PaddNumber((ulong)(rowNumber * primeNumber), maxPaddedLength));
            }
        }
    }
}
