using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using App.Common.Strings;
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
    public void Exploding()
    {
        var math = new SnailfishMath();
        var number = new SnailfishNumber("[[[[[9,8],1],2],3],4]");
        var result = math.Explode(number);

        Assert.That(result.ToString(), Is.EqualTo("[[[[0,9],2],3],4]"));
    }
}

public class SnailfishMath
{
    public SnailfishNumber Explode(SnailfishNumber number)
    {
        var nodeToExplode = FindNodeToExplode(number);
        if (nodeToExplode != null)
        {
            var literalList = BuildListOfLiterals(number);
            var currentNode = literalList.First;
            while (currentNode != null)
            {
                if (currentNode.Value.Id == nodeToExplode.Id)
                    break;

                currentNode = currentNode.Next;
            }

            var x = 0;
        }

        return nodeToExplode;
    }

    private LinkedList<SnailfishNumber> BuildListOfLiterals(SnailfishNumber snailfishNumber, LinkedList<SnailfishNumber> list = null)
    {
        list = list ?? new LinkedList<SnailfishNumber>();

        if (!snailfishNumber.IsComposite)
        {
            list.AddLast(snailfishNumber);
        }
        
        foreach (var child in snailfishNumber.Children)
        {
            BuildListOfLiterals(child, list);
        }

        return list;
    }
    
    private SnailfishNumber FindNodeToExplode(SnailfishNumber number)
    {
        var currentNode = number;
        var stack = new Stack<string>();
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
    
    private List<SnailfishNumber> ParseNumbers(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input);
        var numbers = lines.Select(o => new SnailfishNumber(o)).ToList();
        return numbers;
    }
}

public class SnailfishNumber
{
    private int _value = 0;
    public Guid Id { get; }

    public int ParsedLength { get; }
    public int LiteralValue { get; private set; }
    public bool IsComposite { get; private set; }
    public SnailfishNumber Parent { get; }
    public SnailfishNumber Left => Children.FirstOrDefault();
    public SnailfishNumber Right => Children.LastOrDefault();
    public List<SnailfishNumber> Children { get; } = new();

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

    public void Explode()
    {
        Children.Clear();
        IsComposite = false;
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

    public override string ToString()
    {
        return IsComposite
            ? $"[{Left},{Right}]"
            : LiteralValue.ToString();
    }
}
