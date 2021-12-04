using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.Bingo
{
    public class BingoGame
    {
        private readonly IList<int> _numbers;
        private readonly IDictionary<int, BingoBoard> _boards;

        public BingoGame(string input)
        {
            var groups = PuzzleInputReader.ReadStringGroups(input);
            _numbers = groups.First().Split(',').Select(int.Parse).ToList();
            _boards = ParseBoards(groups.Skip(1));
        }

        public int Play(bool findLastWinner)
        {
            foreach (var number in _numbers)
            {
                MarkNumber(number);
                var boardsWithBingo = _boards.Values.Where(o => o.HasBingo).ToList();
                    if (boardsWithBingo.Any())
                {
                    var currentBoard = boardsWithBingo.First();
                    
                    if (!findLastWinner)
                        return CalculateScore(currentBoard, number);

                    foreach (var board in boardsWithBingo)
                    {
                        _boards.Remove(board.Id);
                    }

                    if (!_boards.Any())
                        return CalculateScore(currentBoard, number);
                }
            }

            return 0;
        }

        private int CalculateScore(BingoBoard board, in int number)
        {
            return board.Score * number;
        }
        
        private void MarkNumber(in int number)
        {
            foreach (var board in _boards.Values)
            {
                board.MarkNumber(number);
            }
        }

        private Dictionary<int, BingoBoard> ParseBoards(IEnumerable<string> inputs)
        {
            var d = new Dictionary<int, BingoBoard>();
            var i = 0;
            foreach (var input in inputs)
            {
                d.Add(i, new BingoBoard(i, MatrixBuilder.BuildIntMatrix(input), new Matrix<bool>(5, 5)));
                i++;
            }

            return d;
        }
    }

    public class BingoBoard
    {
        public int Id { get; }
        private readonly Matrix<int> _numbers;
        private readonly Matrix<bool> _marks;
        private IList<MatrixAddress> _coords;

        public BingoBoard(int id, Matrix<int> numbers, Matrix<bool> marks)
        {
            Id = id;
            _numbers = numbers;
            _marks = marks;
            _coords = _numbers.Coords;
        }

        public void MarkNumber(in int number)
        {
            foreach (var coord in _coords)
            {
                if (_numbers.ReadValueAt(coord) == number)
                {
                    _marks.MoveTo(coord);
                    _marks.WriteValue(true);
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