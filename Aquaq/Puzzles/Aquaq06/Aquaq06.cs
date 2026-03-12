using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq06;

[Name("Let me count the ways")]
public class Aquaq06 : AquaqPuzzle
{
    [Puzzle("a693902fb2b369af1febd8b1d529364f")]
    public int Solve() => FindOneCount(123);

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