using Pzl.Common;
using Pzl.Tools.Debug;

namespace Pzl.Everybody.Puzzles.Ecs02.Ecs0202;

[Name("The Pocket-Money Popper")]
public class Ecs0202 : EverybodyStoryPuzzle
{
    private static readonly char[] Arrows = ['R', 'G', 'B'];

    public PuzzleResult Part1(string input)
    {
        var i = 0;
        var arrowIndex = 0;
        while (i < input.Length)
        {
            while (i < input.Length && input[i] == Arrows[arrowIndex % Arrows.Length])
                i++;

            arrowIndex++;
            i++;
        }
        
        return new PuzzleResult(arrowIndex, "4648ca473c884f7676991b343c2db8e0");
    }

    public PuzzleResult Part2(string input)
    {
        var result = Part2And3(input, 100);
        return new PuzzleResult(result, "00ed6d0c92fbd2e3d164be5870f33a3f");
    }

    public PuzzleResult Part3(string input)
    {
        var result = Part2And3(input, 100_000);
        return new PuzzleResult(result, "c2eff10d6d075e935bd2a23732fe7ef2");
    }

    public static int Part2And3(string input, int repeats)
    {
        var (list1, list2) = BuildLists(input, repeats);
        var balloonCount = list1.Count + list2.Count;
        
        var shotCount = 0;
        
        while (balloonCount > 0)
        {
            var arrow = Arrows[shotCount % Arrows.Length];
            shotCount++;
            var isColorMatch = list1.First!.Value == arrow;
            var isEvenCount = balloonCount % 2 == 0;
            
            list1.RemoveFirst();
            balloonCount--;

            if (!isEvenCount)
                continue;
            
            if (isColorMatch)
            {
                list2.RemoveFirst();
                balloonCount--;
            }
            else
            {
                list1.AddLast(list2.First!.Value);
                list2.RemoveFirst();
            }
        }
        
        return shotCount;
    }

    private static (LinkedList<char> list1, LinkedList<char> list2) BuildLists(string input, int repeats)
    {
        var balloonCount = input.Length * repeats;
        var listSize = balloonCount / 2;
        var list1 = BuildList(input, 0, listSize);
        var list2 = BuildList(input, listSize, listSize);
        
        return (list1, list2);
    }

    private static LinkedList<char> BuildList(string input, int startIndex, int count)
    {
        var counter = 0;
        var index = startIndex;
        var list = new LinkedList<char>();
        while (counter < count)
        {
            list.AddLast(input[index % input.Length]);
            index++;
            counter++;
        }

        return list;
    }
}