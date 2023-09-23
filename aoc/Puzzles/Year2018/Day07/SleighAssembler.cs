using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Strings;

namespace Aoc.Puzzles.Year2018.Day07;

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

    private IDictionary<string, SleighStep> GetSteps(string input)
    {
        var instructions = PuzzleInputReader.ReadLines(input);
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
            if(dep != null)
                step.Deps.Remove(dep);
        }
    }
}