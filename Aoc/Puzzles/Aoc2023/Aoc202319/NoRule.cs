namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202319;

public class NoRule(string target) : WorkflowRule
{
    public override string Target { get; } = target;
    public override string Field { get; } = "";
    public override int Value { get; } = 0;
    public override bool Evaluate(Part part) => Evaluate(0);
    public override bool Evaluate(int v) => true;
}