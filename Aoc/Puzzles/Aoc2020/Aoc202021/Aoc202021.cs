﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202021;

[Name("Allergen Assessment")]
public class Aoc202021(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var detector = new AllergenDetector(input);
        var ingredientCount = detector.FindIngredientsWithoutAllergens();
        return new PuzzleResult(ingredientCount, "a3862d6533f785e932eeaa517ad2549d");
    }

    protected override PuzzleResult RunPart2()
    {
        var detector = new AllergenDetector(input);
        var ingredientList = detector.GetIngredientList();
        return new PuzzleResult(ingredientList, "6adefc0d0ced658ef54a524396bb93a1");
    }
}