namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201701;

public class CaptchaCalculator
{
    public int Sum1 { get; }
    public int Sum2 { get; }

    public CaptchaCalculator(string input)
    {
        var numbers = input.ToCharArray().Select(o => int.Parse((string) o.ToString())).ToList();

        Sum1 = GetSum(numbers, 1);
        Sum2 = GetSum(numbers, numbers.Count / 2);
    }

    private static int GetSum(IList<int> numbers, int offset)
    {
        var matchingNumbers = new List<int>();
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
                matchingNumbers.Add(currentValue);
            }
        }

        return matchingNumbers.Sum();
    }
}