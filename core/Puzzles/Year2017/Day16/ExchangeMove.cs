using System.Collections.Generic;

namespace Core.Puzzles.Year2017.Day16;

public class ExchangeMove : DanceMove
{
    private readonly int _index1;
    private readonly int _index2;

    public ExchangeMove(string command)
    {
        var parts = command.Substring(1).Split('/');
        _index1 = int.Parse(parts[0]);
        _index2 = int.Parse(parts[1]);
    }

    public override void Execute(IDictionary<char, int> programs)
    {
        char? key1 = null;
        char? key2 = null;
        foreach (var key in programs.Keys)
        {
            if (programs[key] == _index1)
                key1 = key;

            if (programs[key] == _index2)
                key2 = key;
        }

        programs[key1.Value] = _index2;
        programs[key2.Value] = _index1;
    }
}