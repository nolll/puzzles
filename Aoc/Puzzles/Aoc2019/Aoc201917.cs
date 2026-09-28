using System.Text;
using Pzl.Common;
using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Set and Forget")]
public class Aoc201917 : AocPuzzle
{
    [Puzzle("8e35e428c486ee717b90ef52086fa0d3")]
    public int Part1(string input)
    {
        var sc = new ScaffoldingComputer1(input);
        return new ScaffoldIntersectionFinder(sc.Run()).GetSumOfAlignmentParameters();
    }

    [Puzzle("8972452161d6f5ef5e3681d5ce31f9b6")]
    public long Part2(string input) => new ScaffoldingComputer2(input).Run();
    
    public class ScaffoldIntersectionFinder
    {
        private readonly Grid<char> _grid;

        public ScaffoldIntersectionFinder(string input)
        {
            _grid = BuildGrid(input);
        }

        public int GetSumOfAlignmentParameters()
        {
            var intersections = GetIntersections().ToList();
            var sum = intersections.Sum(o => o.X * o.Y);
            return sum;
        }

        private IEnumerable<Coord> GetIntersections()
        {
            return _grid.Coords.Where(coord => IsIntersection(coord.X, coord.Y)).ToList();
        }

        private char? GetValueAt(Coord coord)
        {
            if (_grid.IsOutOfRange(coord))
                return null;
            return _grid.ReadValueAt(coord);
        }

        private bool IsIntersection(int x, int y)
        {
            var v = GetValueAt(new Coord(x, y));
            if (v == '.')
                return false;

            v = GetValueAt(new Coord(x, y - 1));
            if (v == '.')
                return false;

            v = GetValueAt(new Coord(x + 1, y));
            if (v == '.')
                return false;

            v = GetValueAt(new Coord(x, y + 1));
            if (v == '.')
                return false;

            v = GetValueAt(new Coord(x - 1, y));
            if (v == '.')
                return false;

            return true;
        }

        private Grid<char> BuildGrid(string map)
        {
            var grid = new Grid<char>();
            var rows = map.Trim().Split('\n');
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
    }
    
    public class ScaffoldingComputer1
    {
        private readonly IntCodeComputer _computer;
        private readonly StringBuilder _sb;

        public ScaffoldingComputer1(string program)
        {
            _sb = new StringBuilder();
            _computer = new IntCodeComputer(program, ReadInput, WriteOutput);
        }

        public string Run()
        {
            _computer.Start();
            return _sb.ToString();
        }

        private long ReadInput()
        {
            return 0;
        }

        private bool WriteOutput(long output)
        {
            _sb.Append((char)output);
            return true;
        }
    }
    
    public class ScaffoldingComputer2
    {
        private readonly IntCodeComputer _computer;
        private long _output;

        private const string MainRoutine = "A,B,A,C,B,C,A,B,A,C";
        private const string FunctionA = "R,6,L,10,R,8,R,8";
        private const string FunctionB = "R,12,L,8,L,10";
        private const string FunctionC = "R,12,L,10,R,6,L,10";

        private readonly IList<int> _inputSequence;

        public ScaffoldingComputer2(string program)
        {
            _computer = new IntCodeComputer($"2{program[1..]}", ReadInput, WriteOutput);
            _inputSequence = BuildInputSequence();
        }

        private IList<int> BuildInputSequence()
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

        public long Run()
        {
            _computer.Start();
            return _output;
        }

        private long ReadInput()
        {
            if (_inputSequence.Any())
            {
                var val = _inputSequence.First();
                _inputSequence.RemoveAt(0);
                return val;
            }

            return 0;
        }

        private bool WriteOutput(long output)
        {
            _output = output;
            return true;
        }
    }
}