using System;
using Core.OperationComputer;

namespace ConsoleApp.Years.Year2018
{
    public class Day19 : Day2018
    {
        public Day19() : base(19)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var computer = new OpComputer();
            var value1 = computer.RunInstructionPointerProgram(Input, 0, true, false);
            Console.WriteLine($"Value at register 0 when program halts: {value1}");

            WritePartTitle();
            var computer2 = new OpComputer();
            var value2 = computer2.RunInstructionPointerProgram(Input, 1, true, false);
            Console.WriteLine($"Value at register 0 when program halts: {value2}");
        }

        protected override string Input => @"
#ip 5
addi 5 16 5
seti 1 8 4
seti 1 5 3
mulr 4 3 1
eqrr 1 2 1
addr 1 5 5
addi 5 1 5
addr 4 0 0
addi 3 1 3
gtrr 3 2 1
addr 5 1 5
seti 2 5 5
addi 4 1 4
gtrr 4 2 1
addr 1 5 5
seti 1 2 5
mulr 5 5 5
addi 2 2 2
mulr 2 2 2
mulr 5 2 2
muli 2 11 2
addi 1 8 1
mulr 1 5 1
addi 1 18 1
addr 2 1 2
addr 5 0 5
seti 0 7 5
setr 5 0 1
mulr 1 5 1
addr 5 1 1
mulr 5 1 1
muli 1 14 1
mulr 1 5 1
addr 2 1 2
seti 0 0 0
seti 0 9 5";
    }
}