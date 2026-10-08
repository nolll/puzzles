using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("The Sum of Its Parts")]
public class Aoc201807 : AocPuzzle
{
    [Puzzle("ed793c91fc1d9c9e6a4828232e0a8c2b")]
    public string Part1(string input) => Solve(input, 1, 0).order;

    [Puzzle("c0599783d1840d6a6a7350bc40af4377")]
    public int Part2(string input) => Solve(input, 5, 60).time;

    public (string order, int time) Solve(string input, int workerCount, int timeOffset)
    {
        var time = -1;
        var steps = GetSteps(input);
        var workers = GetWorkers(workerCount);
        var order = new StringBuilder();
        while (steps.Values.Any() || workers.Any(o => o.IsWorking))
        {
            var finishedWorkers = workers.Where(o => o.IsFinished).ToList();
            foreach (var worker in finishedWorkers)
            {
                order.Append(worker.Task!.Name);
                RemoveDep(steps, worker.Task.Name);
                worker.Task = null;
            }

            var idleWorkers = workers.Where(o => o.IsIdle).ToList();
            if (idleWorkers.Any())
            {
                foreach (var worker in idleWorkers)
                {
                    var stepsReadyToRun = steps.Values.Where(o => !o.Deps.Any()).OrderBy(o => o.Name).ToList();
                    if (stepsReadyToRun.Any())
                    {
                        var step = stepsReadyToRun.First();
                        worker.Task = step;
                        worker.TimeLeft = GetRequiredTime(timeOffset, step);
                        steps.Remove(step.Name);
                    }
                }
            }

            foreach (var worker in workers)
            {
                worker.DecreaseTime();
            }

            time += 1;
        }

        return (order.ToString(), time);
    }
    
    private static IList<SleighWorker> GetWorkers(int workerCount)
    {
        var workers = new List<SleighWorker>();
        for (var i = 0; i < workerCount; i++)
        {
            workers.Add(new SleighWorker());
        }

        return workers;
    }

    private static int GetRequiredTime(int timeOffset, SleighStep step) => step.Name[0] - 'A' + 1 + timeOffset;

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

    private static void RemoveDep(IDictionary<string, SleighStep> steps, string name)
    {
        foreach (var step in steps.Values)
        {
            var dep = step.Deps.FirstOrDefault(o => o.Name == name);
            if (dep != null)
                step.Deps.Remove(dep);
        }
    }

    private class SleighWorker
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

    public record SleighStep(string Name)
    {
        public IList<SleighStep> Deps { get; } = new List<SleighStep>();
    }
}