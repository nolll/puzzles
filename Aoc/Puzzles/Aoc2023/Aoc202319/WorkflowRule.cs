namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202319;

public abstract class WorkflowRule
{
    public abstract string Target { get; }
    public abstract string Field { get; }
    public abstract int Value { get; }
    public abstract bool Evaluate(Part part);
    public abstract bool Evaluate(int v);

    public ValidValues Include(ValidValues validValues)
    {
        var v = new ValidValues(validValues);
        if(Field != "")
            v.Ranges[Field] = validValues.Ranges[Field].Where(Evaluate).ToList();
        return v;
    }

    public ValidValues Exclude(ValidValues validValues)
    {
        var v = new ValidValues(validValues);
        if (Field != "")
            v.Ranges[Field] = validValues.Ranges[Field].Where(o => !Evaluate(o)).ToList();
        return v;
    }
}