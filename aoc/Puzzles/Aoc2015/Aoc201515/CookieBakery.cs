using System.Collections.Generic;
using System.Linq;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2015.Day15;

public class CookieBakery
{
    public int HighestScore { get; }
    public int HighestScoreWith500Calories { get; }

    public CookieBakery(string input)
    {
        var ingredients = ParseIngredients(input);
        var combinations = GetCombinations(ingredients.Count);
        HighestScore = 0;
        HighestScoreWith500Calories = 0;

        foreach (var combination in combinations)
        {
            var score = GetScore(ingredients, combination);
            var calories = GetCalories(ingredients, combination);
            if (score > HighestScore)
                HighestScore = score;

            if (calories == 500 && score > HighestScoreWith500Calories)
                HighestScoreWith500Calories = score;
        }
    }

    private int GetScore(IList<CookieIngredient> ingredients, List<int> percentages)
    {
        var capacity = 0;
        var durability = 0;
        var flavor = 0;
        var texture = 0;

        for (var i = 0; i < ingredients.Count; i++)
        {
            capacity += percentages[i] * ingredients[i].Capacity;
            durability += percentages[i] * ingredients[i].Durability;
            flavor += percentages[i] * ingredients[i].Flavor;
            texture += percentages[i] * ingredients[i].Texture;
        }

        capacity = capacity > 0 ? capacity : 0;
        durability = durability > 0 ? durability : 0;
        flavor = flavor > 0 ? flavor : 0;
        texture = texture > 0 ? texture : 0;

        return capacity * durability * flavor * texture;
    }

    private int GetCalories(IList<CookieIngredient> ingredients, List<int> percentages)
    {
        var calories = 0;

        for (var i = 0; i < ingredients.Count; i++)
        {
            calories += percentages[i] * ingredients[i].Calories;
        }

        return calories > 0 ? calories : 0;
    }

    private IList<List<int>> GetCombinations(int depth)
    {
        const int min = 0;
        const int max = 100;

        var combinations = new List<List<int>>();

        if (depth == 2)
        {
            for (var a = min; a <= max; a++)
            {
                var b = max - a;
                if(a + b == max)
                    combinations.Add(new List<int>{a, b});
            }
        }

        if (depth == 4)
        {
            for (var a = min; a <= max; a++)
            {
                for (var b = min; b <= max; b++)
                {
                    for (var c = min; c <= max; c++)
                    {
                        var d = max - a - b - c;
                        if (a + b + c + d == max)
                            combinations.Add(new List<int> { a, b, c, d });

                    }
                }
            }
        }

        return combinations;
    }

    private IList<CookieIngredient> ParseIngredients(string input)
    {
        var rows = PuzzleInputReader.ReadLines(input);
        return rows.Select(ParseIngredient).ToList();
    }

    private CookieIngredient ParseIngredient(string s)
    {
        var parts = s.Replace(":", "").Replace(",", "").Split(' ');
        var name = parts[0];
        var capacity = int.Parse(parts[2]);
        var durability = int.Parse(parts[4]);
        var flavor = int.Parse(parts[6]);
        var texture = int.Parse(parts[8]);
        var calories = int.Parse(parts[10]);
        return new CookieIngredient(name, capacity, durability, flavor, texture, calories);
    }
}