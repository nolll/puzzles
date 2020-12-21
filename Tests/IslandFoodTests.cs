using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class IslandFoodTests
    {
        [Test]
        public void IngredientsWithoutAllergens()
        {
            const string input = @"
mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)";

            var detector = new AllergenDetector(input);
            var ingredientCount = detector.FindIngredientsWithoutAllergens();

            Assert.That(ingredientCount, Is.EqualTo(5));
        }
    }

    public class AllergenDetector
    {
        private IEnumerable<Food> _foods;

        public AllergenDetector(string input)
        {
            var rows = PuzzleInputReader.ReadLines(input);
            _foods = rows.Select(Food.Parse);
        }

        public int FindIngredientsWithoutAllergens()
        {
            var d = new Dictionary<string, List<string>>();
            foreach (var food in _foods)
            {
                foreach (var allergen in food.Allergens)
                {
                    if (!d.TryGetValue(allergen, out var possibleIngredients))
                    {
                        d[allergen] = food.Ingredients.ToList();
                    }
                    else
                    {
                        var newPossibleIngredients = new List<string>();
                        foreach (var ingredient in possibleIngredients)
                        {
                            if (food.Ingredients.Contains(ingredient))
                            {
                                newPossibleIngredients.Add(ingredient);
                            }
                        }

                        d[allergen] = newPossibleIngredients;
                    }
                }
            }

            var ingredientsWithAllergens = d.Values.SelectMany(o => o).Distinct();
            var ingredientInstancesWithoutAllergens = _foods.SelectMany(o => o.Ingredients).Where(o => !ingredientsWithAllergens.Contains(o));
            return ingredientInstancesWithoutAllergens.Count();
        }
    }

    public class Food
    {
        public List<string> Ingredients { get; }
        public List<string> Allergens { get; }

        private Food(List<string> ingredients, List<string> allergens)
        {
            Ingredients = ingredients;
            Allergens = allergens;
        }

        public static Food Parse(string s)
        {
            var parts = s.Split('(');
            var ingredients = parts[0].Trim().Split(' ').Select(o => o.Trim()).ToList();
            var allergens = parts[1].Replace("contains", "").Trim(')').Split(',').Select(o => o.Trim()).ToList();

            return new Food(ingredients, allergens);
        }
    }
}