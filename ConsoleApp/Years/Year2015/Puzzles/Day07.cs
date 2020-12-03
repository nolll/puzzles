using System;
using Core.BitwiseLogic;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day07 : Day2015
    {
        public Day07() : base(7)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var circuit = new Circuit(FileInput);
            var runOne = circuit.RunOne("a");

            Console.WriteLine($"Signal A after run one: {runOne}");

            WritePartTitle();
            var runTwo = circuit.RunTwo("a", "b");

            Console.WriteLine($"Signal A after run two: {runTwo}");
        }
    }
}