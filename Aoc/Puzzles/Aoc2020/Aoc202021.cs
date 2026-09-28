using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Allergen Assessment")]
public class Aoc202021 : AocPuzzle
{
    [Puzzle("a3862d6533f785e932eeaa517ad2549d")]
    public int Part1(string input) => new AllergenDetector(input).FindIngredientsWithoutAllergens();

    [Puzzle("6adefc0d0ced658ef54a524396bb93a1")]
    public string Part2(string input) => new AllergenDetector(input).GetIngredientList();

    public class AllergenDetector(string input)
    {
        private readonly IEnumerable<Food> _foods = input.Split(LineBreaks.Single).Select(Food.Parse);

        public int FindIngredientsWithoutAllergens()
        {
            var possibleIngredients = GetPossibleIngredientsByAllergen();

            var ingredientsWithAllergens = possibleIngredients.Values.SelectMany(o => o).Distinct();
            var ingredientInstancesWithoutAllergens = _foods.SelectMany(o => o.Ingredients).Where(o => !ingredientsWithAllergens.Contains(o));
            return ingredientInstancesWithoutAllergens.Count();
        }

        private Dictionary<string, List<string>> GetPossibleIngredientsByAllergen()
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

            return d;
        }

        public string GetIngredientList()
        {
            var possibleIngredients = GetPossibleIngredientsByAllergen();
            var canonical = new Dictionary<string, string>();

            while (possibleIngredients.Values.Any(o => o.Count > 0))
            {
                var single = possibleIngredients.First(o => o.Value.Count == 1);
                var allergenName = single.Key;
                var ingredientName = single.Value.First();
                canonical.Add(allergenName, ingredientName);

                foreach (var ingredient in possibleIngredients)
                {
                    if (ingredient.Value.Contains(ingredientName))
                    {
                        ingredient.Value.Remove(ingredientName);
                    }

                    if (!ingredient.Value.Any())
                    {
                        possibleIngredients.Remove(allergenName);
                    }
                }
            }

            var canonicalList = canonical.OrderBy(o => o.Key).Select(o => o.Value);

            return string.Join(',', canonicalList);
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