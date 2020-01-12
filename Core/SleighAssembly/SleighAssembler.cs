using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Tools;

namespace Core.SleighAssembly
{
    public class SleighAssembler
    {
        public string Assemble(string input)
        {
            var instructions = PuzzleInputReader.Read(input);
            var steps = new Dictionary<string, SleighStep>();
            foreach (var instruction in instructions)
            {
                var depName = instruction.Substring(5, 1);
                var name = instruction.Substring(36, 1);
                steps.TryGetValue(depName, out var dep);
                if (dep == null)
                {
                    dep = new SleighStep(depName);
                    steps.Add(depName, dep);
                }

                if (steps.ContainsKey(name))
                {
                    steps[name].Deps.Add(dep);
                }
                else
                {
                    var step = new SleighStep(name);
                    step.Deps.Add(dep);
                    steps.Add(name, step);
                }
            }

            var order = new StringBuilder();
            while (steps.Values.Any())
            {
                var availableSteps = steps.Values.Where(o => !o.Deps.Any());
                var step = availableSteps.OrderBy(o => o.Name).FirstOrDefault();
                order.Append(step.Name);
                Remove(steps, step.Name);
            }
            return order.ToString();
        }

        private void Remove(IDictionary<string, SleighStep> steps, string name)
        {
            var dep = steps[name];
            steps.Remove(name);
            foreach (var step in steps.Values)
            {
                step.Deps.Remove(dep);
            }
        }
    }
}