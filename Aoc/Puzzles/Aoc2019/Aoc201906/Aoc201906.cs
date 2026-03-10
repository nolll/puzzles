using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201906;

[Name("Universal Orbit Map")]
public class Aoc201906 : AocPuzzle
{
    [Puzzle("47b7e7a9aac22c8d0dc3f8a1f510498a")]
    public PuzzleResult Part1(string input)
    {
        var calculator = new OrbitCalculator(input);
        var orbitCount = calculator.GetOrbitCount();
        return new PuzzleResult(orbitCount);
    }

    [Puzzle("b69467aeda98c0291c1767a24409e868")]
    public PuzzleResult Part2(string input)
    {
        var calculator = new OrbitCalculator(input);
        var distance = calculator.GetSantaDistance();
        return new PuzzleResult(distance);
    }
}