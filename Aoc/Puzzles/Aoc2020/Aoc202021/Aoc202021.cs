using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202021;

public class Aoc202021 : AocPuzzle
{
    public override string Name => "Allergen Assessment";

    protected override PuzzleResult RunPart1()
    {
        var detector = new AllergenDetector(InputFile);
        var ingredientCount = detector.FindIngredientsWithoutAllergens();
        return new PuzzleResult(ingredientCount, "a3862d6533f785e932eeaa517ad2549d");
    }

    protected override PuzzleResult RunPart2()
    {
        var detector = new AllergenDetector(InputFile);
        var ingredientList = detector.GetIngredientList();
        return new PuzzleResult(ingredientList, "6adefc0d0ced658ef54a524396bb93a1");
    }
}