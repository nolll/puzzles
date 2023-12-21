namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202319;

public class LessThanRule(string target, string field, int value) : WorkflowRule
{
    public override string Target { get; } = target;
    protected override string Field { get; } = field;
    public override bool Evaluate(Part part) => Evaluate(part.Fields[Field]);
    protected override bool Evaluate(int v) => v < value;
}