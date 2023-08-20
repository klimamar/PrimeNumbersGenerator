using NuGet.Frameworks;
using NUnit.Framework.Internal;
using PrimeNumberGenerator.PrimeNumberGenerator;

namespace PrimeNumberGenerator.UnitTests
{
    public class PrimeNumberGeneratorUnitTests
    {
        private IPrimeNumberGenerator sut;

        [SetUp]
        public void Setup()
        {
            sut = new PrimeNumberGenerator.PrimeNumberGenerator();
        }

        [Test]
        public void EmptyResultSet_When_Input_Is_LessThan1()
        {
            var result = sut.GeneratePrimes(0);

            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        [TestCase(1, new int[]{ 2} )]
        [TestCase(2, new int[] { 2, 3 })]
        [TestCase(3, new int[] { 2, 3, 5})]
        [TestCase(4, new int[] { 2, 3, 5, 7 })]
        [TestCase(25, new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
        public void CorrectPrimeNumbers_Are_Generated(int n, IEnumerable<int> shouldBeResultSet)
        {
            var result = sut.GeneratePrimes(n);

            Assert.IsNotNull(result);
            CollectionAssert.AllItemsAreUnique(result);
            CollectionAssert.AreEquivalent(result, shouldBeResultSet);
        }
    }
}