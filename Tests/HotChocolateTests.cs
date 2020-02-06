using Core.HotChocolate;
using NUnit.Framework;

namespace Tests
{
    public class HotChocolateTests
    {
        [TestCase(9, "5158916779")]
        [TestCase(5, "0124515891")]
        [TestCase(18, "9251071085")]
        [TestCase(2018, "5941429882")]
        public void FindRecipeScores(int input, string expected)
        {
            var generator = new RecipeGenerator();
            var scores = generator.ScoresAfter(input);

            Assert.That(scores, Is.EqualTo(expected));
        }
    }
}