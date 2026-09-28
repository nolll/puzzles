using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Inverse Captcha")]
public class Aoc201701 : AocPuzzle
{
    [Puzzle("a3151100ec696399e5149c71f7bc46c3")]
    public int Part1(string input) => GetSum(Parse(input), 1);

    [Puzzle("d29f3098be44b414da54304aa4ad0c3f")]
    public int Part2(string input) => GetSum(Parse(input), input.Length / 2);

    private static int GetSum(IList<int> numbers, int offset) => 
        FindMatchingNumbers(numbers, offset).Sum();

    private static IEnumerable<int> FindMatchingNumbers(IList<int> numbers, int offset)
    {
        for (var i = 0; i < numbers.Count; i++)
        {
            var currentValue = numbers[i];
            var nextIndex = i + offset;
            if (nextIndex > numbers.Count - 1)
            {
                nextIndex -= numbers.Count;
            }
            if (currentValue == numbers[nextIndex])
            {
                yield return currentValue;
            }
        }
    }
    
    private static List<int> Parse(string input) => 
        input.ToCharArray().Select(o => int.Parse(o.ToString())).ToList();
}