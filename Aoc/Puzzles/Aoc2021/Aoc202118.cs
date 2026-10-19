using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Snailfish")]
public class Aoc202118 : AocPuzzle
{
    [Puzzle("1d3da7fb83304ae6368c25c4835fb0af")]
    public int Part1(string input) => Sum(ParseNumbers(input)).Magnitude;

    [Puzzle("a9626bd58c604514d0e274952464ba7d")]
    public int Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var largestMagnitude = 0;
        foreach (var line1 in lines)
        {
            foreach (var line2 in lines)
            {
                if (line1 == line2)
                    continue;

                var num1 = new SnailfishNumber(line1);
                var num2 = new SnailfishNumber(line2);
                var sum = Sum(num1, num2);
                var magnitude = sum.Magnitude;
                if (magnitude > largestMagnitude)
                    largestMagnitude = magnitude;
            }
        }

        return largestMagnitude;
    }

    public SnailfishNumber Sum(IReadOnlyCollection<SnailfishNumber> numbers)
    {
        var number = numbers.First();
        return numbers.Skip(1).Aggregate(number, Sum);
    }

    public SnailfishNumber Explode(SnailfishNumber number)
    {
        var nodeToExplode = FindNodeToExplode(number);
        if (nodeToExplode == null)
            return number;
        
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

        prevNode?.LiteralValue += leftNode.LiteralValue;
        nextNode?.LiteralValue += rightNode.LiteralValue;
        nodeToExplode.Explode();

        return number;
    }

    private SnailfishNumber Split(SnailfishNumber number)
    {
        var nodeToSplit = FindNodeToSplit(number);
        nodeToSplit?.Split();

        return number;
    }

    private static LinkedList<SnailfishNumber> BuildListOfLiteralNodes(SnailfishNumber snailfishNumber, LinkedList<SnailfishNumber>? list = null)
    {
        list ??= new LinkedList<SnailfishNumber>();

        if (!snailfishNumber.IsComposite) 
            list.AddLast(snailfishNumber);

        foreach (var child in snailfishNumber.Children) 
            BuildListOfLiteralNodes(child, list);

        return list;
    }

    private static SnailfishNumber? FindNodeToExplode(SnailfishNumber number)
    {
        while (true)
        {
            if (!number.IsComposite)
                return null;
            
            if (number.Level > 3)
                return number;

            return number.Children.Select(FindNodeToExplode).OfType<SnailfishNumber>().FirstOrDefault();
        }
    }

    private static SnailfishNumber? FindNodeToSplit(SnailfishNumber number)
    {
        while (true)
        {
            if (number.IsComposite)
            {
                return number.Children.Select(FindNodeToSplit).OfType<SnailfishNumber>().FirstOrDefault();
            }

            if (number.LiteralValue > 9)
                return number;

            return null;
        }
    }

    public List<SnailfishNumber> ParseNumbers(string input) =>
        input.Split(LineBreaks.Single).Select(o => new SnailfishNumber(o)).ToList();

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

    public class SnailfishNumber
    {
        public Guid Id { get; }

        private readonly int _parsedLength;
        private SnailfishNumber? _parent;

        public int LiteralValue { get; set; }
        public bool IsComposite { get; private set; }
        public SnailfishNumber Left => Children.First();
        public SnailfishNumber Right => Children.Last();
        public List<SnailfishNumber> Children { get; private set; } = new();

        public SnailfishNumber(string input, SnailfishNumber? parent = null)
        {
            Id = Guid.NewGuid();
            _parent = parent;
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

            currentInput = currentInput[Left._parsedLength..];
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

            _parsedLength = Left._parsedLength + Right._parsedLength + 3;
        }

        public SnailfishNumber(int value, SnailfishNumber parent)
        {
            Id = Guid.NewGuid();
            IsComposite = false;
            _parsedLength = 1;
            LiteralValue = value;
            _parent = parent;
        }

        public SnailfishNumber(SnailfishNumber number1, SnailfishNumber number2)
        {
            Id = Guid.NewGuid();
            IsComposite = true;
            number1._parent = this;
            number2._parent = this;
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
            Children = [new(left, this), new(right, this)];
            LiteralValue = 0;
        }

        public int Level => _parent == null ? 0 : _parent.Level + 1;

        public int Magnitude => IsComposite ? Left.Magnitude * 3 + Right.Magnitude * 2 : LiteralValue;

        public override string ToString() => IsComposite
            ? $"[{Left},{Right}]"
            : LiteralValue.ToString();
    }
}