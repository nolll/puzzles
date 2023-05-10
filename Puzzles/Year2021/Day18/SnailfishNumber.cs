using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Year2021.Day18;

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
            var child = new SnailfishNumber(currentInput, this);
            Children.Add(child);
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
            var child = new SnailfishNumber(currentInput, this);
            Children.Add(child);
        }
        else
        {
            var child = new SnailfishNumber(int.Parse(currentInput[..1]), this);
            Children.Add(child);
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