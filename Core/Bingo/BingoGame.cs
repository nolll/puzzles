using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.Bingo
{
    public class BingoGame
    {
        private readonly IList<int> _numbers;
        private readonly IList<BingoBoard> _boards;

        public BingoGame(string input)
        {
            var groups = PuzzleInputReader.ReadStringGroups(input);
            _numbers = groups.First().Split(',').Select(int.Parse).ToList();
            _boards = ParseBoards(groups.Skip(1)).ToList();
        }

        public int Play()
        {
            var score = 0;
            foreach (var number in _numbers)
            {
                MarkNumber(number);
                var boardWithBingo = _boards.FirstOrDefault(o => o.HasBingo);
                if (boardWithBingo != null)
                {
                    score = CalculateScore(boardWithBingo, number);
                    break;
                }
            }

            return score;
        }

        private int CalculateScore(BingoBoard board, in int number)
        {
            return board.Score * number;
        }
        
        private void MarkNumber(in int number)
        {
            foreach (var board in _boards)
            {
                board.MarkNumber(number);
            }
        }

        private IEnumerable<BingoBoard> ParseBoards(IEnumerable<string> inputs)
        {
            return inputs.Select(input => new BingoBoard(MatrixBuilder.BuildIntMatrix(input), new Matrix<bool>(5, 5)));
        }
    }

    public class BingoBoard
    {
        public Matrix<int> Numbers { get; }
        public Matrix<bool> Marks { get; }

        public BingoBoard(Matrix<int> numbers, Matrix<bool> marks)
        {
            Numbers = numbers;
            Marks = marks;
        }

        public void MarkNumber(in int number)
        {
            var coords = Numbers.Coords;
            foreach (var coord in coords)
            {
                if (Numbers.ReadValueAt(coord) == number)
                {
                    Marks.MoveTo(coord);
                    Marks.WriteValue(true);
                }
            }
        }

        public bool HasBingo => HasHorizontalBingo || HasVerticalBingo;

        private bool HasHorizontalBingo
        {
            get
            {
                for (var x = 0; x < Marks.Width; x++)
                {
                    var hasBingo = true;
                    for (var y = 0; y < Marks.Height; y++)
                    {
                        if (!Marks.ReadValueAt(x, y))
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
                for (var y = 0; y < Marks.Height; y++)
                {
                    var hasBingo = true;
                    for (var x = 0; x < Marks.Width; x++)
                    {
                        if (!Marks.ReadValueAt(x, y))
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
                var coords = Marks.Coords;
                var score = 0;
                foreach (var coord in coords)
                {
                    if (!Marks.ReadValueAt(coord))
                        score += Numbers.ReadValueAt(coord);
                }

                return score;
            }
        }
    }
}