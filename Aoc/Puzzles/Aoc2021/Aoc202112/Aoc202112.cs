using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202112;

[Name("Passage Pathing")]
public class Aoc202112 : AocPuzzle
{
    [Puzzle("f0ddaeeb33f1a0ff7a113ef020e9decd")]
    public int Part1(string input) => new CaveSystem(input, false).CountPaths();

    [Puzzle("435c45d6610ccd392e06c43e52654eb5")]
    public int Part2(string input) => new CaveSystem(input, true).CountPaths();
}