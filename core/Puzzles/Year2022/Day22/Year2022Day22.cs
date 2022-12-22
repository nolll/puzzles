using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Common.Strings;
using Core.Platform;

namespace Core.Puzzles.Year2022.Day22;

public class Year2022Day22 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var result = Part1(FileInput);
        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        return new EmptyPuzzleResult();
    }

    public int Part1(string input)
    {
        var groups = PuzzleInputReader.ReadStringGroupsWithWhitespace(input);
        var matrix = MatrixBuilder.BuildQuickCharMatrixWithoutTrim(groups[0], ' ');
        matrix.MoveTo(0, 0);
        matrix.TurnTo(MatrixDirection.Right);
        while (matrix.ReadValue() == ' ')
            matrix.MoveForward();

        var path = ParsePath(groups[1]);

        foreach (var instruction in path)
        {
            var isNumeric = int.TryParse(instruction, out var stepsToMove);
            if (isNumeric)
            {
                while (stepsToMove > 0)
                {
                    var lastPos = matrix.Address;
                    var moveSucceeded = true;
                    if (matrix.TryMoveForward())
                    {
                        if (matrix.ReadValue() == '#')
                        {
                            matrix.MoveTo(lastPos);
                            break;
                        }

                        if (matrix.ReadValue() == ' ')
                            moveSucceeded = false;
                    }
                    else
                    {
                        moveSucceeded = false;
                    }

                    if (!moveSucceeded)
                    {
                        if (matrix.Direction.Equals(MatrixDirection.Up))
                            matrix.MoveTo(matrix.Address.X, matrix.YMax);
                        else if (matrix.Direction.Equals(MatrixDirection.Right))
                            matrix.MoveTo(matrix.XMin, matrix.Address.Y);
                        else if (matrix.Direction.Equals(MatrixDirection.Down))
                            matrix.MoveTo(matrix.Address.X, matrix.YMin);
                        else
                            matrix.MoveTo(matrix.XMax, matrix.Address.Y);
                    }

                    while (matrix.ReadValue() == ' ')
                        matrix.MoveForward();

                    if (matrix.ReadValue() == '#')
                    {
                        matrix.MoveTo(lastPos);
                        break;
                    }

                    stepsToMove--;
                }
            }
            else
            {
                if (instruction == "R")
                    matrix.TurnRight();
                else
                    matrix.TurnLeft();
            }
        }

        var row = matrix.Address.Y + 1;
        var col = matrix.Address.X + 1;
        var facingScore = GetFacingScore(matrix.Direction);

        var password = 1000 * row + 4 * col + facingScore;

        return password;
    }

    private string[] ParsePath(string s)
    {
        var css = s.Replace("R", ",R,").Replace("L", ",L,");
        return css.Split(',').ToArray();
    }

    private int GetFacingScore(MatrixDirection d)
    {
        if (d.Equals(MatrixDirection.Up))
            return 3;
        if (d.Equals(MatrixDirection.Right))
            return 0;
        if (d.Equals(MatrixDirection.Down))
            return 1;
        return 2;
    }
}