using System.Collections.Generic;
using System.Linq;

namespace Core.Spreadsheets
{
    public class Spreadsheet
    {
        public int Checksum { get; }

        public Spreadsheet(string input)
        {
            var numberRows = GetNumbers(input);
            foreach (var row in numberRows)
            {
                Checksum += row.Max() - row.Min();
            }
        }

        private IList<IList<int>> GetNumbers(string input)
        {
            var stringRows = input.Replace("\t", " ").Trim().Split("\n").Select(o => o.Trim());
            var numberRows = new List<IList<int>>();
            foreach (var strRow in stringRows)
            {
                var numbers = strRow.Split(" ").Select(o => int.Parse(o.Trim())).ToList();
                numberRows.Add(numbers);
            }

            return numberRows;
        }
    }
}