using System;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2017.Day21;

public class FractalRule
{
    public string Input { get; }
    public IMatrix<char> Output { get; }

    public FractalRule(string input, string output)
    {
        Input = input;
        Output = MatrixBuilder.BuildQuickCharMatrix(output.Replace("/", Environment.NewLine));
    }

    public bool IsMatch(string compare)
    {
        return compare == Input;
    }
}