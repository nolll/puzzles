using System.Diagnostics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Arithmetic Logic Unit")]
public class Aoc202124 : AocPuzzle
{
    private List<string> ValidNumbers
    {
        get
        {
            if (field == null)
            {
                field = [];
                var monad = new Monad();
                monad.Search(0, 0, new int[14], field);
                field = field.OrderBy(o => o).ToList();
            }

            return field;
        }
    }

    private long SmallestValidNumber => long.Parse(ValidNumbers.First());
    private long LargestValidNumber => long.Parse(ValidNumbers.Last());

    [Puzzle("e513806c32f88d6227c6a529844981ef")]
    public long Part1(string input) => LargestValidNumber;

    [Puzzle("aa756b55fecfa23d098754af71fcc02a")]
    public long Part2(string input) => SmallestValidNumber;
    
    public class Monad
    {
        private readonly int[] _p3;
        private readonly int[] _p1;
        private readonly int[] _p2;
        private readonly long[] _zMax;

        public Monad()
        {
            _p1 = [12, 11, 14, -6, 15, 12, -9, 14, 14, -5, -9, -5, -2, -7];
            _p2 = [4, 10, 12, 14, 6, 16, 1, 7, 8, 11, 8, 3, 1, 8];
            _p3 = [1, 1, 1, 26, 1, 1, 26, 1, 1, 26, 26, 26, 26, 26];
            _zMax = GetZLimits();
        }

        // z can't be larger than the product of p3[depth..] at each level
        private long[] GetZLimits()
        {
            var zList = new List<long>();
            long currentZMax = 1;
            foreach (var p in _p3.Reverse())
            {
                currentZMax *= p;
                zList.Add(currentZMax);
            }

            zList.Reverse();
            return zList.ToArray();
        }

        // this is the compiled validation process
        private long Process(int n, int w, long z)
        {
            var z1 = (long)Math.Floor((double)z / _p3[n]);
            if (w == z % 26 + _p1[n])
                return z1;

            return 26 * z1 + w + _p2[n];
        }

        // search recursively from most significant digit
        public void Search(int depth, long z, int[] solution, List<string> solutions)
        {
            // found valid solution
            if (depth == 14)
            {
                if (z == 0)
                {
                    solutions.Add(string.Join("", solution));
                }
                return;
            }

            // if z is too large, abandon this branch
            if (z >= _zMax[depth])
                return;

            // continue with next digit
            for (var i = 1; i <= 9; ++i)
            {
                solution[depth] = i;
                Search(depth + 1, Process(depth, i, z), solution, solutions);
            }
        }
    }

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

    public class AluInstruction
    {
        private readonly char _address;
        private readonly string? _b;
        public string Operation { get; }

        public AluInstruction(string operation, char address, string? b)
        {
            _address = address;
            _b = b;
            Operation = operation;
        }

        public AluState Execute(AluState state)
        {
            //inp a - Read an input value and write it to variable a.
            //add a b - Add the value of a to the value of b, then store the result in variable a.
            //mul a b - Multiply the value of a by the value of b, then store the result in variable a.
            //div a b - Divide the value of a by the value of b, truncate the result to an integer, then store the result in variable a. (Here, "truncate" means to round the value toward zero.)
            //mod a b - Divide the value of a by the value of b, then store the remainder in variable a. (This is also called the modulo operation.)
            //eql a b - If the value of a and b are equal, then store the value 1 in variable a. Otherwise, store the value 0 in variable a.
            if (Operation == "inp")
            {
                var input = state.ReadInput();
                state.Memory[_address] = input;
                return state;
            }

            var value = GetValue(state, _b);
            if (Operation == "add")
            {
                state.Memory[_address] += value;
            }

            if (Operation == "mul")
            {
                state.Memory[_address] *= value;
            }

            if (Operation == "div")
            {
                state.Memory[_address] = (int)Math.Floor((double)state.Memory[_address] / value);
            }

            if (Operation == "mod")
            {
                state.Memory[_address] = state.Memory[_address] % value;
            }

            if (Operation == "eql")
            {
                state.Memory[_address] = state.Memory[_address] == value ? 1 : 0;
            }

            return state;
        }

        private long GetValue(AluState state, string? s)
        {
            var isAddress = IsAddress(s);
            if (isAddress)
            {
                var address = s![..1].ToCharArray().First();
                return state.Memory[address];
            }
            else
            {
                return int.Parse(s!);
            }
        }

        private static bool IsAddress(string? s) => s is "w" or "x" or "y" or "z";
    }
    
    public class Alu
    {
        private readonly IEnumerable<AluInstruction> _instructions;

        public Alu(string input)
        {
            var lines = input.Split(LineBreaks.Single);
            _instructions = lines.Select(ParseInstruction);
        }

        private static AluInstruction ParseInstruction(string s)
        {
            var parts = s.Split(' ');
            var operation = parts[0];
            var a = parts[1][..1].ToCharArray().First();
            var b = parts.Length > 2 ? parts[2] : null;

            return new AluInstruction(operation, a, b);
        }

        public AluState Process(long input, Dictionary<char, long>? memory = null)
        {
            var inputs = input.ToString().Select(o => int.Parse(o.ToString())).ToList();
            var state = new AluState(inputs, memory);

            foreach (var instruction in _instructions)
            {
                instruction.Execute(state);
            }

            return state;
        }
    }
}