using System.Linq;
using Console.Inputs;
using Core.Computer;
using Core.IntersectionFinder;
using Core.Modules;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Day3Part2();
            //Day3Part1();

            //Day2Part2();
            //Day2Part1();

            //Day1Part2();
            //Day1Part1();
        }

        private static void Day3Part2()
        {
            var intersectionFinder = new IntersectionFinder(InputData.WirePathA, InputData.WirePathB);
            var result = intersectionFinder.FewestSteps.Steps;

            WriteTitle(3, 2);
            System.Console.WriteLine($"The fewest combined steps to the closest intersection is: {result}");
        }

        private static void Day3Part1()
        {
            var intersectionFinder = new IntersectionFinder(InputData.WirePathA, InputData.WirePathB);
            var result = intersectionFinder.ClosestIntersection.Distance;

            WriteTitle(3, 1);
            System.Console.WriteLine($"The distance of the closest intersection is: {result}");
        }

        private static void Day2Part2()
        {
            var solutionFinder = new ComputerSolutionFinder();
            var result = solutionFinder.FindSolution(19690720);
            var answer = 100 * result.Noun + result.Verb;

            WriteTitle(2, 2);
            System.Console.WriteLine($"The answer is: {answer}");
        }

        private static void Day2Part1()
        {
            var computer = new IntCodeComputer();
            var value = computer.Run().Integer;

            WriteTitle(2, 1);
            System.Console.WriteLine($"Value at position 0: {value}");
        }

        private static void Day1Part2()
        {
            var modules = new ModuleRepository().List();
            var requiredFuel = modules.Sum(o => o.TotalFuel);
            WriteTitle(1, 2);
            System.Console.WriteLine($"Required fuel: {requiredFuel}");
        }

        private static void Day1Part1()
        {
            var modules = new ModuleRepository().List();
            var requiredFuel = modules.Sum(o => o.MassFuel);
            WriteTitle(1, 1);
            System.Console.WriteLine($"Required fuel: {requiredFuel}");
        }

        private static void WriteTitle(int day, int part)
        {
            System.Console.WriteLine($"Day {day}, part {part}:");
        }
    }
}
