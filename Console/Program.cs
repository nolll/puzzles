using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Console.Inputs;
using Core.Computer;
using Core.IntersectionFinder;
using Core.ModuleMass;
using Core.Passwords;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1Part1();
            //Day1Part2();

            //Day2Part1();
            //Day2Part2();

            //Day3Part1();
            //Day3Part2();

            Day4Part1();
        }

        private static void Day1Part1()
        {
            var massCalculator = new MassCalculator(InputData.ModulesMasses);

            WriteTitle(1, 1);
            System.Console.WriteLine($"Required fuel: {massCalculator.MassFuel}");
        }

        private static void Day1Part2()
        {
            var massCalculator = new MassCalculator(InputData.ModulesMasses);

            WriteTitle(1, 2);
            System.Console.WriteLine($"Required fuel: {massCalculator.TotalFuel}");
        }

        private static void Day2Part1()
        {
            var computer = new IntCodeComputer(InputData.IntCodeMemory);
            var value = computer.Run().Integer;

            WriteTitle(2, 1);
            System.Console.WriteLine($"Value at position 0: {value}");
        }

        private static void Day2Part2()
        {
            var solutionFinder = new ComputerSolutionFinder(InputData.IntCodeMemory);
            var result = solutionFinder.FindSolution(19690720);
            var answer = 100 * result.Noun + result.Verb;

            WriteTitle(2, 2);
            System.Console.WriteLine($"The answer is: {answer}");
        }

        private static void Day3Part1()
        {
            var intersectionFinder = new IntersectionFinder(InputData.WirePathA, InputData.WirePathB);
            var result = intersectionFinder.ClosestIntersection.Distance;

            WriteTitle(3, 1);
            System.Console.WriteLine($"The distance of the closest intersection is: {result}");
        }

        private static void Day3Part2()
        {
            var intersectionFinder = new IntersectionFinder(InputData.WirePathA, InputData.WirePathB);
            var result = intersectionFinder.FewestSteps.Steps;

            WriteTitle(3, 2);
            System.Console.WriteLine($"The fewest combined steps to the closest intersection is: {result}");
        }

        private static void Day4Part1()
        {
            var passwordFinder = new PasswordFinder();
            var passwords = passwordFinder.Find(InputData.PasswordLowerbound, InputData.PasswordUpperbound);
            var passwordCount = passwords.Count();

            WriteTitle(4, 1);
            System.Console.WriteLine($"Number of valid passwords: {passwordCount}");
        }

        private static void WriteTitle(int day, int part)
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"Day {day}, part {part}:");
        }
    }

    public class PasswordFinder
    {
        public IEnumerable<int> Find(int lowerBound, int upperBound)
        {
            var passwordValidator = new PasswordValidator();

            for (var pwd = lowerBound; pwd <= upperBound; pwd++)
            {
                if (passwordValidator.IsValid(pwd))
                    yield return pwd;
            }
        }
    }
}
