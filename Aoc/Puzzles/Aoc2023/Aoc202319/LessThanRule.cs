namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202319;

public class LessThanRule(string target, string field, int value) : WorkflowRule
{
    public override string Target { get; } = target;
    public override string Field { get; } = field;
    public override int Value { get; } = value;
    public override bool Evaluate(Part part) => Evaluate(part.Fields[Field]);
    public override bool Evaluate(int v) => v < Value;
}