using System;

namespace App.Common.Computers.IntCode
{
    public class ConsoleComputer : IntCodeComputer
    {
        public long Output { get; private set; }

        public ConsoleComputer(string input) : base(input)
        {
        }

        protected override long ReadInput()
        {
            Console.Write("Enter the ID of the system: ");
            var str = Console.ReadLine() ?? "";
            return int.Parse(str);
        }

        protected override void WriteOutput(long output)
        {
            Output = output;
            Console.WriteLine(output);
        }
    }
}