using System.Collections.Generic;
using System.Linq;
using Common.Strings;

namespace Aoc.Puzzles.Year2020.Day21;

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