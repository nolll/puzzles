namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202118;

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
            if (_parent == null)
                return 0;

            return _parent.Level + 1;
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