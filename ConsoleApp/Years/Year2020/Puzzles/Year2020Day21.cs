using Core.IslandFood;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Year2020Day21 : Year2020Day
    {
        public override int Day => 21;

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
}