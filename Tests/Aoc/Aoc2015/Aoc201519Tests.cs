using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201519Tests : PuzzleTest<Aoc201519>
{
    [Fact]
    public void FindsDistinctMolecules()
    {
        const string startMolecule = "HOH";
        const string input = """
                             H => HO
                             H => OH
                             O => HH
                             """;
        
        Sut.GetCalibrationMoleculeCount(input, startMolecule).Should().Be(4);
    }

    [Theory]
    [InlineData("HOH", 3)]
    [InlineData("HOHOHO", 6)]
    public void TimeToMakeMolecule(string molecule, int steps)
    {
        const string input = """
                             e => H
                             e => O
                             H => HO
                             H => OH
                             O => HH
                             """;
        
        Sut.StepsToMake(input, molecule).Should().Be(steps);
    }
}