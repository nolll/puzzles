using System.Collections.Generic;

namespace Core.AircraftBoarding
{
    public class BoardingCard
    {
        public int Row { get; }
        public int Column { get; }
        public int Id { get; }

        public BoardingCard(string boardingCard)
        {
            var rowInstructions = boardingCard.Substring(0, 7);
            var colInstructions = boardingCard.Substring(7);

            Row = FindRow(rowInstructions);
            Column = FindCol(colInstructions);
            Id = Row * 8 + Column;
        }
        
        private int FindRow(string instructions)
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

        private int FindCol(string instructions)
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

        private List<int> CreateList(int length)
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