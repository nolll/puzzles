using System.Collections.Generic;
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
        return new PuzzleResult(result, 47462);
    }

    public override PuzzleResult RunPart2()
    {
        var result = Part2(FileInput);
        return new PuzzleResult(result, 137045);
    }

    public static int Part1(string input)
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

    public static int Part2(string input)
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
                    var lastDirection = matrix.Direction;
                    var moveSucceeded = true;
                    if (matrix.TryMoveForward())
                    {
                        if (matrix.ReadValue() == '#')
                        {
                            matrix.MoveTo(lastPos);
                            break;
                        }

                        if (matrix.ReadValue() == ' ')
                        {
                            matrix.MoveTo(lastPos);
                            moveSucceeded = false;
                        }
                    }
                    else
                    {
                        moveSucceeded = false;
                    }

                    if (!moveSucceeded)
                    {
                        var (newCoord, newDirection) = MapExitPosition(matrix.Address, matrix.Direction);
                        if (matrix.TryMoveTo(newCoord))
                        {
                            matrix.TurnTo(newDirection);
                        }
                    }

                    if (matrix.ReadValue() == '#')
                    {
                        matrix.MoveTo(lastPos);
                        matrix.TurnTo(lastDirection);
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

    public static (MatrixAddress newCoord, MatrixDirection newDirection) MapExitPosition(MatrixAddress c, MatrixDirection d)
    {
        var x = c.X;
        var y = c.Y;
        if (d.Equals(MatrixDirection.Up))
        {
            switch (c.X)
            {
                case < 50: // from left to front
                    return (new MatrixAddress(y - 50, x + 50), MatrixDirection.Right);
                case < 100: // from top to back
                    return (new MatrixAddress(y, x + 100), MatrixDirection.Right);
                case < 150: // from right to back
                    return (new MatrixAddress(x - 100, y + 200 - 1), MatrixDirection.Up);
            }
        }
        else if (d.Equals(MatrixDirection.Right))
        {
            switch (c.Y)
            {
                case < 50: // from right to bottom
                    return (new MatrixAddress(x - 50, 150 - y - 1), MatrixDirection.Left);
                case < 100: // from front to right
                    return (new MatrixAddress(y + 50, x - 50), MatrixDirection.Up);
                case < 150: // from bottom to right
                    return (new MatrixAddress(x + 50, 150 - y - 1), MatrixDirection.Left);
                case < 200: // from back to bottom
                    return (new MatrixAddress(y - 100, x + 100), MatrixDirection.Up);
            }
        }
        else if (d.Equals(MatrixDirection.Down))
        {
            switch (c.X)
            {
                case < 50: // from back to right
                    return (new MatrixAddress(x + 100, y - 200 + 1), MatrixDirection.Down);
                case < 100: // from bottom to back
                    return (new MatrixAddress(y - 100, x + 100), MatrixDirection.Left);
                case < 150: // from right to front
                    return (new MatrixAddress(y + 50, x - 50), MatrixDirection.Left);
            }
        }
        else
        {
            switch (c.Y)
            {
                case < 50: // from top to left
                    return (new MatrixAddress(x - 50, 150 - y - 1), MatrixDirection.Right);
                case < 100: // from front to left
                    return (new MatrixAddress(y - 50, x + 50), MatrixDirection.Down);
                case < 150: // from left to top
                    return (new MatrixAddress(x + 50, 150 - y - 1), MatrixDirection.Right);
                case < 200: // from back to top
                    return (new MatrixAddress(y - 100, x), MatrixDirection.Down);
            }
        }

        return (new MatrixAddress(0, 0), MatrixDirection.Up);
    }

    private static IEnumerable<string> ParsePath(string s)
    {
        var css = s.Replace("R", ",R,").Replace("L", ",L,");
        return css.Split(',').ToArray();
    }

    private static int GetFacingScore(MatrixDirection d)
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
