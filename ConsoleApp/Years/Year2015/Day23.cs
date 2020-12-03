using System;
using Core.TuringLock;

namespace ConsoleApp.Years.Year2015
{
    public class Day23 : Day2015
    {
        public Day23() : base(23)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var computer1 = new ChristmasComputer();
            computer1.Run(Input);
            Console.WriteLine($"Value of register B: {computer1.RegisterB}");

            WritePartTitle();
            var computer2 = new ChristmasComputer();
            computer2.Run(Input, 1);
            Console.WriteLine($"Value of register B: {computer2.RegisterB}");
        }

        protected override string Input => @"
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