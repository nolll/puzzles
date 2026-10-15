using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Binary Boarding")]
public class Aoc202005 : AocPuzzle
{
    [Puzzle("0c707dd92ed04ceea0c32086af11620a")]
    public int Part1(string input) => ParseBoardingCards(input).Max(o => o.Id);

    [Puzzle("886c488b39cd9f4848e5a6a2358861c6")]
    public int? Part2(string input) => FindMySeat(ParseBoardingCards(input))?.Id;

    public static IEnumerable<BoardingCard> ParseBoardingCards(string input) => input.Split(LineBreaks.Single).Select(BoardingCard.Parse);

    public BoardingCard? FindMySeat(IEnumerable<BoardingCard> boardingCards)
    {
        var myRow = boardingCards
            .GroupBy(o => o.Row)
            .Where(o => o.Count() == 7)
            .OrderBy(o => o.Key)
            .First()
            .ToList();

        for (var col = 0; col < 8; col++)
        {
            if (myRow.All(o => o.Column != col))
                return new BoardingCard(myRow[0].Row, col);
        }

        return null;
    }
    
    public record BoardingCard(int Row, int Column)
    {
        public int Id { get; } = Row * 8 + Column;

        public static BoardingCard Parse(string s)
        {
            var rowInstructions = s[..7];
            var colInstructions = s[7..];

            var row = FindRow(rowInstructions);
            var col = FindCol(colInstructions);
            return new BoardingCard(row, col);
        }

        private static int FindRow(string instructions)
        {
            var rows = CreateList(128);
            foreach (var c in instructions)
            {
                var length = rows.Count;
                if (c == 'F')
                    rows.RemoveRange(length / 2, length / 2);
                else
                    rows.RemoveRange(0, length / 2);
            }

            return rows[0];
        }

        private static int FindCol(string instructions)
        {
            var cols = CreateList(8);
            foreach (var c in instructions)
            {
                var length = cols.Count;
                if (c == 'L')
                    cols.RemoveRange(length / 2, length / 2);
                else
                    cols.RemoveRange(0, length / 2);
            }

            return cols[0];
        }

        private static List<int> CreateList(int length) => [.. Enumerable.Range(0, length)];
    }
}