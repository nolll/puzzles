using System.Diagnostics;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202124;

[DebuggerDisplay("{W},{X},{Y},{Z}")]
public class AluState
{
    public Dictionary<char, long> Memory { get; }
    public List<int> Inputs { get; private set; }

    private long W => Memory['w'];
    private long X => Memory['x'];
    private long Y => Memory['y'];
    private long Z => Memory['z'];

    public AluState(List<int> inputs, Dictionary<char, long>? memory = null)
    {
        Inputs = inputs;
        Memory = memory ?? new Dictionary<char, long>
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

    public override string ToString()
    {
        return $"{W},{X},{Y},{Z}";
    }
}