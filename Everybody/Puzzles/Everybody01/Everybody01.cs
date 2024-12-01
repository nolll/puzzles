using Pzl.Common;

namespace Pzl.Everybody.Puzzles.Everybody01;

[Name("The Battle for the Farmlands")]
public class Everybody01 : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var count = PotionsNeeded(input, 1);
        
        return new PuzzleResult(count, "93584fbfb539341540431fdcbdd43e43");
    }
    
    protected override PuzzleResult RunPart2(string input)
    {
        var count = PotionsNeeded(input, 2);
        
        return new PuzzleResult(count, "29c8c2e9da7059c271b37645091e3caa");
    }
    
    protected override PuzzleResult RunPart3(string input)
    {
        var count = PotionsNeeded(input, 3);
        
        return new PuzzleResult(count, "114dce9075f6d580a84376f6f7eceeeb");
    }

    public static int PotionsNeeded(string input, int groupSize) => 
        SplitToSize(input, groupSize)
            .Sum(s => s.Sum(GetPotionCount) + CalculateBonus(GetCreatureCount(s)));

    private static IEnumerable<string> SplitToSize(string s, int size)
    {
        for (var i = 0; i < s.Length; i += size)
        {
            yield return s.Substring(i, size);
        }
    }   

    private static int CalculateBonus(int creatureCount) => creatureCount switch
    {
        2 => 2,
        3 => 6,
        _ => 0
    };

    private static int GetCreatureCount(string s) => s.Count(o => o != 'x');

    private static int GetPotionCount(char c) => c switch
    {
        'B' => 1,
        'C' => 3,
        'D' => 5,
        _ => 0
    };
}