using System.Collections.Generic;

namespace Core.OperationComputer
{
    public class OperationMatch
    {
        public int Opcode { get; }
        public IList<Operation> Operations { get; }

        public OperationMatch(int opcode, IList<Operation> operations)
        {
            Opcode = opcode;
            Operations = operations;
        }
    }
}