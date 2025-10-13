using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq14;

[Name("That's a bingo")]
public class Aquaq14 : AquaqPuzzle
{
    private const int BoardSize = 5;
    
    private const string BoardInput = """
                                      6  17 34 50 68
                                      10 21 45 53 66
                                      5  25 36 52 69
                                      14 30 33 54 63
                                      15 23 41 51 62
                                      """;

    private static readonly int[] Range = Enumerable.Range(0, BoardSize).ToArray();
    private static readonly Dictionary<int, Coord> Board = BuildBoard();
    private static readonly IEnumerable<Coord> Diagonal1 = BuildDiagonal1();
    private static readonly IEnumerable<Coord> Diagonal2 = BuildDiagonal2();

    public PuzzleResult Run(string input)
    {
        var result = PlayBingo(input);
        return new PuzzleResult(result, "d9665f8161f8ada6709d7be1564965fa");
    }

    public static int PlayBingo(string input)
    {
        var games = StringReader.ReadLines(input).Select(o => o.Split(' ').Select(int.Parse));

        var totalSum = 0;
        foreach (var numbers in games)
        {
            var numberCount = 0;
            var game = new List<Coord>();
            foreach (var number in numbers)
            {
                numberCount++;
                if(Board.TryGetValue(number, out var address))
                {
                    game.Add(address);

                    if (IsBingo(game))
                        break;
                }
            }

            totalSum += numberCount;
        }

        return totalSum;
    }

    private static Dictionary<int, Coord> BuildBoard()
    {
        var boardLines = StringReader.ReadLines(BoardInput.Replace("  ", " "));
        var board = new Dictionary<int, Coord>();

        var y = 0;
        foreach (var boardLine in boardLines)
        {
            var lineNumbers = boardLine.Split(' ').Select(int.Parse);
            var x = 0;
            foreach (var lineNumber in lineNumbers)
            {
                var address = new Coord(x, y);
                board.Add(lineNumber, address);
                x += 1;
            }

            y += 1;
        }

        return board;
    }

    private static bool IsBingo(IReadOnlyCollection<Coord> game) 
        => IsHorizontalBingo(game) || IsVerticalBingo(game) || IsDiagonalBingo(game);

    private static bool IsHorizontalBingo(IEnumerable<Coord> game)
        => game.GroupBy(o => o.X).Any(o => o.Count() == 5);

    private static bool IsVerticalBingo(IEnumerable<Coord> game)
        => game.GroupBy(o => o.Y).Any(o => o.Count() == 5);

    private static bool IsDiagonalBingo(IReadOnlyCollection<Coord> game) 
        => Diagonal1.All(game.Contains) || Diagonal2.All(game.Contains);

    private static IEnumerable<Coord> BuildDiagonal1() 
        => Range.Select(o => new Coord(o, o));

    private static IEnumerable<Coord> BuildDiagonal2()
        => Range.Select(o => new Coord(BoardSize - o - 1, o));
}