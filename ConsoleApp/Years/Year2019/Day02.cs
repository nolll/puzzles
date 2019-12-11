using System;
using ConsoleApp.Inputs;
using Core.Computer;

namespace ConsoleApp.Years.Year2019
{
    public class Day02 : Day
    {
        public Day02() : base(2)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var computer = new ConsoleComputer(InputData.ComputerProgramDay2);
            computer.Start();
            var value = computer.Output;
            Console.WriteLine($"Value at position 0: {value}");

            WritePartTitle();
            var solutionFinder = new ComputerSolutionFinder(InputData.ComputerProgramDay2);
            var result = solutionFinder.FindSolution(19690720);
            var answer = 100 * result.Noun + result.Verb;
            Console.WriteLine($"The answer is: {answer}");
        }
    }
}