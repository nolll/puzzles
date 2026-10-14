using System.Text;
using Pzl.Common;
using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Set and Forget")]
public class Aoc201917 : AocPuzzle
{
    private const string MainRoutine = "A,B,A,C,B,C,A,B,A,C";
    private const string FunctionA = "R,6,L,10,R,8,R,8";
    private const string FunctionB = "R,12,L,8,L,10";
    private const string FunctionC = "R,12,L,10,R,6,L,10";
    
    [Puzzle("8e35e428c486ee717b90ef52086fa0d3")]
    public int Part1(string input) => GetSumOfAlignmentParameters(RunPart1(input));
    
    [Puzzle("8972452161d6f5ef5e3681d5ce31f9b6")]
    public long Part2(string input)
    {
        var output = 0L;
        var inputSequence = BuildInputSequence();
        var computer = new IntCodeComputer($"2{input[1..]}", () =>
        {
            if (!inputSequence.Any())
                return 0;

            var val = inputSequence.First();
            inputSequence.RemoveAt(0);
            return val;
        }, o =>
        {
            output = o;
            return true;
        });

        computer.Start();
        return output;
    }

    public int GetSumOfAlignmentParameters(string input) => GetSumOfAlignmentParameters(BuildGrid(input));
    private int GetSumOfAlignmentParameters(Grid<char> grid) => grid.Coords.Where(coord => IsIntersection(grid, coord)).Sum(o => o.X * o.Y);

    private static char? GetValueAt(Grid<char> grid, Coord coord) => grid.IsOutOfRange(coord)
        ? null
        : grid.ReadValueAt(coord);

    private static bool IsIntersection(Grid<char> grid, Coord coord)
    {
        var v = GetValueAt(grid, coord);
        if (v == '.')
            return false;

        v = GetValueAt(grid, coord.Up);
        if (v == '.')
            return false;

        v = GetValueAt(grid, coord.Right);
        if (v == '.')
            return false;

        v = GetValueAt(grid, coord.Down);
        if (v == '.')
            return false;

        v = GetValueAt(grid, coord.Left);
        if (v == '.')
            return false;

        return true;
    }

    private static string RunPart1(string input)
    {
        var sb = new StringBuilder();
        var computer = new IntCodeComputer(input, () => 0, output =>
        {
            sb.Append((char)output);
            return true;
        });

        computer.Start();
        return sb.ToString();
    }

    private static Grid<char> BuildGrid(string map)
    {
        var grid = new Grid<char>();
        var rows = map.Trim().Split(LineBreaks.Single);
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                grid.MoveTo(x, y);
                grid.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }

    private static IList<int> BuildInputSequence()
    {
        var inputSequence = new List<int>();
        inputSequence.AddRange(MainRoutine.ToCharArray().Select(o => (int)o));
        inputSequence.Add(10);
        inputSequence.AddRange(FunctionA.ToCharArray().Select(o => (int)o));
        inputSequence.Add(10);
        inputSequence.AddRange(FunctionB.ToCharArray().Select(o => (int)o));
        inputSequence.Add(10);
        inputSequence.AddRange(FunctionC.ToCharArray().Select(o => (int)o));
        inputSequence.Add(10);
        inputSequence.Add('n');
        inputSequence.Add(10);

        return inputSequence;
    }
}