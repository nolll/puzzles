using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Giant Squid")]
public class Aoc202104 : AocPuzzle
{
    [Puzzle("95287604b1b5cd043b3268068d4c34ef")]
    public int Part1(string input) => Solve(input, false);

    [Puzzle("d3b6f7e7618d28f0aac8b2a2c99f5b2e")]
    public int Part2(string input) => Solve(input, true);

    public int Solve(string input, bool findLastWinner)
    {
        var (numbers, boards) = Parse(input);
        foreach (var number in numbers)
        {
            MarkNumber(boards, number);
            var boardsWithBingo = boards.Values.Where(o => o.HasBingo).ToList();
            if (boardsWithBingo.Count == 0)
                continue;
            
            var currentBoard = boardsWithBingo.First();

            if (!findLastWinner)
                return CalculateScore(currentBoard, number);

            foreach (var board in boardsWithBingo) 
                boards.Remove(board.Id);

            if (!boards.Any())
                return CalculateScore(currentBoard, number);
        }

        return 0;
    }

    private static int CalculateScore(BingoBoard board, in int number) => board.Score * number;

    private void MarkNumber(Dictionary<int, BingoBoard> boards, int number)
    {
        foreach (var board in boards.Values)
        {
            board.MarkNumber(number);
        }
    }

    private (int[], Dictionary<int, BingoBoard>) Parse(string input)
    {
        var groups = input.Trim().Split(LineBreaks.Double);
        var numbers = Numbers.IntsFromString(groups.First());
        var boards = ParseBoards(groups.Skip(1));
        return (numbers, boards);
    }

    private Dictionary<int, BingoBoard> ParseBoards(IEnumerable<string> inputs)
    {
        var d = new Dictionary<int, BingoBoard>();
        var i = 0;
        foreach (var input in inputs)
        {
            d.Add(i, new BingoBoard(i, GridBuilder.BuildIntGridFromSpaceSeparated(input), new Grid<bool>(5, 5)));
            i++;
        }

        return d;
    }

    private class BingoBoard
    {
        public int Id { get; }
        private readonly Grid<int> _numbers;
        private readonly Grid<bool> _marks;
        private readonly IList<Coord> _coords;

        public BingoBoard(int id, Grid<int> numbers, Grid<bool> marks)
        {
            Id = id;
            _numbers = numbers;
            _marks = marks;
            _coords = _numbers.Coords.ToList();
        }

        public void MarkNumber(in int number)
        {
            foreach (var coord in _coords)
            {
                if (_numbers.ReadValueAt(coord) == number)
                {
                    _marks.WriteValueAt(coord, true);
                }
            }
        }

        public bool HasBingo => HasHorizontalBingo || HasVerticalBingo;

        private bool HasHorizontalBingo
        {
            get
            {
                for (var x = 0; x < _marks.Width; x++)
                {
                    var hasBingo = true;
                    for (var y = 0; y < _marks.Height; y++)
                    {
                        if (!_marks.ReadValueAt(x, y))
                        {
                            hasBingo = false;
                            break;
                        }
                    }

                    if (hasBingo)
                        return true;
                }

                return false;
            }
        }

        private bool HasVerticalBingo
        {
            get
            {
                for (var y = 0; y < _marks.Height; y++)
                {
                    var hasBingo = true;
                    for (var x = 0; x < _marks.Width; x++)
                    {
                        if (!_marks.ReadValueAt(x, y))
                        {
                            hasBingo = false;
                            break;
                        }
                    }

                    if (hasBingo)
                        return true;
                }

                return false;
            }
        }

        public int Score
        {
            get
            {
                var score = 0;
                foreach (var coord in _coords)
                {
                    if (!_marks.ReadValueAt(coord))
                        score += _numbers.ReadValueAt(coord);
                }

                return score;
            }
        }
    }
}