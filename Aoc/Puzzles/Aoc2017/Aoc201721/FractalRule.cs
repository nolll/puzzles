using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201721;

public class FractalRule
{
    public string Input { get; }
    public Grid<char> Output { get; }

    public FractalRule(string input, string output)
    {
        Input = input;
        Output = GridBuilder.BuildCharGrid(output.Replace("/", LineBreaks.Single));
    }

    public bool IsMatch(string compare)
    {
        return compare == Input;
    }
}