using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;
using App.Common.Strings;
using NuGet.Frameworks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace App.Puzzles.Year2021.Day18;

public class Year2021Day18Tests
{
    [Test]
    public void Parsing1()
    {
        var number = new SnailfishNumber("[1,2]");

        Assert.That(number.Left.LiteralValue, Is.EqualTo(1));
        Assert.That(number.Right.LiteralValue, Is.EqualTo(2));
    }

    [Test]
    public void Parsing2()
    {
        var number = new SnailfishNumber("[[1,2],3]");

        Assert.That(number.Left.Left.LiteralValue, Is.EqualTo(1));
        Assert.That(number.Left.Right.LiteralValue, Is.EqualTo(2));
        Assert.That(number.Right.LiteralValue, Is.EqualTo(3));
    }

    [Test]
    public void Parsing3()
    {
        var number = new SnailfishNumber("[9,[8,7]]");

        Assert.That(number.Left.LiteralValue, Is.EqualTo(9));
        Assert.That(number.Right.Left.LiteralValue, Is.EqualTo(8));
        Assert.That(number.Right.Right.LiteralValue, Is.EqualTo(7));
    }

    [Test]
    public void Parsing4()
    {
        var number = new SnailfishNumber("[[1,9],[8,5]]");

        Assert.That(number.Left.Left.LiteralValue, Is.EqualTo(1));
        Assert.That(number.Left.Right.LiteralValue, Is.EqualTo(9));
        Assert.That(number.Right.Left.LiteralValue, Is.EqualTo(8));
        Assert.That(number.Right.Right.LiteralValue, Is.EqualTo(5));
    }

    [Test]
    public void Parsing5()
    {
        var number = new SnailfishNumber("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]");

        Assert.That(number.ToString(), Is.EqualTo("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]"));
        Assert.That(number.Left.Left.Left.Left.LiteralValue, Is.EqualTo(1));
        Assert.That(number.Left.Left.Left.Right.LiteralValue, Is.EqualTo(2));
        Assert.That(number.Left.Left.Right.Left.LiteralValue, Is.EqualTo(3));
        Assert.That(number.Left.Left.Right.Right.LiteralValue, Is.EqualTo(4));
        Assert.That(number.Left.Right.Left.Left.LiteralValue, Is.EqualTo(5));
        Assert.That(number.Left.Right.Left.Right.LiteralValue, Is.EqualTo(6));
        Assert.That(number.Left.Right.Right.Left.LiteralValue, Is.EqualTo(7));
        Assert.That(number.Left.Right.Right.Right.LiteralValue, Is.EqualTo(8));
        Assert.That(number.Right.LiteralValue, Is.EqualTo(9));
    }

    [Test]
    public void Parsing6()
    {
        var number = new SnailfishNumber("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]");

        Assert.That(number.ToString(), Is.EqualTo("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]"));
    }

    [Test]
    public void Parsing7()
    {
        var number = new SnailfishNumber("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]");

        Assert.That(number.ToString(), Is.EqualTo("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]"));
    }

    [Test]
    public void Parsing8()
    {
        var number = new SnailfishNumber("[[[[0,7],4],[15,[0,13]]],[1,1]]");

        Assert.That(number.ToString(), Is.EqualTo("[[[[0,7],4],[15,[0,13]]],[1,1]]"));
    }

    [Test]
    public void Exploding1()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[[[[9,8],1],2],3],4]");
        var result = math.Explode(number);

        Assert.That(result.ToString(), Is.EqualTo("[[[[0,9],2],3],4]"));
    }

    [Test]
    public void Exploding2()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[7,[6,[5,[4,[3,2]]]]]");
        var result = math.Explode(number);

        Assert.That(result.ToString(), Is.EqualTo("[7,[6,[5,[7,0]]]]"));
    }

    [Test]
    public void Exploding3()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]");
        var result = math.Explode(number);

        Assert.That(result.ToString(), Is.EqualTo("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]"));
    }

    [Test]
    public void Adding1()
    {
        var math = new SnailfishMath();
        var number1 = new SnailfishNumber("[[[[4,3],4],4],[7,[[8,4],9]]]");
        var number2 = new SnailfishNumber("[1,1]");
        var result = math.Sum(number1, number2);

        Assert.That(result.ToString(), Is.EqualTo("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]"));
    }

    [Test]
    public void Sum1()
    {
        const string input = @"
[1,1]
[2,2]
[3,3]
[4,4]
[5,5]
[6,6]";

        var math = new SnailfishMath();
        var result = math.Sum(input);

        Assert.That(result.ToString(), Is.EqualTo("[[[[5,0],[7,4]],[5,5]],[6,6]]"));
    }

    [Test]
    public void Sum2()
    {
        const string input = @"
[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]";

        var math = new SnailfishMath();
        var result = math.Sum(input);

        Assert.That(result.ToString(), Is.EqualTo("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]"));
    }

    [Test]
    public void Magnitude1()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[1,2],[[3,4],5]]");

        Assert.That(number.Magnitude, Is.EqualTo(143));
    }

    [Test]
    public void Magnitude2()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]");

        Assert.That(number.Magnitude, Is.EqualTo(3488));
    }

    [Test]
    public void Part1()
    {
        const string input = @"
[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

        var math = new SnailfishMath();
        var result = math.Sum(input);

        Assert.That(result.ToString(), Is.EqualTo("[[[[6,6],[7,6]],[[7,7],[7,0]]],[[[7,7],[7,7]],[[7,8],[9,9]]]]"));
        Assert.That(result.Magnitude, Is.EqualTo(4140));
    }

    [Test]
    public void Part2()
    {
        const string input = @"
[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

        var math = new SnailfishMath();
        var result = math.LargestMagnitude(input);

        Assert.That(result, Is.EqualTo(3993));
    }
}

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

public class SnailfishNumber
{
    public Guid Id { get; }

    public int ParsedLength { get; }
    public int LiteralValue { get; set; }
    public bool IsComposite { get; private set; }
    public SnailfishNumber Parent { get; set; }
    public SnailfishNumber Left => Children.FirstOrDefault();
    public SnailfishNumber Right => Children.LastOrDefault();
    public List<SnailfishNumber> Children { get; private set; } = new();

    public SnailfishNumber(string input, SnailfishNumber parent = null)
    {
        Id = Guid.NewGuid();
        Parent = parent;
        IsComposite = true;
        var currentInput = input[1..];
        if (currentInput.First() == '[')
        {
            Children.Add(new SnailfishNumber(currentInput, this));
        }
        else
        {
            var child = new SnailfishNumber(int.Parse(currentInput[..1]), this);
            Children.Add(child);
        }
        currentInput = currentInput[Left.ParsedLength..];
        currentInput = currentInput[1..];
        if (currentInput.First() == '[')
        {
            Children.Add(new SnailfishNumber(currentInput, this));
        }
        else
        {
            Children.Add(new SnailfishNumber(int.Parse(currentInput[..1]), this));
        }

        ParsedLength = Left.ParsedLength + Right.ParsedLength + 3;
    }

    public SnailfishNumber(int value, SnailfishNumber parent)
    {
        Id = Guid.NewGuid();
        IsComposite = false;
        ParsedLength = 1;
        LiteralValue = value;
        Parent = parent;
    }

    public SnailfishNumber(SnailfishNumber number1, SnailfishNumber number2)
    {
        Id = Guid.NewGuid();
        IsComposite = true;
        number1.Parent = this;
        number2.Parent = this;
        Children.Add(number1);
        Children.Add(number2);
    }

    public void Explode()
    {
        Children.Clear();
        IsComposite = false;
        LiteralValue = 0;
    }

    public void Split()
    {
        IsComposite = true;
        var left = LiteralValue / 2;
        var right = LiteralValue % 2 == 0 ? left : left + 1;
        Children = new List<SnailfishNumber>
        {
            new(left, this),
            new(right, this)
        };
        LiteralValue = 0;
    }

    public int Level
    {
        get
        {
            if (Parent == null)
                return 0;

            return Parent.Level + 1;
        }
    }

    public int Magnitude
    {
        get
        {
            if (IsComposite)
                return Left.Magnitude * 3 + Right.Magnitude * 2;

            return LiteralValue;
        }
    }

    public override string ToString()
    {
        return IsComposite
            ? $"[{Left},{Right}]"
            : LiteralValue.ToString();
    }
}
