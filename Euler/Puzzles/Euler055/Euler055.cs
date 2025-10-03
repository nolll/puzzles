using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles.Euler055;

[Name("Lychrel Numbers")]
public class Euler055 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var n = new BigInteger(1);
        var lychrelCount = 0;

        while (n < 10_000)
        {
            var current = n;
            var found = false;
            for (var i = 0; i < 50; i++)
            {
                var s = current.ToString();
                var b = s.ReverseString();
                current = BigInteger.Parse(s) + BigInteger.Parse(b);
                var rs = current.ToString();
                var isPalindrome = rs == rs.ReverseString();

                if (!isPalindrome)
                    continue;
                
                found = true;
                break;
            }
            
            if (!found)
                lychrelCount++;

            n++;
        }
        
        return new PuzzleResult(lychrelCount, "2cfc10140c99d8efac8a77765769479d");
    }
}