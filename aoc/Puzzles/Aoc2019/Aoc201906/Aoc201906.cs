using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201906;

public class Aoc201906 : AocPuzzle
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