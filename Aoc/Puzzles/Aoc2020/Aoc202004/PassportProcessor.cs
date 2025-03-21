using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202004;

public class PassportProcessor
{
    private readonly IList<Passport> _passports;

    public PassportProcessor(string input)
    {
        var rows = StringReader.ReadLines(input.Replace(LineBreaks.Double, "--").Replace(LineBreaks.Single, " ").Replace("--", LineBreaks.Single));
        _passports = rows.Select(o => new Passport(o.Trim())).ToList();
    }

    public int GetNumberOfPassportsThatHasAllFields()
    {
        return _passports.Count(o => o.HasAllFields());
    }

    public int GetNumberOfValidPassports()
    {
        return _passports.Count(o => o.IsValid());
    }

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
                var parts = p.Split(':');
                var key = parts[0].Trim();
                var value = parts[1].Trim();

                _props.Add(key, value);
            }
        }

        private string? GetValue(string key)
        {
            return _props.TryGetValue(key, out var value)
                ? value
                : null;
        }

        public bool HasAllFields()
        {
            return GetValue(BirthYear) != null &&
                   GetValue(IssueYear) != null &&
                   GetValue(ExpirationYear) != null &&
                   GetValue(Height) != null &&
                   GetValue(HairColor) != null &&
                   GetValue(EyeColor) != null &&
                   GetValue(PassportId) != null;
        }

        public bool IsValid()
        {
            return IsBirthYearValid &&
                   IsIssueYearValid &&
                   IsExpirationYearValid &&
                   IsHeightValid &&
                   IsHairColorValid &&
                   IsEyeColorValid &&
                   IsPassportIdValid;
        }

        private bool IsBirthYearValid => IsIntBetween(GetValue(BirthYear), 1920, 2002);
        private bool IsIssueYearValid => IsIntBetween(GetValue(IssueYear), 2010, 2020);
        private bool IsExpirationYearValid => IsIntBetween(GetValue(ExpirationYear), 2020, 2030);

        private bool IsEyeColorValid
        {
            get
            {
                var v = GetValue(EyeColor);
                return v is "amb" or "blu" or "brn" or "gry" or "grn" or "hzl" or "oth";
            }
        }

        private bool IsPassportIdValid
        {
            get
            {
                var v = GetValue(PassportId);
                return v != null && v.Length == 9 && IsDigitsOnly(v);
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

                if (isCm)
                    return IsIntBetween(v, 150, 193);

                return IsIntBetween(v, 59, 76);
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
            
        private bool IsIntBetween(string? s, int from, int to)
        {
            if (s == null)
                return false;

            if (!IsDigitsOnly(s))
                return false;

            var v = int.Parse(s);
            return v >= from && v <= to;
        }

        private static bool IsDigitsOnly(string? s)
        {
            return s != null && s.All(IsDigit);
        }

        private static bool IsHexCharsOnly(string s)
        {
            return s != null && s.All(IsHexChar);
        }

        private static bool IsDigit(char c)
        {
            return IsBetween(c, '0', '9');
        }

        private static bool IsHexChar(char c)
        {
            return IsDigit(c) || IsBetween(c, 'a', 'f');
        }

        private static bool IsBetween(char c, char from, char to)
        {
            return c >= from && c <= to;
        }
    }
}