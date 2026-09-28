using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Corruption Checksum")]
public class Aoc201702 : AocPuzzle
{
    [Puzzle("d61d3967c55f3affc9cb3db5d9bb4c39")]
    public int Part1(string input) => new Spreadsheet(input).ChecksumMaxMin;

    [Puzzle("cde27fe58ccb82229c3aa108e113d5bb")]
    public int Part2(string input) => new Spreadsheet(input).ChecksumDivision;
    
    public class Spreadsheet
    {
        public int ChecksumMaxMin { get; }
        public int ChecksumDivision { get; }

        public Spreadsheet(string input)
        {
            var numberRows = GetNumbers(input);
            ChecksumMaxMin = GetChecksumMaxMin(numberRows);
            ChecksumDivision = GetChecksumDivision(numberRows);
        }

        private int GetChecksumMaxMin(IList<IList<int>> numberRows)
        {
            return numberRows.Sum(row => row.Max() - row.Min());
        }

        private int GetChecksumDivision(IList<IList<int>> numberRows)
        {
            var checksum = 0;
            foreach (var row in numberRows)
            {
                foreach (var num1 in row)
                {
                    foreach (var num2 in row)
                    {
                        if (num1 != num2 && num1 % num2 == 0)
                        {
                            checksum += num1 / num2;
                        }
                    }
                }
            }

            return checksum;
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