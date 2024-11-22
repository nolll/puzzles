using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201721;

public class FractalRule
{
    public string Input { get; }
    public Matrix<char> Output { get; }

    public FractalRule(string input, string output)
    {
        Input = input;
        Output = MatrixBuilder.BuildCharMatrix(output.Replace("/", Environment.NewLine));
    }

    public bool IsMatch(string compare)
    {
        return compare == Input;
    }
}