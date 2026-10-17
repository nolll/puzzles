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
    public void IngredientsWithoutAllergens() => Sut.Part1(Input).Should().Be(5);

    [Fact]
    public void CanonicalIngredientList() => Sut.Part2(Input).Should().Be("mxmxvkd,sqjhc,fvjkl");
}