using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.IslandFood
{
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
}