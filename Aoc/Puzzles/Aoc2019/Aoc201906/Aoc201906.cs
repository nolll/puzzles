using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201906;

[Name("Universal Orbit Map")]
public class Aoc201906 : AocPuzzle
{
    [Puzzle("47b7e7a9aac22c8d0dc3f8a1f510498a")]
    public int Part1(string input) => new OrbitCalculator(input).GetOrbitCount();

    [Puzzle("b69467aeda98c0291c1767a24409e868")]
    public int Part2(string input) => new OrbitCalculator(input).GetSantaDistance();
}