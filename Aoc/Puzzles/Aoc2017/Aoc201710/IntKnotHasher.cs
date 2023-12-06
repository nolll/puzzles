namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201710;

public class IntKnotHasher
{
    private readonly int[] _list;
    private int _listIndex;
    private int _skip;
    private int _lengthIndex;
    private readonly int[] _lengths;

    public int Checksum { get; }

    public IntKnotHasher(string input, int size = 256)
    {
        _lengths = input.Split(',').Select(int.Parse).ToArray();
        _list = FillList(size);
        _listIndex = 0;
        _skip = 0;

        for (var i = 0; i < _lengths.Length; i++)
        {
            _lengthIndex = i;
            var values = ReadValues();
            var reversed = values.Reverse().ToArray();
            WriteValues(reversed);
            MoveForward();
        }

        Checksum = _list[0] * _list[1];
    }

    private int[] FillList(int size)
    {
        var list = new int[size];
        for (var i = 0; i < size; i++)
        {
            list[i] = i;
        }

        return list;
    }

    private void MoveForward()
    {
        var steps = _lengths[_lengthIndex] + _skip;
        for (var i = 0; i < steps; i++)
        {
            _listIndex++;
            if (_listIndex >= _list.Length)
                _listIndex = 0;
        }
        _skip++;
    }

    private void WriteValues(int[] values)
    {
        var current = _listIndex;
        foreach (var v in values)
        {
            _list[current] = v;
            current++;
            if (current >= _list.Length)
                current = 0;
        }
    }

    private IList<int> ReadValues()
    {
        var length = _lengths[_lengthIndex];
        var values = new int[length];
        var current = _listIndex;
        for (var i = 0; i < length; i++)
        {
            values[i] = _list[current];
            current++;
            if (current >= _list.Length)
                current = 0;
        }

        return values;
    }
}