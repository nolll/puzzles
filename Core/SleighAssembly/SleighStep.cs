using System.Collections.Generic;

namespace Core.SleighAssembly
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