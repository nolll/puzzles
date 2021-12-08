using System.Collections.Generic;

namespace App.Puzzles.Year2018.Day07
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