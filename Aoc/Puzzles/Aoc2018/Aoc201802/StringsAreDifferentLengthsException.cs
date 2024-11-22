namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201802;

public class StringsAreDifferentLengthsException : Exception
{
    public StringsAreDifferentLengthsException(string str1, string str2) : base($"Strings {str1} and {str2} are different length.")
    {
    }
}