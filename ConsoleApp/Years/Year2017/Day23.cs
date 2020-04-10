using System;
using Core.CoprocessorConflagration;
using Core.SporificaVirus;

namespace ConsoleApp.Years.Year2017
{
    public class Day23 : Day
    {
        public Day23() : base(23)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var processor1 = new CoProcessor(Input);
            processor1.Run();
            Console.WriteLine($"The mul instruction was invoked {processor1.MulCount} times.");

            WritePartTitle();
            var processor2 = new OptimizedCoProcessor();
            processor2.Run();
            Console.WriteLine($"Value left in register h: {processor2.H}.");

            //WritePartTitle();
            //var processor2 = new CoProcessor(Input, 1);
            //processor2.Run();
            //Console.WriteLine($"Value left in register h: {processor2.RegisterH}.");
        }

        private const string Input = @"
set b 67
set c b
jnz a 2
jnz 1 5
mul b 100
sub b -100000
set c b
sub c -17000
set f 1
set d 2
set e 2
set g d
mul g e
sub g b
jnz g 2
set f 0
sub e -1
set g e
sub g b
jnz g -8
sub d -1
set g d
sub g b
jnz g -13
jnz f 2
sub h -1
set g b
sub g c
jnz g 2
jnz 1 3
sub b -17
jnz 1 -23";
    }
}