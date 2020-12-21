using Core.IslandFood;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class IslandFoodTests
    {
        private const string Input = @"
mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)";

        [Test]
        public void IngredientsWithoutAllergens()
        {
            var detector = new AllergenDetector(Input);
            var ingredientCount = detector.FindIngredientsWithoutAllergens();

            Assert.That(ingredientCount, Is.EqualTo(5));
        }

        [Test]
        public void CanonicalIngredientList()
        {
            var detector = new AllergenDetector(Input);
            var ingredientList = detector.GetIngredientList();

            Assert.That(ingredientList, Is.EqualTo("mxmxvkd,sqjhc,fvjkl"));
        }
    }
}