using Puzzles.Common.Puzzles;
using Puzzles.Common.Strings;

namespace Puzzles.Aquaq.Puzzles.Aquaq37;

public class Aquaq37 : AquaqPuzzle
{
    public override string Name => "GUESS WORDS";

    private const int WordLength = 5;

    protected override PuzzleResult Run()
    {
        var words = FindWords(InputFile);
        var score = words.Sum(GetWordScore);

        return new PuzzleResult(score, "ba0ef798d7f57b80a0675236159ccfb1");
    }

    public List<string> FindWords(string input)
    {
        var words = InputReader.ReadLines(CommonTextFile("Words.txt"))
            .Where(o => o.Length == WordLength)
            .ToList();

        var guesses = InputReader.ReadLines(input)
            .Skip(1)
            .Select(ParseGuess)
            .ToList();

        var foundWords = new List<string>();
        var used = new HashSet<string>();
        var remainingGuesses = guesses.ToList();
        var matchingWords = words.ToList();
        while (remainingGuesses.Any())
        {
            var guess = remainingGuesses.First();
            remainingGuesses = remainingGuesses.Skip(1).ToList();
            used.Add(guess.Word);

            matchingWords = matchingWords
                .Where(o => !used.Contains(o))
                .Where(o => guess.IsMatch(o))
                .ToList();

            if (matchingWords.Count > 1)
                continue;

            var foundWord = matchingWords.First();
            foundWords.Add(foundWord);
            used.Clear();
            matchingWords = words.ToList();
        }

        return foundWords;
    }

    private static Guess ParseGuess(string s)
    {
        var parts = s.Split(',');
        var word = parts[0];
        var results = parts[1].Split(' ').Select(int.Parse).ToArray();

        return new Guess(word, results);
    }

    public static int GetWordScore(string word) => word.Select(o => o - 'a').Sum();

    public class Guess
    {
        public string Word { get; }
        private readonly int[] _result;

        public Guess(string word, int[] result)
        {
            Word = word;
            _result = result;
        }

        public bool IsMatch(string other)
        {
            for (var i = 0; i < WordLength; i++)
            {
                var result = _result[i];
                var wordChar = Word[i];
                var otherChar = other[i];
                switch (result)
                {
                    case 2 when wordChar != otherChar:
                    case 0 or 1 when wordChar == otherChar:
                        return false;
                }
            }

            var possibleChars = new List<char>();
            var blockedChars = new List<char>();
            var remainingChars = new List<char>();
            for (var i = 0; i < WordLength; i++)
            {
                var result = _result[i];
                var wordChar = Word[i];
                var otherChar = other[i];
                if (result is 0 or 1)
                    remainingChars.Add(otherChar);

                if (result == 1)
                    possibleChars.Add(wordChar);

                if (result == 0)
                    blockedChars.Add(wordChar);
            }

            return possibleChars.All(remainingChars.Remove) && !blockedChars.Any(remainingChars.Contains);
        }
    }
}