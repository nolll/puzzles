using System;
using Core.SafeCracking;
using Core.Tools;

namespace ConsoleApp.Years.Year2016
{
    public class Day23 : Day
    {
        public Day23() : base(23)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            //var computer1 = new AssembunnyComputerPart1(Input, 7, 0);
            //Console.WriteLine($"Value in register A: {computer1.ValueA}");

            WritePartTitle();
            // By inspecting output from the computer I realized that it is calculating the factorial of 12
            var computer2 = new SafeCrackingComputerPart2(Input, 12, 0);
            Console.WriteLine($"Value in register A: {computer2.ValueA}");
            //var factorial = Factorial(12);
            //Console.WriteLine($"Value in register A: {factorial}");
        }

        private const string Input = @"
cpy a b
dec b
cpy a d
cpy 0 a
cpy b c
inc a
dec c
jnz c -2
dec d
jnz d -5
dec b
cpy b c
cpy c d
dec d
inc c
jnz d -2
tgl c
cpy -16 c
jnz 1 c
cpy 94 c
jnz 82 d
inc a
inc d
jnz d -2
inc c
jnz c -5";
    }
}