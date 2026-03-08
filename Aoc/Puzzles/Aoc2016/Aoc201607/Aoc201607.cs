using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201607;

[Name("Internet Protocol Version 7")]
public class Aoc201607 : AocPuzzle
{
    [Puzzle("e5028de6073400f8137ef0152f3ce53b")]
    public int Part1(string input) => new IpTester().TlsSupportCount(input);

    [Puzzle("e54678768fabf49128ceb9f16bd2f125")]
    public int Part2(string input) => new IpTester().SslSupportCount(input);
}