using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Crab Cups")]
public class Aoc202023 : AocPuzzle
{
    [Puzzle("060b60050b1b5e81909b30f5b00b81dc")]
    public string Part1(string input, int moves = 100)
    {
        var cups = Play(input, moves);
        var currentCup = cups[1];

        var resultNumbers = new List<int>();
        currentCup = currentCup.NextOrFirst();
        while (currentCup.Value != 1)
        {
            resultNumbers.Add(currentCup.Value);
            currentCup = currentCup.NextOrFirst();
        }

        return string.Concat(resultNumbers.Select(o => o.ToString()));
    }

    [Puzzle("86b2d5ff30f1a76d6a5de3dfc06e89e9")]
    public long Part2(string input)
    {
        var cups = Play(input, 10_000_000, true);
        var currentCup = cups[1];

        currentCup = currentCup.NextOrFirst();
        long val1 = currentCup.Value;
        currentCup = currentCup.NextOrFirst();
        long val2 = currentCup.Value;

        return val1 * val2;
    }

    private const int ExtendedMaxNumber = 1_000_000;

    private static Dictionary<int, LinkedListNode<int>> Play(string input, int moves, bool isExtended = false)
    {
        var numbers = input.ToCharArray().Select(o => int.Parse(o.ToString())).ToList();
        var minNumber = numbers.Min();
        var maxNumber = numbers.Max();
        var circle = new LinkedList<int>();
        LinkedListNode<int> currentCup;
        var cups = new Dictionary<int, LinkedListNode<int>>();

        do
        {
            var num = numbers.First();
            currentCup = circle.AddLast(num);
            cups.Add(num, currentCup);
            numbers.RemoveAt(0);
        } while (numbers.Count != 0);

        if (isExtended)
        {
            for (var num = maxNumber + 1; num <= ExtendedMaxNumber; num++)
            {
                currentCup = circle.AddLast(num);
                cups.Add(num, currentCup);
            }

            maxNumber = ExtendedMaxNumber;
        }

        currentCup = circle.First!;

        var cupsToMove = new LinkedListNode<int>[3];
        for (var i = 0; i < moves; i++)
        {
            var currentCupBeforeMove = currentCup;
            var currentCupLabel = currentCup.Value;
            var nodeToMove = currentCup.NextOrFirst();
            for (var j = 0; j < 3; j++)
            {
                cupsToMove[j] = nodeToMove;
                var nodeToRemove = nodeToMove;
                nodeToMove = nodeToMove.NextOrFirst();
                circle.Remove(nodeToRemove);
            }

            var destinationCup = currentCupLabel - 1;
            while (destinationCup < minNumber || cupsToMove.Any(o => o.Value == destinationCup))
            {
                destinationCup--;
                if (destinationCup < minNumber)
                    destinationCup = maxNumber;
            }

            currentCup = cups[destinationCup];

            foreach (var cup in cupsToMove)
            {
                circle.AddAfter(currentCup, cup);
                currentCup = currentCup.NextOrFirst();
            }

            currentCup = currentCupBeforeMove;
            currentCup = currentCup.NextOrFirst();
        }

        return cups;
    }
}