using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Secure Container")]
public class Aoc201904 : AocPuzzle
{
    [Puzzle("130c5099df019116c1fa98e589523b7c")]
    public int Part1(string input)
    {
        var (lowerbound, upperbound) = Parse(input);
        return new PasswordFinder().FindPart1(lowerbound, upperbound).Count();
    }

    [Puzzle("a91290a19800def81b170a8a45592c43")]
    public int Part2(string input)
    {
        var (lowerbound, upperbound) = Parse(input);
        return new PasswordFinder().FindPart2(lowerbound, upperbound).Count();
    }
    
    public class PasswordFinder
    {
        public IEnumerable<int> FindPart1(int lowerBound, int upperBound)
        {
            var passwordValidator = new PasswordValidator();

            for (var pwd = lowerBound; pwd <= upperBound; pwd++)
            {
                if (passwordValidator.IsValidPart1(pwd))
                    yield return pwd;
            }
        }

        public IEnumerable<int> FindPart2(int lowerBound, int upperBound)
        {
            var passwordValidator = new PasswordValidator();

            for (var pwd = lowerBound; pwd <= upperBound; pwd++)
            {
                if (passwordValidator.IsValidPart2(pwd))
                    yield return pwd;
            }
        }
    }

    private static (int, int) Parse(string input)
    {
        var (a, b) = input.Split('-');
        return (int.Parse(a), int.Parse(b));
    }
    
    public static class PasswordAnalyzer
    {
        public static bool HasGroupOfTwo(IEnumerable<char> chars)
        {
            var groups = GetGroups(chars).Select(o => o.Count());
            return groups.Any(o => o == 2);
        }

        public static bool HasGroup(IEnumerable<char> chars)
        {
            var groups = GetGroups(chars).Select(o => o.Count());
            return groups.Any(o => o >= 2);
        }

        private static IEnumerable<IEnumerable<char>> GetGroups(IEnumerable<char> chars)
        {
            var lastChar = ' ';
            var groups = new List<IEnumerable<char>>();
            IList<char> currentGroup = new List<char>();
            foreach (var c in chars)
            {
                if (c == lastChar)
                {
                    currentGroup.Add(c);
                }
                else
                {
                    currentGroup = new List<char> { c };
                    groups.Add(currentGroup);
                }

                lastChar = c;
            }

            return groups;
        }
    }
    
    public class PasswordValidator
    {
        public bool IsValidPart1(int pwd)
        {
            var chars = pwd.ToString().ToCharArray();
            var hasPair = PasswordAnalyzer.HasGroup(chars);
            if (!hasPair)
                return false;

            var hasCorrectOrder = HasCorrectOrder(chars);
            if (!hasCorrectOrder)
                return false;

            return true;
        }

        public bool IsValidPart2(int pwd)
        {
            var chars = pwd.ToString().ToCharArray();
            var hasPair = PasswordAnalyzer.HasGroupOfTwo(chars);
            if (!hasPair)
                return false;

            var hasCorrectOrder = HasCorrectOrder(chars);
            if (!hasCorrectOrder)
                return false;

            return true;
        }

        private static bool HasCorrectOrder(IEnumerable<char> chars)
        {
            var lastChar = ' ';
            foreach (var c in chars)
            {
                if (c < lastChar)
                    return false;

                lastChar = c;
            }

            return true;
        }
    }
}