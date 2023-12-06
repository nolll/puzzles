using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201906;

public class Aoc201906 : AocPuzzle
{
    public override string Name => "Universal Orbit Map";

    protected override PuzzleResult RunPart1()
    {
        var calculator = new OrbitCalculator(InputFile);
        var orbitCount = calculator.GetOrbitCount();
        return new PuzzleResult(orbitCount, "47b7e7a9aac22c8d0dc3f8a1f510498a");
    }

    protected override PuzzleResult RunPart2()
    {
        var calculator = new OrbitCalculator(InputFile);
        var distance = calculator.GetSantaDistance();
        return new PuzzleResult(distance, "b69467aeda98c0291c1767a24409e868");
    }
}