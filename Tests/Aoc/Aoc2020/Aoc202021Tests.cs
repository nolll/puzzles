using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202021Tests : PuzzleTest<Aoc202021>
{
    private const string Input = """
                                 mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
                                 trh fvjkl sbzzf mxmxvkd (contains dairy)
                                 sqjhc fvjkl (contains soy)
                                 sqjhc mxmxvkd sbzzf (contains fish)
                                 """;

    [Fact]
    public void IngredientsWithoutAllergens()
    {
        var detector = new Aoc202021.AllergenDetector(Input.Trim());
        var ingredientCount = detector.FindIngredientsWithoutAllergens();

        ingredientCount.Should().Be(5);
    }

    [Fact]
    public void CanonicalIngredientList()
    {
        var detector = new Aoc202021.AllergenDetector(Input.Trim());
        var ingredientList = detector.GetIngredientList();

        ingredientList.Should().Be("mxmxvkd,sqjhc,fvjkl");
    }
}