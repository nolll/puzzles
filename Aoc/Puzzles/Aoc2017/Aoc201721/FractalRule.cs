using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201721;

public class FractalRule(string input, string output)
{
    public string Input { get; } = input;
    public Grid<char> Output { get; } = GridBuilder.BuildCharGrid(output.Replace("/", LineBreaks.Single));
    public bool IsMatch(string compare) => compare == Input;
}