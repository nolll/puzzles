using Pzl.Tools.Puzzles;

namespace Pzl.Aquaq.Puzzles.Aquaq06;

public class Aquaq06 : AquaqPuzzle
{
    public override string Name => "Let me count the ways";

    protected override PuzzleResult Run()
    {
        const int n = 123;
        var result = FindOneCount(n);

        return new PuzzleResult(result, "a693902fb2b369af1febd8b1d529364f");
    }

    public static int FindOneCount(int n)
    {
        var oneCount = 0;
        for (var i = 0; i <= n; i++)
        {
            for (var j = 0; j <= n - i; j++)
            {
                for (var k = 0; k <= n - i - j; k++)
                {
                    if (i + j + k == n)
                    {
                        oneCount += $"{i}{j}{k}".Count(o => o == '1');
                    }
                }
            }
        }

        return oneCount;
    }
}