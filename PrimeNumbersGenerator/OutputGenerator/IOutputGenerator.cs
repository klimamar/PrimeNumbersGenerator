using System.Text;

namespace Generator.OutputGenerator
{
    public interface IOutputGenerator
    {
        string GenerateOutput(IEnumerable<int> primeNumbers);
        string PaddNumber(ulong number, int maxPaddedLength);
        void GenerateHeader(IEnumerable<int> primeNumbers, int maxPaddedLength, StringBuilder stringBuilder);
        void GenerateRow(int rowNumber, IEnumerable<int> primeNumbers, int maxPaddedLength, StringBuilder stringBuilder);
        void GenerateStringFromNumbers(int rowNumber, IEnumerable<int> primeNumbers, int maxPaddedLength, StringBuilder stringBuilder);
    }
}
