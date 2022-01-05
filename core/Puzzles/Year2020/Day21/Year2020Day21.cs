using Core.Platform;

namespace Core.Puzzles.Year2020.Day21;

public class Year2020Day21 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var detector = new AllergenDetector(FileInput);
        var ingredientCount = detector.FindIngredientsWithoutAllergens();
        return new PuzzleResult(ingredientCount, 2595);
    }

    public override PuzzleResult RunPart2()
    {
        var detector = new AllergenDetector(FileInput);
        var ingredientList = detector.GetIngredientList();
        return new PuzzleResult(ingredientList, "thvm,jmdg,qrsczjv,hlmvqh,zmb,mrfxh,ckqq,zrgzf");
    }
}