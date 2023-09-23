using Common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day06;

public class Year2019Day06 : AocPuzzle
{
    public override string Name => "Universal Orbit Map";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new OrbitCalculator(InputFile);
        var orbitCount = calculator.GetOrbitCount();
        return new PuzzleResult(orbitCount, 278_744);
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new OrbitCalculator(InputFile);
        var distance = calculator.GetSantaDistance();
        return new PuzzleResult(distance, 475);
    }
}