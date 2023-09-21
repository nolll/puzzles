using System.Collections.Generic;
using System.Linq;
using Aoc.Platform;
using common.CoordinateSystems.CoordinateSystem2D;
using common.Puzzles;
using common.Strings;

namespace Aoc.Puzzles.Year2022.Day22;

public class Year2022Day22 : AocPuzzle
{
    public override string Name => "Monkey Map";

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
        var matrix = MatrixBuilder.BuildCharMatrixWithoutTrim(groups[0], ' ');
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
        var matrix = MatrixBuilder.BuildCharMatrixWithoutTrim(groups[0], ' ');
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
                        var (newCoord, newDirection) = MapExitPosition(matrix.Address, matrix.Direction, 50);
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

    public static (MatrixAddress newCoord, MatrixDirection newDirection) MapExitPosition(MatrixAddress c, MatrixDirection d, int size)
    {
        var x = c.X;
        var y = c.Y;

        if (d.Equals(MatrixDirection.Up))
        {
            if (c.X < size) // from left to front
                return (new MatrixAddress(y - size, x + size), MatrixDirection.Right);
            if (c.X < size * 2) // from top to back
                return (new MatrixAddress(y, x + size * 2), MatrixDirection.Right);
            if (c.X < size * 3) // from right to back
                return (new MatrixAddress(x - size * 2, y + size * 4 - 1), MatrixDirection.Up);
        }
        else if (d.Equals(MatrixDirection.Right))
        {
            if (c.Y < size) // from right to bottom
                return (new MatrixAddress(x - size, size * 3 - y - 1), MatrixDirection.Left);
            if (c.Y < size * 2) // from front to right
                return (new MatrixAddress(y + size, x - size), MatrixDirection.Up);
            if (c.Y < size * 3) // from bottom to right
                return (new MatrixAddress(x + size, size * 3 - y - 1), MatrixDirection.Left);
            if (c.Y < size * 4) // from back to bottom
                return (new MatrixAddress(y - size * 2, x + size * 2), MatrixDirection.Up);
        }
        else if (d.Equals(MatrixDirection.Down))
        {
            if (c.X < size) // from back to right
                return (new MatrixAddress(x + size * 2, y - size * 4 + 1), MatrixDirection.Down);
            if (c.X < size * 2) // from bottom to back
                return (new MatrixAddress(y - size * 2, x + size * 2), MatrixDirection.Left);
            if (c.X < size * 3) // from right to front
                return (new MatrixAddress(y + size, x - size), MatrixDirection.Left);
        }
        else
        {
            if (c.Y < size) // from top to left
                return (new MatrixAddress(x - size, size * 3 - y - 1), MatrixDirection.Right);
            if (c.Y < size * 2) // from front to left
                return (new MatrixAddress(y - size, x + size), MatrixDirection.Down);
            if (c.Y < size * 3) // from left to top
                return (new MatrixAddress(x + size, size * 3 - y - 1), MatrixDirection.Right);
            if (c.Y < size * 4) // from back to top
                return (new MatrixAddress(y - size * 2, x), MatrixDirection.Down);
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
