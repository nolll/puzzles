using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202021;

public class Aoc202021 : AocPuzzle
{
    public override string Name => "Allergen Assessment";

    protected override PuzzleResult RunPart1()
    {
        var detector = new AllergenDetector(InputFile);
        var ingredientCount = detector.FindIngredientsWithoutAllergens();
        return new PuzzleResult(ingredientCount, 2595);
    }

    protected override PuzzleResult RunPart2()
    {
        var detector = new AllergenDetector(InputFile);
        var ingredientList = detector.GetIngredientList();
        return new PuzzleResult(ingredientList, "thvm,jmdg,qrsczjv,hlmvqh,zmb,mrfxh,ckqq,zrgzf");
    }
}