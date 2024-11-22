using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq39;

[Name("Game of Throwns")]
public class Aquaq39(string input) : AquaqPuzzle
{
    private const int GameTarget = 501;
    private const int DartsPerTurn = 3;

    protected override PuzzleResult Run()
    {
        var result = PlayGame(input);

        return new PuzzleResult(result, "5522d4ea2615abc82626c1563f788ce8");
    }

    public static int PlayGame(string input)
    {
        var darts = input.Split(' ').Select(int.Parse).ToArray();

        var scores = new int[2];
        var winCount = new int[2];
        var winningDartSum = 0;

        var pStart = 0;
        var pUp = pStart;

        var dartIndex = 0;
        var dartsLeft = DartsPerTurn;

        while (dartIndex < darts.Length)
        {
            var dart = darts[dartIndex];
            scores[pUp] += dart;
            dartsLeft--;

            if (scores[pUp] == GameTarget)
            {
                dartsLeft = DartsPerTurn;
                winCount[pUp]++;
                winningDartSum += dart;
                pStart = pStart == 0 ? 1 : 0;
                pUp = pStart;
                scores[0] = 0;
                scores[1] = 0;
            } 
            else if (dartsLeft == 0)
            {
                pUp = pUp == 0 ? 1 : 0;
                dartsLeft = DartsPerTurn;
            }

            dartIndex++;
        }

        return winningDartSum * winCount[0];
    }
}