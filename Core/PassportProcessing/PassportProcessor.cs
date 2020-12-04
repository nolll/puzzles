using System.Linq;
using Core.Tools;

namespace Core.PassportProcessing
{
    public class PassportProcessor
    {
        public int GetValidPassportCount(string input)
        {
            var rows = PuzzleInputReader.Read(input.Replace("\r\n\r\n", "--").Replace("\r\n", " ").Replace("--", "\r\n"));
            return rows.Count(IsValid);
        }

        public bool IsValid(string input)
        {
            return input.Contains("byr") &&
                   input.Contains("iyr") &&
                   input.Contains("eyr") &&
                   input.Contains("hgt") &&
                   input.Contains("hcl") &&
                   input.Contains("ecl") &&
                   input.Contains("pid");
        }
    }
}