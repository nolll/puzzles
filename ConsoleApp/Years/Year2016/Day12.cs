using System;
using Core.Tools;

namespace ConsoleApp.Years.Year2016
{
    public class Day12 : Day
    {
        public Day12() : base(12)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var control1 = new AssembunnyComputer(Input, 0, 0);
            Console.WriteLine($"Value in register A: {control1.ValueA}");

            WritePartTitle();
            var control2 = new AssembunnyComputer(Input, 0, 1);
            Console.WriteLine($"Value in register A: {control2.ValueA}");
        }

        private const string Input = @"cpy 1 a
cpy 1 b
cpy 26 d
jnz c 2
jnz 1 5
cpy 7 c
inc d
dec c
jnz c -2
cpy a c
inc a
dec b
jnz b -2
cpy c b
dec d
jnz d -6
cpy 16 c
cpy 12 d
inc a
dec d
jnz d -2
dec c
jnz c -5";
    }
}