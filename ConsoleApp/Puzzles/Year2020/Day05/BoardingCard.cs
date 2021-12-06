using System.Collections.Generic;

namespace ConsoleApp.Puzzles.Year2020.Day05
{
    public class BoardingCard
    {
        public int Row { get; }
        public int Column { get; }
        public int Id { get; }

        public BoardingCard(int row, int col)
        {
            Row = row;
            Column = col;
            Id = row * 8 + col;
        }

        public static BoardingCard Parse(string s)
        {
            var rowInstructions = s.Substring(0, 7);
            var colInstructions = s.Substring(7);

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
                {
                    rows.RemoveRange(length / 2, length / 2);
                }
                else
                {
                    rows.RemoveRange(0, length / 2);
                }
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
                {
                    cols.RemoveRange(length / 2, length / 2);
                }
                else
                {
                    cols.RemoveRange(0, length / 2);
                }
            }

            return cols[0];
        }

        private static List<int> CreateList(int length)
        {
            var list = new List<int>();
            for (var i = 0; i < length; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}