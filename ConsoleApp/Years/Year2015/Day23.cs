using System;
using Core.TuringLock;

namespace ConsoleApp.Years.Year2015
{
    public class Day23 : Day
    {
        public Day23() : base(23)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var computer = new ChristmasComputer();
            computer.Run(Input);
            Console.WriteLine($"Value of register B: {computer.RegisterB}");
        }

        private const string Input = @"
jio a, +18
inc a
tpl a
inc a
tpl a
tpl a
tpl a
inc a
tpl a
inc a
tpl a
inc a
inc a
tpl a
tpl a
tpl a
inc a
jmp +22
tpl a
inc a
tpl a
inc a
inc a
tpl a
inc a
tpl a
inc a
inc a
tpl a
tpl a
inc a
inc a
tpl a
inc a
inc a
tpl a
inc a
inc a
tpl a
jio a, +8
inc b
jie a, +4
tpl a
inc a
jmp +2
hlf a
jmp -7";
    }
}