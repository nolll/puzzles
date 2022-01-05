using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2021.Day18;

public class SnailfishMath
{
    public SnailfishNumber Sum(string input)
    {
        var numbers = ParseNumbers(input);
        return Sum(numbers);
    }

    public int LargestMagnitude(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input);
        var largestMagnitude = 0;
        foreach (var line1 in lines)
        {
            foreach (var line2 in lines)
            {
                if (line1 != line2)
                {
                    var num1 = new SnailfishNumber(line1);
                    var num2 = new SnailfishNumber(line2);
                    var sum = Sum(num1, num2);
                    var magnitude = sum.Magnitude;
                    if (magnitude > largestMagnitude)
                        largestMagnitude = magnitude;
                }
            }
        }

        return largestMagnitude;
    }

    public SnailfishNumber Sum(List<SnailfishNumber> numbers)
    {
        var number = numbers.First();
        var numbersToAdd = numbers.Skip(1);
        foreach (var n in numbersToAdd)
        {
            number = Sum(number, n);
        }

        return number;
    }

    public SnailfishNumber Explode(SnailfishNumber number)
    {
        var nodeToExplode = FindNodeToExplode(number);
        if (nodeToExplode != null)
        {
            var literalNodeList = BuildListOfLiteralNodes(number);
            var leftNode = nodeToExplode.Left;
            var rightNode = nodeToExplode.Right;
            var leftNodeInList = literalNodeList.First;
            while (leftNodeInList != null)
            {
                if (leftNodeInList.Value.Id == leftNode.Id)
                    break;

                leftNodeInList = leftNodeInList.Next;
            }

            var rightNodeInList = literalNodeList.First;
            while (rightNodeInList != null)
            {
                if (rightNodeInList.Value.Id == rightNode.Id)
                    break;

                rightNodeInList = rightNodeInList.Next;
            }

            var prevNode = leftNodeInList?.Previous?.Value;
            var nextNode = rightNodeInList?.Next?.Value;

            if (prevNode != null)
            {
                prevNode.LiteralValue += leftNode.LiteralValue;
            }

            if (nextNode != null)
            {
                nextNode.LiteralValue += rightNode.LiteralValue;
            }

            nodeToExplode.Explode();
        }

        return number;
    }

    public SnailfishNumber Split(SnailfishNumber number)
    {
        var nodeToSplit = FindNodeToSplit(number);
        if (nodeToSplit != null)
            nodeToSplit.Split();

        return number;
    }

    private LinkedList<SnailfishNumber> BuildListOfLiteralNodes(SnailfishNumber snailfishNumber, LinkedList<SnailfishNumber> list = null)
    {
        list = list ?? new LinkedList<SnailfishNumber>();

        if (!snailfishNumber.IsComposite)
        {
            list.AddLast(snailfishNumber);
        }

        foreach (var child in snailfishNumber.Children)
        {
            BuildListOfLiteralNodes(child, list);
        }

        return list;
    }
    
    private SnailfishNumber FindNodeToExplode(SnailfishNumber number)
    {
        var currentNode = number;
        while (true)
        {
            if (currentNode.IsComposite)
            {
                if (currentNode.Level > 3)
                    return currentNode;

                foreach (var child in currentNode.Children)
                {
                    var found = FindNodeToExplode(child);
                    if (found != null)
                        return found;
                }
            }

            return null;
        }
    }

    private SnailfishNumber FindNodeToSplit(SnailfishNumber number)
    {
        var currentNode = number;
        while (true)
        {
            if (currentNode.IsComposite)
            {
                foreach (var child in currentNode.Children)
                {
                    var found = FindNodeToSplit(child);
                    if (found != null)
                        return found;
                }
            }
            else
            {
                if (currentNode.LiteralValue > 9)
                    return currentNode;
            }

            return null;
        }
    }

    private List<SnailfishNumber> ParseNumbers(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input);
        var numbers = lines.Select(o => new SnailfishNumber(o)).ToList();
        return numbers;
    }

    public SnailfishNumber Sum(SnailfishNumber number1, SnailfishNumber number2)
    {
        var newNumber = new SnailfishNumber(number1, number2);
        newNumber = Reduce(newNumber);
        return newNumber;
    }

    private SnailfishNumber Reduce(SnailfishNumber number)
    {
        var sCurrent = number.ToString();
        while (true)
        {
            number = Explode(number);
            var sExploded = number.ToString();

            if (sExploded != sCurrent)
            {
                sCurrent = sExploded;
                continue;
            }

            number = Split(number);
            var sSplitted = number.ToString();

            if (sSplitted == sCurrent)
                break;
        }

        return number;
    }
}