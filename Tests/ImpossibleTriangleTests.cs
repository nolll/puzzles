using Core.ImpossibleTriangles;
using NUnit.Framework;

namespace Tests
{
    public class ImpossibleTriangleTests
    {
        [TestCase("12 13 14", true)]
        [TestCase("1 2 5", false)]
        public void ValidateTriangles(string triangleSpec, bool expectedResult)
        {
            var validator = new TriangleValidator();
            var isValid = validator.IsValid(triangleSpec);

            Assert.That(isValid, Is.EqualTo(expectedResult));
        }
    }
}