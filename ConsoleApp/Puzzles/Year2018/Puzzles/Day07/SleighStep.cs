using System.Collections.Generic;

namespace ConsoleApp.Puzzles.Year2018.Puzzles.Day07
{
    public class SleighStep
    {
        public string Name { get; }
        public IList<SleighStep> Deps { get; }

        public SleighStep(string name)
        {
            Name = name;
            Deps = new List<SleighStep>();
        }
    }
}