using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201906;

[Name("Universal Orbit Map")]
public class Aoc201906 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var calculator = new OrbitCalculator(input);
        var orbitCount = calculator.GetOrbitCount();
        return new PuzzleResult(orbitCount, "47b7e7a9aac22c8d0dc3f8a1f510498a");
    }

    public PuzzleResult RunPart2(string input)
    {
        var calculator = new OrbitCalculator(input);
        var distance = calculator.GetSantaDistance();
        return new PuzzleResult(distance, "b69467aeda98c0291c1767a24409e868");
    }
}