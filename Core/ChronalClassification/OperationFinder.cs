using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ChronalClassification
{
    public class OperationFinder
    {
        private readonly IList<Operation> _operations;

        public OperationFinder()
        {
            _operations = new List<Operation>
            {
                new AddrOperation(),
                new AddiOperation(),
                new MulrOperation(),
                new MuliOperation(),
                new BanrOperation(),
                new BaniOperation(),
                new BorrOperation(),
                new BoriOperation(),
                new SetrOperation(),
                new SetiOperation(),
                new GtirOperation(),
                new GtriOperation(),
                new GtrrOperation(),
                new EqirOperation(),
                new EqriOperation(),
                new EqrrOperation()
            };
        }

        public int InputsMatchingThreeOrMore(string input)
        {
            var count = 0;
            var rows = PuzzleInputReader.Read(input.Replace(":", "").Replace("[", "").Replace("]", "").Replace(",", ""));
            var before = new int[0];
            var command = new int[0];
            var after = new int[0];
            foreach (var row in rows)
            {
                if (row.StartsWith("Before"))
                {
                    before = row.Replace("Before", "").Trim().Split(' ').Select(int.Parse).ToArray();
                }
                else if (row.StartsWith("After"))
                {
                    after = row.Replace("After", "").Trim().Split(' ').Select(int.Parse).ToArray();
                    var matches = GetMatchingOperations(before, after, command[1], command[2], command[3]);
                    if (matches.Count >= 3)
                        count++;
                    continue;
                }
                else if (!string.IsNullOrEmpty(row))
                {
                    command = row.Split(' ').Select(int.Parse).ToArray();
                }
            }

            return count;
        }

        public IList<Operation> GetMatchingOperations(int[] before, int[] after, int a, int b, int c)
        {
            var matchingOperations = new List<Operation>();
            foreach (var operation in _operations)
            {
                var register = new int[4];
                before.CopyTo(register, 0);
                var result = operation.Execute(register, a, b, c);
                if (IsEqual(result, after))
                    matchingOperations.Add(operation);
            }

            return matchingOperations;
        }

        private static bool IsEqual(IReadOnlyList<int> a, IReadOnlyList<int> b)
        {
            if (a.Count != b.Count)
                return false;
            
            var index = 0;
            while (index < a.Count)
            {
                if (a[index] != b[index])
                    return false;
                index++;
            }
            return true;

        }

        public abstract class Operation
        {
            public abstract string Name { get; }
            public abstract int[] Execute(int[] registers, int a, int b, int c);
        }

        public class AddrOperation : Operation
        {
            public override string Name => "addr";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] + registers[b];
                return registers;
            }
        }

        public class AddiOperation : Operation
        {
            public override string Name => "addi";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] + b;
                return registers;
            }
        }

        public class MulrOperation : Operation
        {
            public override string Name => "mulr";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] * registers[b];
                return registers;
            }
        }

        public class MuliOperation : Operation
        {
            public override string Name => "muli";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] * b;
                return registers;
            }
        }

        public class BanrOperation : Operation
        {
            public override string Name => "banr";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] & registers[b];
                return registers;
            }
        }

        public class BaniOperation : Operation
        {
            public override string Name => "bani";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] & b;
                return registers;
            }
        }

        public class BorrOperation : Operation
        {
            public override string Name => "borr";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] | registers[b];
                return registers;
            }
        }

        public class BoriOperation : Operation
        {
            public override string Name => "bori";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] | b;
                return registers;
            }
        }

        public class SetrOperation : Operation
        {
            public override string Name => "setr";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a];
                return registers;
            }
        }

        public class SetiOperation : Operation
        {
            public override string Name => "seti";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = a;
                return registers;
            }
        }

        public class GtirOperation : Operation
        {
            public override string Name => "gtir";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = a > registers[b] ? 1 : 0;
                return registers;
            }
        }

        public class GtriOperation : Operation
        {
            public override string Name => "gtri";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] > b ? 1 : 0;
                return registers;
            }
        }

        public class GtrrOperation : Operation
        {
            public override string Name => "gtrr";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] > registers[b] ? 1 : 0;
                return registers;
            }
        }

        public class EqirOperation : Operation
        {
            public override string Name => "eqir";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = a == registers[b] ? 1 : 0;
                return registers;
            }
        }

        public class EqriOperation : Operation
        {
            public override string Name => "Eqri";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] == b ? 1 : 0;
                return registers;
            }
        }

        public class EqrrOperation : Operation
        {
            public override string Name => "eqrr";

            public override int[] Execute(int[] registers, int a, int b, int c)
            {
                registers[c] = registers[a] == registers[b] ? 1 : 0;
                return registers;
            }
        }
    }
}