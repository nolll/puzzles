using System.Threading;
using NUnit.Framework.Constraints;
using Puzzles.common.Puzzles;

namespace Puzzles.aquaq.Puzzles.Aquaq37;

public class Aquaq37 : AquaqPuzzle
{
    public override string Name => "GUESS WORDS";

    protected override PuzzleResult Run()
    {
        var words = FindWords(InputFile);
        var score = words.Sum(GetWordScore);

        return new PuzzleResult(score);
    }

    public List<string> FindWords(string input)
    {
        var words = CommonTextFile("Words.txt")
            .Split(Environment.NewLine)
            .Where(o => o.Length == 5)
            .ToList();

        var guesses = input
            .Split(Environment.NewLine)
            .Skip(1)
            .Select(ParseGuess)
            .ToList();
        var guessSections = new List<List<Guess>>();

        var currentList = new List<Guess>();
        var lastCorrectCount = 0;
        foreach (var guess in guesses)
        {
            if (guess.CorrectCount < lastCorrectCount)
            {
                guessSections.Add(currentList);
                currentList = new List<Guess>();
            }

            lastCorrectCount = guess.CorrectCount;

            currentList.Add(guess);
        }
        guessSections.Add(currentList);

        return FindWords(words, guessSections);
    }

    public static List<string> FindWords(List<string> words, List<List<Guess>> guessSections)
    {
        return guessSections.Select(o => FindNextWord(words, o)).ToList();
    }

    public static string FindNextWord(List<string> words, List<Guess> guesses)
    {
        var used = guesses.Select(o => o.Word).ToHashSet();
        var blockedChars = guesses.SelectMany(o => o.BlockedChars()).Distinct().ToHashSet();
        var lastGuess = guesses.Last();
        var matchingWords = words
            .Where(o => 
                lastGuess.IsMatch(o) && 
                !used.Contains(o));

        var matchingWords2 = matchingWords.Where(o => !ContainsBlockedChar(o, blockedChars));
        var matchingWord = matchingWords2.FirstOrDefault();
        if (matchingWord is not null)
        {
            return matchingWord;
        }

        Console.WriteLine(lastGuess.Word);
        throw new Exception();
    }

    private static bool ContainsBlockedChar(string word, HashSet<char> blockedChars) 
        => word.Any(blockedChars.Contains);

    public static Guess ParseGuess(string s)
    {
        var parts = s.Split(',');
        var word = parts[0];
        var results = parts[1].Split(' ').Select(int.Parse).ToArray();

        return new Guess(word, results);
    }

    public static int GetWordScore(string word) => word.Select(o => o - 'a').Sum();

    public record Guess(string Word, int[] Result)
    {
        public int CorrectCount => Result.Count(o => o == 2);

        public bool IsMatch(string other)
        {
            for (var i = 0; i < 5; i++)
            {
                if (Result[i] == 2 && other[i] != Word[i])
                    return false;
            }

            return true;
        }

        public char[] BlockedChars()
        {
            var correctChars = CorrectChars();
            return Word.Where(o => !correctChars.Contains(o)).ToArray();
        }

        private HashSet<char> CorrectChars()
        {
            var corrext = new List<char>();

            for (var i = 0; i < 5; i++)
            {
                if (Result[i] == 1 || Result[i] == 2)
                    corrext.Add(Word[i]);
            }

            return corrext.Distinct().ToHashSet();
        }
    };
}