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
        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        var result = Part2(FileInput);
        return new PuzzleResult(result);
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

    public int Part2(string input)
    {
        var groups = PuzzleInputReader.ReadStringGroupsWithWhitespace(input);
        var matrix = MatrixBuilder.BuildQuickCharMatrixWithoutTrim(groups[0], ' ');
        matrix.MoveTo(0, 0);
        matrix.TurnTo(MatrixDirection.Right);

        //var sides = MapSides(matrix);

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
                            moveSucceeded = false;
                    }
                    else
                    {
                        moveSucceeded = false;
                    }

                    if (!moveSucceeded)
                    {
                        if (matrix.Direction.Equals(MatrixDirection.Up))
                        {
                            if (matrix.Address.X < 50) // from left to front
                            {
                                // todo: map x and y
                                matrix.TurnTo(MatrixDirection.Right);
                            }
                            else if (matrix.Address.X < 100) // from top to back
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                            else if (matrix.Address.X < 150) // from right
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                        }
                        else if (matrix.Direction.Equals(MatrixDirection.Right))
                        {
                            if (matrix.Address.Y < 50) // from right
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                            else if (matrix.Address.Y < 100) // from front
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                            else if (matrix.Address.Y < 150) // from bottom
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                            else if (matrix.Address.Y < 200) // from back
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                        }
                        else if (matrix.Direction.Equals(MatrixDirection.Down))
                        {
                            if (matrix.Address.X < 50) // from back
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                            else if (matrix.Address.X < 100) // from bottom
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                            else if (matrix.Address.X < 150) // from right
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                        }
                        else
                        {
                            if (matrix.Address.Y < 50) // from top
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                            else if (matrix.Address.Y < 100) // from front
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                            else if (matrix.Address.Y < 150) // from left
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
                            else if (matrix.Address.Y < 200) // from back
                            {
                                // todo: map x and y
                                // todo: map direction
                            }
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

    //private Dictionary<Side, CubeSide> MapSides(IMatrix<char> matrix)
    //{
    //    var totalWidth = matrix.Width;
    //    var totalHeight = matrix.Height;
    //    var mapType = totalWidth > totalHeight
    //        ? MapType.FourByThree
    //        : MapType.ThreeByFour;
    //    var size = mapType == MapType.FourByThree
    //        ? totalWidth / 4
    //        : totalHeight / 4;

    //    var blueprint = mapType == MapType.FourByThree
    //        ? GetBluePrintForFourByThree()
    //        : GetBluePrintForThreeByFour();

    //    var sides = BuildSides(blueprint, size);

    //    return sides;
    //}

    //private Dictionary<Side, CubeSide> BuildSides(Dictionary<Side, SideBlueprint> bluePrint, int size)
    //{
    //    var sides = new Dictionary<Side, CubeSide>
    //    {
    //        { Side.Top, new CubeSide(bluePrint[Side.Top], size) },
    //        { Side.Bottom, new CubeSide(bluePrint[Side.Bottom], size) },
    //        { Side.Front, new CubeSide(bluePrint[Side.Front], size) },
    //        { Side.Back, new CubeSide(bluePrint[Side.Back], size) },
    //        { Side.Left, new CubeSide(bluePrint[Side.Left], size) },
    //        { Side.Right, new CubeSide(bluePrint[Side.Right], size) }
    //    };

    //    return sides;
    //}

    //private Dictionary<Side, SideBlueprint> GetBluePrintForFourByThree()
    //{
    //    var bluePrint = new Dictionary<Side, SideBlueprint>
    //    {
    //        { Side.Top, new SideBlueprint(new MatrixAddress(2, 0), new Dictionary<MatrixDirection, NavigationRule>
    //        {
    //            { MatrixDirection.Up, new NavigationRule(MatrixDirection.Up, Side.Back, )}
    //        }) },
    //        { Side.Bottom, new SideBlueprint(new MatrixAddress(2, 2), new Dictionary<Side, NavigationRule>()) },
    //        { Side.Front, new SideBlueprint(new MatrixAddress(2, 1), new Dictionary<Side, NavigationRule>()) },
    //        { Side.Back, new SideBlueprint(new MatrixAddress(0, 1), new Dictionary<Side, NavigationRule>()) },
    //        { Side.Left, new SideBlueprint(new MatrixAddress(1, 1), new Dictionary<Side, NavigationRule>()) },
    //        { Side.Right, new SideBlueprint(new MatrixAddress(3, 2), new Dictionary<Side, NavigationRule>()) }
    //    };

    //    return bluePrint;
    //}

    //private Dictionary<Side, SideBlueprint> GetBluePrintForThreeByFour()
    //{
    //    var bluePrint = new Dictionary<Side, SideBlueprint>
    //    {
    //        { Side.Top, new SideBlueprint(new MatrixAddress(1, 0), new Dictionary<Side, NavigationRule>()) },
    //        { Side.Bottom, new SideBlueprint(new MatrixAddress(1, 2), new Dictionary<Side, NavigationRule>()) },
    //        { Side.Front, new SideBlueprint(new MatrixAddress(1, 1), new Dictionary<Side, NavigationRule>()) },
    //        { Side.Back, new SideBlueprint(new MatrixAddress(0, 3), new Dictionary<Side, NavigationRule>()) },
    //        { Side.Left, new SideBlueprint(new MatrixAddress(0, 2), new Dictionary<Side, NavigationRule>()) },
    //        { Side.Right, new SideBlueprint(new MatrixAddress(2, 0), new Dictionary<Side, NavigationRule>()) }
    //    };

    //    return bluePrint;
    //}

    //public class SideBlueprint
    //{
    //    public MatrixAddress MapLocation { get; }
    //    public Dictionary<MatrixDirection, NavigationRule> NavigationRules { get; }

    //    public SideBlueprint(MatrixAddress mapLocation, Dictionary<MatrixDirection, NavigationRule> navigationRules)
    //    {
    //        MapLocation = mapLocation;
    //        NavigationRules = navigationRules;
    //    }
    //}

    //public class NavigationRule
    //{
    //    public MatrixDirection ExitDirection { get; }
    //    public Side TargetSide { get; }
    //    public MatrixDirection TargetDirection { get; }

    //    public NavigationRule(MatrixDirection exitDirection, Side targetSide, MatrixDirection targetDirection)
    //    {
    //        ExitDirection = exitDirection;
    //        TargetSide = targetSide;
    //        TargetDirection = targetDirection;
    //    }
    //}

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

//public enum Side
//{
//    Top,
//    Bottom,
//    Front,
//    Back,
//    Left,
//    Right
//}

//public enum MapType
//{
//    FourByThree,
//    ThreeByFour
//}

//public class CubeSide
//{
//    public MatrixAddress TopLeft { get; }
//    public MatrixAddress BottomRight { get; }

//    public CubeSide(Year2022Day22.SideBlueprint blueprint, int size)
//    {
//        TopLeft = blueprint.MapLocation;
//        BottomRight = new MatrixAddress(blueprint.MapLocation.X + size - 1, blueprint.MapLocation.Y + size - 1);
//    }
//}