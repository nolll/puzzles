using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201608;

[Name("Two-Factor Authentication")]
public class Aoc201608 : AocPuzzle
{
    [Puzzle("40e526702a7945ea86fbcec32dd72a4d")]
    public int Part1(string input) => new ScreenSimulator(50, 6).Run(input).PixelCount;

    [Puzzle("5eb2504556c7376b34258205d7ef40f2")]
    public string Part2(string input) => new ScreenSimulator(50, 6).Run(input).Letters;
}