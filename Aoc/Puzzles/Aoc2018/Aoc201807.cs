using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("The Sum of Its Parts")]
public class Aoc201807 : AocPuzzle
{
    [Puzzle("ed793c91fc1d9c9e6a4828232e0a8c2b")]
    public string Part1(string input) => new SleighAssembler(input, 1, 0).Assemble().Order;

    [Puzzle("c0599783d1840d6a6a7350bc40af4377")]
    public int Part2(string input) => new SleighAssembler(input, 5, 60).Assemble().Time;

    public class SleighWorker
    {
        public SleighStep? Task { get; set; }
        public int TimeLeft { get; set; }
        public bool IsIdle => TimeLeft == 0 && Task == null;
        public bool IsFinished => TimeLeft == 0 && Task != null;
        public bool IsWorking => Task != null;

        public void DecreaseTime()
        {
            if (TimeLeft > 0)
                TimeLeft -= 1;
        }
    }

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

    public class SleighResult
    {
        public string Order { get; }
        public int Time { get; }

        public SleighResult(string order, int time)
        {
            Order = order;
            Time = time;
        }
    }

    public class SleighAssembler
    {
        private readonly IDictionary<string, SleighStep> _steps;
        private readonly IList<SleighWorker> _workers;
        private readonly int _timeOffset;

        public SleighAssembler(string input, int workerCount, int timeOffset)
        {
            _steps = GetSteps(input);
            _workers = GetWorkers(workerCount);
            _timeOffset = timeOffset;
        }

        private IList<SleighWorker> GetWorkers(int workerCount)
        {
            var workers = new List<SleighWorker>();
            for (var i = 0; i < workerCount; i++)
            {
                workers.Add(new SleighWorker());
            }

            return workers;
        }

        public SleighResult Assemble()
        {
            var time = -1;

            var order = new StringBuilder();
            while (_steps.Values.Any() || _workers.Any(o => o.IsWorking))
            {
                var finishedWorkers = _workers.Where(o => o.IsFinished).ToList();
                foreach (var worker in finishedWorkers)
                {
                    order.Append(worker.Task!.Name);
                    RemoveDep(worker.Task.Name);
                    worker.Task = null;
                }

                var idleWorkers = _workers.Where(o => o.IsIdle).ToList();
                if (idleWorkers.Any())
                {
                    foreach (var worker in idleWorkers)
                    {
                        var stepsReadyToRun = _steps.Values.Where(o => !o.Deps.Any()).OrderBy(o => o.Name).ToList();
                        if (stepsReadyToRun.Any())
                        {
                            var step = stepsReadyToRun.First();
                            worker.Task = step;
                            worker.TimeLeft = GetRequiredTime(step);
                            RemoveStep(step.Name);
                        }
                    }
                }

                foreach (var worker in _workers)
                {
                    worker.DecreaseTime();
                }

                time += 1;
            }

            return new SleighResult(order.ToString(), time);
        }

        private int GetRequiredTime(SleighStep step)
        {
            var c = step.Name[0];
            return c - 'A' + 1 + _timeOffset;
        }

        private static IDictionary<string, SleighStep> GetSteps(string input)
        {
            var instructions = input.Split(LineBreaks.Single);
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

            return steps;
        }

        private void RemoveStep(string name)
        {
            _steps.Remove(name);
        }

        private void RemoveDep(string name)
        {
            foreach (var step in _steps.Values)
            {
                var dep = step.Deps.FirstOrDefault(o => o.Name == name);
                if (dep != null)
                    step.Deps.Remove(dep);
            }
        }
    }
}