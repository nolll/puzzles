using Common.Cryptography;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq35;

public class Aquaq35 : AquaqPuzzle
{
    public override string Name => "Columns";

    protected override PuzzleResult Run()
    {
        var words = CommonTextFile("Words.txt").Split(Environment.NewLine);
        var input = InputFile;

        var keyword = FindKeyword(words, input);

        return new PuzzleResult(keyword, null, "47f8ac801da35487059c7f5acb1c77ac");
    }

    private static string FindKeyword(IEnumerable<string> words, string input)
    {
        // Optimization after the answer was found. Takes 225s without it
        const int startSearchFrom = 19000;
        var inputLength = input.Length;
        
        var shortWordList = words.Where(o => inputLength % o.Length == 0).Skip(startSearchFrom);
        
        foreach (var word in shortWordList)
        {
            var decrypted = ColumnarTranspositionCipher.Decrypt(word, input);

            // A sentence from a book probably doesn't contain double spaces
            if (!decrypted.Trim().Contains("  "))
                return word;
        }

        return "";
    }
}