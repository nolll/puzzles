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

        return FindWords(words, guesses);
    }

    public static List<string> FindWords(List<string> words, List<Guess> guesses)
    {
        var foundWords = new List<string>();
        var used = new HashSet<string>();
        var blockedChars = new HashSet<char>();
        var remainingGuesses = guesses.ToList();
        var matchingWords = words.ToList();
        while (remainingGuesses.Any())
        {
            var guess = remainingGuesses.First();
            remainingGuesses = remainingGuesses.Skip(1).ToList();
            used.Add(guess.Word);
            foreach (var blockedChar in guess.BlockedChars())
            {
                blockedChars.Add(blockedChar);
            }
            var lastGuess = guesses.Last();
            matchingWords = matchingWords
                .Where(o => lastGuess.IsMatch(o))
                .Where(o => !used.Contains(o))
                .Where(o => !ContainsBlockedChar(o, blockedChars))
                .ToList();

            if (matchingWords.Count == 1)
            {
                var foundWord = matchingWords.First();
                foundWords.Add(foundWord);
                blockedChars.Clear();
                used.Clear();
                matchingWords = words.ToList();
                Console.WriteLine(foundWord);
            }
            
        }

        return foundWords;
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