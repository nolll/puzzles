using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202021;

[Name("Allergen Assessment")]
public class Aoc202021 : AocPuzzle
{
    [Puzzle("a3862d6533f785e932eeaa517ad2549d")]
    public PuzzleResult Part1(string input)
    {
        var detector = new AllergenDetector(input);
        var ingredientCount = detector.FindIngredientsWithoutAllergens();
        return new PuzzleResult(ingredientCount);
    }

    [Puzzle("6adefc0d0ced658ef54a524396bb93a1")]
    public string Part2(string input) => new AllergenDetector(input).GetIngredientList();
}