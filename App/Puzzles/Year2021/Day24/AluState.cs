using System.Collections.Generic;
using System.Linq;

namespace App.Puzzles.Year2021.Day24;

public class AluState
{
    public Dictionary<char, long> Memory { get; }
    public List<int> Inputs { get; private set; }

    public AluState(List<int> inputs)
    {
        Inputs = inputs;
        Memory = new Dictionary<char, long>
        {
            { 'w', 0 },
            { 'x', 0 },
            { 'y', 0 },
            { 'z', 0 }
        };
    }

    public int ReadInput()
    {
        var nextInput = Inputs.First();
        Inputs = Inputs.Skip(1).ToList();
        return nextInput;
    }
}