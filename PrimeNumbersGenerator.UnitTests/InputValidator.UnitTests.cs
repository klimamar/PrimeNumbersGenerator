using NuGet.Frameworks;
using PrimeNumberGenerator.InputValidator;
using System.Text;

namespace PrimeNumberGenerator.UnitTests
{
    public class InputValidatorUnitTests
    {
        private IInputValidator sut;

        [SetUp]
        public void Setup()
        {
            sut = new InputValidator.InputValidator();
        }

        [Test]
        public void ThrowException_When_MaxPrimeNumberCountInput_LessThan1()
        {     
            Assert.Throws<ArgumentException>( () => sut.Validate("", -1));
        }

        [Test]
        public void ReturnsFalse_When_InputIsRandomChars()
        {
            var result = sut.Validate("kfjsdlkjf", 10);
            
            Assert.That(result.valid, Is.EqualTo(false));
        }

        [Test]
        public void ReturnsTrueAndParsedNumber_When_InputIsCorrect()
        {
            var result = sut.Validate("158", 200);

            Assert.That(result.valid, Is.EqualTo(true));
            Assert.That(result.parsedNumber, Is.EqualTo(158));
        }

        [Test]
        public void ReturnsFakse_When_InputIsCorrectAndGreaterThanMaxPrimeNumbersAllowed()
        {
            var result = sut.Validate("158", 100);

            Assert.That(result.valid, Is.EqualTo(false));
        }
    }
}
