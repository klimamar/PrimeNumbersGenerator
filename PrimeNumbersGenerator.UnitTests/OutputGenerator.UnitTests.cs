using Generator.OutputGenerator;
using NuGet.Frameworks;
using PrimeNumberGenerator.PrimeNumberGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.UnitTests
{
    public class OutputGeneratorUnitTests
    {
        private IOutputGenerator sut;

        [SetUp]
        public void Setup()
        {
            sut = new OutputGenerator();
        }

        [Test]
        public void GenerateOutput_For_OnePrimeNumber()
        {
            var result = sut.GenerateOutput(new List<int>() { 2 });

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("   2");
            expectedResult.Append    (" 2 4");

            Assert.That(result.ToString(), Is.EqualTo(expectedResult.ToString()));  
        }

        [Test]
        public void GenerateOutput_For_TwoPrimeNumbers()
        {
            var result = sut.GenerateOutput(new List<int>() { 2,3 });

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("   2 3");
            expectedResult.AppendLine(" 2 4 6");
            expectedResult.Append    (" 3 6 9");

            Assert.That(result.ToString(), Is.EqualTo(expectedResult.ToString()));
        }

        [Test]
        public void GenerateOutput_For_FivePrimeNumbers()
        {
            var result = sut.GenerateOutput(new List<int>() { 2,3,5,7,11 });

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("       2   3   5   7  11");
            expectedResult.AppendLine("   2   4   6  10  14  22");
            expectedResult.AppendLine("   3   6   9  15  21  33");
            expectedResult.AppendLine("   5  10  15  25  35  55");
            expectedResult.AppendLine("   7  14  21  35  49  77");
            expectedResult.Append    ("  11  22  33  55  77 121");

            Assert.That(result.ToString(), Is.EqualTo(expectedResult.ToString()));
        }

        [Test]
        public void PadNumbersLeft_Works()
        {
            var result = sut.PaddNumber(5, 3);

            Assert.That(result, Is.EqualTo("  5"));
        }

        [Test]
        public void PadNumbersLeft_Works_For_BigNumbers()
        {
            var result = sut.PaddNumber(((ulong)int.MaxValue * int.MaxValue), 25);

            Assert.That(result, Is.EqualTo("      4611686014132420609"));
        }

        [Test]
        public void GenerateHeader_Works()
        {
            var headerBuilder = new StringBuilder();

            sut.GenerateHeader(new List<int>() { 2, 3, 5 }, 3, headerBuilder);

            Assert.That(headerBuilder.ToString, Is.EqualTo("     2  3  5"));
        }
    }
}
