namespace Pzl.Tools.Strings;

public class NumberAsString(int number)
{
    public override string ToString()
    {
        var s = number.ToString();

        return s.Length switch
        {
            4 => GetWordsForFourDigits(),
            3 => GetWordsForThreeDigits(number),
            2 => GetWordsForTwoDigits(number),
            _ => GetWordsForOneDigit(number)
        };
    }

    private static string GetWordsForOneDigit(int n) => n switch
    {
        1 => "one",
        2 => "two",
        3 => "three",
        4 => "four",
        5 => "five",
        6 => "six",
        7 => "seven",
        8 => "eight",
        9 => "nine",
        _ => ""
    };

    private string GetWordsForTwoDigits(int n) => n < 20
        ? GetWordsForLowTwoDigits(n)
        : GetWordsForHighTwoDigits(n);

    private string GetWordsForHighTwoDigits(int n)
    {
        var s = n.ToString();
        var tens = GetWordsForTens(int.Parse(s[..1]));
        var rest = s[1..];
        var singles = GetWordsForTwoDigits(int.Parse(rest));

        return $"{tens}{singles}";
    }

    private static string GetWordsForTens(int n)
    {
        return n switch
        {
            2 => "twenty",
            3 => "thirty",
            4 => "forty",
            5 => "fifty",
            6 => "sixty",
            7 => "seventy",
            8 => "eighty",
            9 => "ninety",
            _ => throw new ArgumentException($"{n} is out of range")
        };
    }

    private string GetWordsForThreeDigits(int n)
    {
        var s = n.ToString();
        var hundreds = GetWordsForHundreds(int.Parse(s[..1]));
        var rest = s[1..];
        var tens = GetWordsForTwoDigits(int.Parse(rest));
            
        return tens.Length > 0
            ? $"{hundreds} and {tens}"
            : hundreds;
    }

    private static string GetWordsForLowTwoDigits(int n)
    {
        if (n < 10)
            return GetWordsForOneDigit(n);

        return n switch
        {
            10 => "ten",
            11 => "eleven",
            12 => "twelve",
            13 => "thirteen",
            14 => "fourteen",
            15 => "fifteen",
            16 => "sixteen",
            17 => "seventeen",
            18 => "eighteen",
            19 => "nineteen",
            _ => throw new ArgumentException($"{n} is out of range")
        };
    }

    private static string GetWordsForFourDigits() => "one thousand";

    private static string GetWordsForHundreds(int n) => 
        $"{GetWordsForOneDigit(n)} hundred";
}