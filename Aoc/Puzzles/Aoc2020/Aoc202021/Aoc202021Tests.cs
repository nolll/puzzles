namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202021;

public class Aoc202021Tests
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
        var detector = new AllergenDetector(Input.Trim());
        var ingredientCount = detector.FindIngredientsWithoutAllergens();

        ingredientCount.Should().Be(5);
    }

    [Fact]
    public void CanonicalIngredientList()
    {
        var detector = new AllergenDetector(Input.Trim());
        var ingredientList = detector.GetIngredientList();

        ingredientList.Should().Be("mxmxvkd,sqjhc,fvjkl");
    }
}