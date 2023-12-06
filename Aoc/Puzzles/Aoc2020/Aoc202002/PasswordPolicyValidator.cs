namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202002;

public class PasswordPolicyValidator
{
    public bool IsValidAccordingToRuleOne(string policy)
    {
        var parts = policy.Split(':');
        var ruleParts = parts[0].Split(' ');
        var c = ruleParts[1][0];
        var pwd = parts[1].Trim();
        var bounds = ruleParts[0].Split('-');
        var lowerBound = int.Parse(bounds[0]);
        var upperBound = int.Parse(bounds[1]);

        var pwdLetters = pwd.ToCharArray();
        var validLetters = pwdLetters.Where(o => o == c);
        var validLetterCount = validLetters.Count();

        return validLetterCount >= lowerBound && validLetterCount <= upperBound;
    }

    public bool IsValidAccordingToRuleTwo(string policy)
    {
        var parts = policy.Split(':');
        var ruleParts = parts[0].Split(' ');
        var c = ruleParts[1][0];
        var pwd = parts[1].Trim();
        var positions = ruleParts[0].Split('-');
        var firstPosition = int.Parse(positions[0]) - 1;
        var secondPosition = int.Parse(positions[1]) - 1;

        var firstMatch = pwd[firstPosition] == c;
        var secondMatch = pwd[secondPosition] == c;
        var isBothMatch = firstMatch && secondMatch;
        var isOneMatch = firstMatch || secondMatch;

        return isOneMatch && !isBothMatch;
    }
}