using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202222;

[Name("Monkey Map")]
public class Aoc202222 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = Part1(input);
        return new PuzzleResult(result, "5230885ca3521519a0995658751be3a5");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = Part2(input);
        return new PuzzleResult(result, "192dc6b2bb8fcfe7b7deaa5f30ec9f80");
    }

    public static int Part1(string input)
    {
        var groups = StringReader.ReadStringGroupsWithWhitespace(input);
        var grid = GridBuilder.BuildCharGridWithoutTrim(groups[0], ' ');
        grid.MoveTo(0, 0);
        grid.TurnTo(GridDirection.Right);
        while (grid.ReadValue() == ' ')
            grid.MoveForward();

        var path = ParsePath(groups[1]);

        foreach (var instruction in path)
        {
            var isNumeric = int.TryParse(instruction, out var stepsToMove);
            if (isNumeric)
            {
                while (stepsToMove > 0)
                {
                    var lastPos = grid.Coord;
                    var moveSucceeded = true;
                    if (grid.TryMoveForward())
                    {
                        if (grid.ReadValue() == '#')
                        {
                            grid.MoveTo(lastPos);
                            break;
                        }

                        if (grid.ReadValue() == ' ')
                            moveSucceeded = false;
                    }
                    else
                    {
                        moveSucceeded = false;
                    }

                    if (!moveSucceeded)
                    {
                        if (grid.Direction.Equals(GridDirection.Up))
                            grid.MoveTo(grid.Coord.X, grid.YMax);
                        else if (grid.Direction.Equals(GridDirection.Right))
                            grid.MoveTo(grid.XMin, grid.Coord.Y);
                        else if (grid.Direction.Equals(GridDirection.Down))
                            grid.MoveTo(grid.Coord.X, grid.YMin);
                        else
                            grid.MoveTo(grid.XMax, grid.Coord.Y);
                    }

                    while (grid.ReadValue() == ' ')
                        grid.MoveForward();

                    if (grid.ReadValue() == '#')
                    {
                        grid.MoveTo(lastPos);
                        break;
                    }

                    stepsToMove--;
                }
            }
            else
            {
                if (instruction == "R")
                    grid.TurnRight();
                else
                    grid.TurnLeft();
            }
        }

        var row = grid.Coord.Y + 1;
        var col = grid.Coord.X + 1;
        var facingScore = GetFacingScore(grid.Direction);

        var password = 1000 * row + 4 * col + facingScore;

        return password;
    }

    public static int Part2(string input)
    {
        var groups = StringReader.ReadStringGroupsWithWhitespace(input);
        var grid = GridBuilder.BuildCharGridWithoutTrim(groups[0], ' ');
        grid.MoveTo(0, 0);
        grid.TurnTo(GridDirection.Right);

        while (grid.ReadValue() == ' ')
            grid.MoveForward();

        var path = ParsePath(groups[1]);

        foreach (var instruction in path)
        {
            var isNumeric = int.TryParse(instruction, out var stepsToMove);
            if (isNumeric)
            {
                while (stepsToMove > 0)
                {
                    var lastPos = grid.Coord;
                    var lastDirection = grid.Direction;
                    var moveSucceeded = true;
                    if (grid.TryMoveForward())
                    {
                        if (grid.ReadValue() == '#')
                        {
                            grid.MoveTo(lastPos);
                            break;
                        }

                        if (grid.ReadValue() == ' ')
                        {
                            grid.MoveTo(lastPos);
                            moveSucceeded = false;
                        }
                    }
                    else
                    {
                        moveSucceeded = false;
                    }

                    if (!moveSucceeded)
                    {
                        var (newCoord, newDirection) = MapExitPosition(grid.Coord, grid.Direction, 50);
                        if (grid.TryMoveTo(newCoord))
                        {
                            grid.TurnTo(newDirection);
                        }
                    }

                    if (grid.ReadValue() == '#')
                    {
                        grid.MoveTo(lastPos);
                        grid.TurnTo(lastDirection);
                        break;
                    }

                    stepsToMove--;
                }
            }
            else
            {
                if (instruction == "R")
                    grid.TurnRight();
                else
                    grid.TurnLeft();
            }
        }

        var row = grid.Coord.Y + 1;
        var col = grid.Coord.X + 1;
        var facingScore = GetFacingScore(grid.Direction);

        var password = 1000 * row + 4 * col + facingScore;

        return password;
    }

    public static (Coord newCoord, GridDirection newDirection) MapExitPosition(Coord c, GridDirection d, int size)
    {
        var x = c.X;
        var y = c.Y;

        if (d.Equals(GridDirection.Up))
        {
            if (c.X < size) // from left to front
                return (new Coord(y - size, x + size), GridDirection.Right);
            if (c.X < size * 2) // from top to back
                return (new Coord(y, x + size * 2), GridDirection.Right);
            if (c.X < size * 3) // from right to back
                return (new Coord(x - size * 2, y + size * 4 - 1), GridDirection.Up);
        }
        else if (d.Equals(GridDirection.Right))
        {
            if (c.Y < size) // from right to bottom
                return (new Coord(x - size, size * 3 - y - 1), GridDirection.Left);
            if (c.Y < size * 2) // from front to right
                return (new Coord(y + size, x - size), GridDirection.Up);
            if (c.Y < size * 3) // from bottom to right
                return (new Coord(x + size, size * 3 - y - 1), GridDirection.Left);
            if (c.Y < size * 4) // from back to bottom
                return (new Coord(y - size * 2, x + size * 2), GridDirection.Up);
        }
        else if (d.Equals(GridDirection.Down))
        {
            if (c.X < size) // from back to right
                return (new Coord(x + size * 2, y - size * 4 + 1), GridDirection.Down);
            if (c.X < size * 2) // from bottom to back
                return (new Coord(y - size * 2, x + size * 2), GridDirection.Left);
            if (c.X < size * 3) // from right to front
                return (new Coord(y + size, x - size), GridDirection.Left);
        }
        else
        {
            if (c.Y < size) // from top to left
                return (new Coord(x - size, size * 3 - y - 1), GridDirection.Right);
            if (c.Y < size * 2) // from front to left
                return (new Coord(y - size, x + size), GridDirection.Down);
            if (c.Y < size * 3) // from left to top
                return (new Coord(x + size, size * 3 - y - 1), GridDirection.Right);
            if (c.Y < size * 4) // from back to top
                return (new Coord(y - size * 2, x), GridDirection.Down);
        }

        return (new Coord(0, 0), GridDirection.Up);
    }

    private static IEnumerable<string> ParsePath(string s)
    {
        var css = s.Replace("R", ",R,").Replace("L", ",L,");
        return css.Split(',').ToArray();
    }

    private static int GetFacingScore(GridDirection d)
    {
        if (d.Equals(GridDirection.Up))
            return 3;
        if (d.Equals(GridDirection.Right))
            return 0;
        if (d.Equals(GridDirection.Down))
            return 1;
        return 2;
    }
}
