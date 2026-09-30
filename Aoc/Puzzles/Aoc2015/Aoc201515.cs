using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Science for Hungry People")]
public class Aoc201515 : AocPuzzle
{
    private const int Min = 0;
    private const int Max = 100;

    [Puzzle("f40d60cbbeb6aff8eff639104c438ab2")]
    public int Part1(string input) => BakeCookies(input).Max(c => c.Score);

    [Puzzle("b617905d91fbff24a49282c5ea2ec636")]
    public int Part2(string input) => BakeCookies(input).Where(c => c.Calories == 500).Max(c => c.Score);

    private static IEnumerable<Cookie> BakeCookies(string input)
    {
        var ingredients = ParseIngredients(input);
        var combinations = GetCombinations(ingredients.Length);

        foreach (var combination in combinations)
        {
            var score = GetScore(ingredients, combination);
            var calories = GetCalories(ingredients, combination);
            yield return new Cookie(score, calories);
        }
    }

    private static int GetScore(CookieIngredient[] ingredients, int[] percentages)
    {
        var capacity = 0;
        var durability = 0;
        var flavor = 0;
        var texture = 0;

        for (var i = 0; i < ingredients.Length; i++)
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

    private static int GetCalories(CookieIngredient[] ingredients, int[] percentages) =>
        Math.Max(ingredients.Select((t, i) => percentages[i] * t.Calories).Sum(), 0);

    private static IEnumerable<int[]> GetCombinations(int depth) => depth == 2 
        ? GetCombinationsFor2Ingredients() 
        : GetCombinationsFor4Ingredients();

    private static IEnumerable<int[]> GetCombinationsFor2Ingredients()
    {
        for (var a = Min; a <= Max; a++)
        {
            var b = Max - a;
            if (a + b == Max)
                yield return [a, b];
        }
    }

    private static IEnumerable<int[]> GetCombinationsFor4Ingredients()
    {
        for (var a = Min; a <= Max; a++)
        {
            for (var b = Min; b <= Max; b++)
            {
                for (var c = Min; c <= Max; c++)
                {
                    var d = Max - a - b - c;
                    if (a + b + c + d == Max)
                        yield return [a, b, c, d];
                }
            }
        }
    }

    private static CookieIngredient[] ParseIngredients(string input) =>
        [.. input.Split(LineBreaks.Single).Select(ParseIngredient)];

    private static CookieIngredient ParseIngredient(string s)
    {
        var (capacity, durability, flavor, texture, calories) = Numbers.IntsFromString(s);
        return new CookieIngredient(capacity, durability, flavor, texture, calories);
    }

    private record Cookie(int Score, int Calories);
    private record CookieIngredient(int Capacity, int Durability, int Flavor, int Texture, int Calories);
}