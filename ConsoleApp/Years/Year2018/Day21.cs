using System;
using Core.OperationComputer;

namespace ConsoleApp.Years.Year2018
{
    public class Day21 : Day
    {
        public Day21() : base(21)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var computer = new OpComputer();
            var value = computer.RunInstructionPointerProgram(Input, 103548, false, false);
            Console.WriteLine($"Lowest value for register zero: {value}");
        }

        private const string Input = @"
#ip 1
seti 123 0 4
bani 4 456 4
eqri 4 72 4
addr 4 1 1
seti 0 0 1
seti 0 2 4
bori 4 65536 3
seti 10552971 1 4
bani 3 255 5
addr 4 5 4
bani 4 16777215 4
muli 4 65899 4
bani 4 16777215 4
gtir 256 3 5
addr 5 1 1
addi 1 1 1
seti 27 7 1
seti 0 1 5
addi 5 1 2
muli 2 256 2
gtrr 2 3 2
addr 2 1 1
addi 1 1 1
seti 25 0 1
addi 5 1 5
seti 17 2 1
setr 5 7 3
seti 7 8 1
eqrr 4 0 5
addr 5 1 1
seti 5 0 1";
    }
}