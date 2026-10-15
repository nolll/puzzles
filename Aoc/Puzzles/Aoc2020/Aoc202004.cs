using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Passport Processing")]
public class Aoc202004 : AocPuzzle
{
    [Puzzle("1e10a803d525ec160795a9bed9161106")]
    public int Part1(string input) => ParsePassports(input).Count(o => o.HasAllFields());

    [Puzzle("4648ca473c884f7676991b343c2db8e0")]
    public int Part2(string input) => ParsePassports(input).Count(o => o.IsValid());

    private static IEnumerable<Passport> ParsePassports(string input) => input
        .Replace(LineBreaks.Double, "--")
        .Replace(LineBreaks.Single, " ")
        .Replace("--", LineBreaks.Single)
        .Split(LineBreaks.Single).Select(o => new Passport(o));

    public class Passport
    {
        private const string BirthYear = "byr";
        private const string IssueYear = "iyr";
        private const string ExpirationYear = "eyr";
        private const string Height = "hgt";
        private const string HairColor = "hcl";
        private const string EyeColor = "ecl";
        private const string PassportId = "pid";

        private readonly IDictionary<string, string> _props = new Dictionary<string, string>();

        public Passport(string input)
        {
            var props = input.Split(' ');
            foreach (var p in props)
            {
                var (key, value) = p.Split(':');
                _props.Add(key, value);
            }
        }

        private string? GetValue(string key) => _props.TryGetValue(key, out var value)
            ? value
            : null;

        public bool HasAllFields() =>
            GetValue(BirthYear) != null &&
            GetValue(IssueYear) != null &&
            GetValue(ExpirationYear) != null &&
            GetValue(Height) != null &&
            GetValue(HairColor) != null &&
            GetValue(EyeColor) != null &&
            GetValue(PassportId) != null;

        public bool IsValid() =>
            IsBirthYearValid &&
            IsIssueYearValid &&
            IsExpirationYearValid &&
            IsHeightValid &&
            IsHairColorValid &&
            IsEyeColorValid &&
            IsPassportIdValid;

        private bool IsBirthYearValid => IsIntBetween(GetValue(BirthYear), 1920, 2002);
        private bool IsIssueYearValid => IsIntBetween(GetValue(IssueYear), 2010, 2020);
        private bool IsExpirationYearValid => IsIntBetween(GetValue(ExpirationYear), 2020, 2030);

        private bool IsEyeColorValid => GetValue(EyeColor) is "amb" or "blu" or "brn" or "gry" or "grn" or "hzl" or "oth";

        private bool IsPassportIdValid
        {
            get
            {
                var v = GetValue(PassportId);
                return v is { Length: 9 } && IsDigitsOnly(v);
            }
        }

        private bool IsHeightValid
        {
            get
            {
                var v = GetValue(Height);

                if (v == null)
                    return false;

                var isCm = v.EndsWith("cm");
                var isIn = v.EndsWith("in");
                if (!isCm && !isIn)
                    return false;

                v = v.Replace("cm", "").Replace("in", "");

                if (!IsDigitsOnly(v))
                    return false;

                return isCm 
                    ? IsIntBetween(v, 150, 193) 
                    : IsIntBetween(v, 59, 76);
            }
        }

        private bool IsHairColorValid
        {
            get
            {
                var v = GetValue(HairColor);

                if (v == null)
                    return false;

                if (!v.StartsWith('#'))
                    return false;

                v = v.Replace("#", "");

                if (v.Length != 6)
                    return false;

                return IsHexCharsOnly(v);
            }
        }

        private static bool IsIntBetween(string? s, int from, int to)
        {
            if (s == null)
                return false;

            if (!IsDigitsOnly(s))
                return false;

            var v = int.Parse(s);
            return v >= from && v <= to;
        }

        private static bool IsDigitsOnly(string? s) => s != null && s.All(IsDigit);
        private static bool IsHexCharsOnly(string s) => s.All(IsHexChar);
        private static bool IsDigit(char c) => IsBetween(c, '0', '9');
        private static bool IsHexChar(char c) => IsDigit(c) || IsBetween(c, 'a', 'f');
        private static bool IsBetween(char c, char from, char to) => c >= from && c <= to;
    }
}