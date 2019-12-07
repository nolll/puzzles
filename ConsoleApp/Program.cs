using System.Linq;
using ConsoleApp.Inputs;
using Core.Computer;
using Core.IntersectionFinder;
using Core.ModuleMass;
using Core.Orbits;
using Core.Thrust;

namespace ConsoleApp
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

            //Day4();

            //Day5();

            //Day6Part1();
            //Day6Part2();

            Day7Part1();
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
            var computer = new ConsoleComputer(InputData.ComputerProgramDay2);
            var value = computer.Run().Integer;

            WriteTitle(2, 1);
            System.Console.WriteLine($"Value at position 0: {value}");
        }

        private static void Day2Part2()
        {
            var solutionFinder = new ComputerSolutionFinder(InputData.ComputerProgramDay2);
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

        private static void Day4()
        {
            var passwordFinder = new Core.Passwords.PasswordFinder();
            var passwords = passwordFinder.Find(InputData.PasswordLowerbound, InputData.PasswordUpperbound);
            var passwordCount = passwords.Count();

            WriteTitle(4);
            System.Console.WriteLine($"Number of valid passwords: {passwordCount}");
        }

        private static void Day5()
        {
            var computer = new ConsoleComputer(InputData.ComputerProgramDay5);

            WriteTitle(5);

            computer.Run();
        }

        private static void Day6Part1()
        {
            var calculator = new OrbitCalculator(InputStrings.Orbits);
            var orbitCount = calculator.GetOrbitCount();

            WriteTitle(6, 1);

            System.Console.WriteLine($"Total number of orbits: {orbitCount}");
        }

        private static void Day6Part2()
        {
            var calculator = new OrbitCalculator(InputStrings.Orbits);
            var distance = calculator.GetSantaDistance();

            WriteTitle(6, 2);

            System.Console.WriteLine($"Distance to Santa: {distance}");
        }

        private static void Day7Part1()
        {
            var calculator = new ThrustCalculator(InputData.ComputerProgramDay7);
            var maxThrust = calculator.GetMaxThrust();

            WriteTitle(7, 1);

            System.Console.WriteLine($"Maximum thrust: {maxThrust}");
        }

        private static void WriteTitle(int day, int? part = null)
        {
            System.Console.WriteLine();
            if(part == null)
                System.Console.WriteLine($"Day {day}:");
            System.Console.WriteLine($"Day {day}, part {part}:");
        }
    }
}
