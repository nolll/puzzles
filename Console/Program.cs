using System;
using System.Linq;
using Core;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Day2Part2();
            //Day2Part1();
            
            //Day1Part2();
            //Day1Part1();
        }

        private static void Day2Part2()
        {
            var solutionFinder = new ComputerSolutionFinder();
            var result = solutionFinder.FindSolution(19690720);
            var answer = 100 * result.Noun + result.Verb;

            WriteTitle(2, 2);
            Console.WriteLine($"The answer is: {answer}");
        }

        private static void Day2Part1()
        {
            var computer = new IntCodeComputer();
            var value = computer.Run().Integer;

            WriteTitle(2, 1);
            Console.WriteLine($"Value at position 0: {value}");
        }

        private static void Day1Part2()
        {
            var modules = new ModuleRepository().List();
            var requiredFuel = modules.Sum(o => o.TotalFuel);
            WriteTitle(1, 2);
            Console.WriteLine($"Required fuel: {requiredFuel}");
        }

        private static void Day1Part1()
        {
            var modules = new ModuleRepository().List();
            var requiredFuel = modules.Sum(o => o.MassFuel);
            WriteTitle(1, 1);
            Console.WriteLine($"Required fuel: {requiredFuel}");
        }

        private static void WriteTitle(int day, int part)
        {
            Console.WriteLine($"Day {day}, part {part}:");
        }
    }
}
