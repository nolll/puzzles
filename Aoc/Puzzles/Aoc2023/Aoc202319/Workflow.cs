namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202319;

public class Workflow(string label, List<WorkflowRule> rules)
{
    public string Label { get; } = label;
    public List<WorkflowRule> Rules { get; } = rules;
}