using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Monkey Math")]
public class Aoc202221 : AocPuzzle
{
    [Puzzle("b3adb16b1c9bf83decdb14842cf25854")]
    public long Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single).Where(o => o.Length > 0);
        var monkeys = GetMonkeys(lines);
        return monkeys["root"].Yell();
    }

    [Puzzle("cdbf9008c2bea6596aa238829913849e")]
    public long Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single).Where(o => o.Length > 0).ToList();

        var tempMonkeys = GetMonkeys(lines);
        var numbers = new Dictionary<string, long>();
        var list = lines.Where(line => !line.StartsWith("humn"))
            .Select(line => line.Replace(": ", " = "))
            .ToList();

        var rootLeft = tempMonkeys["root"].AName;
        var rootRight = tempMonkeys["root"].BName;
        var rootRightYell = tempMonkeys[rootRight].Yell();
        numbers[rootRight] = long.Parse(rootRightYell.ToString());
        numbers[rootLeft] = long.Parse(rootRightYell.ToString());
        numbers.Remove("humn");

        var queue = new Queue<string>(list);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var parts = current.Split(' ');

            var left = parts[0];
            var middle = parts[2];
            var leftIsNumber = IsNumber(left);
            var middleIsNumber = IsNumber(middle);
            var canMoveToNumbers = !leftIsNumber && middleIsNumber;
            var canMoveToNumbersSwitched = leftIsNumber && !middleIsNumber;
            if (parts.Length == 3)
            {
                if(canMoveToNumbers)
                    numbers[left] = long.Parse(middle);
                else if(canMoveToNumbersSwitched)
                    numbers[middle] = long.Parse(left);
            }
            else if (parts.Length == 5)
            {
                var op = parts[3];
                var right = parts[4];

                var rightIsNumber = IsNumber(right);
                var shouldPerformCalc = middleIsNumber && rightIsNumber;
                if (shouldPerformCalc)
                {
                    var result = PerformCalc(long.Parse(middle), long.Parse(right), op);
                    queue.Enqueue($"{left} = {result}");
                }
                else if (IsNumber(left) && !IsNumber(middle))
                {
                    var result = FindFormulaFor(current, middle);
                    queue.Enqueue(result);
                }
                else if (IsNumber(left) && !IsNumber(right))
                {
                    var result = FindFormulaFor(current, right);
                    queue.Enqueue(result);
                }
                else
                {
                    if (!leftIsNumber && numbers.TryGetValue(left, out var leftResult)) 
                        current = current.Replace(left, leftResult.ToString());
                    
                    if (!middleIsNumber && numbers.TryGetValue(middle, out var middleResult)) 
                        current = current.Replace(middle, middleResult.ToString());

                    if (!rightIsNumber && numbers.TryGetValue(right, out var rightResult)) 
                        current = current.Replace(right, rightResult.ToString());

                    queue.Enqueue(current);
                }
            }
        }
        
        return numbers["humn"];
    }

    private static Dictionary<string, YellMonkey> GetMonkeys(IEnumerable<string> lines)
    {
        var monkeys = new Dictionary<string, YellMonkey>();
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var name = parts[0];
            var actionParts = parts[1].Split(' ');

            if (actionParts.Length == 1)
                monkeys.Add(name, new NumberMonkey(monkeys, long.Parse(actionParts[0])));
            else if (actionParts[1] == "+")
                monkeys.Add(name, new AdditionMonkey(monkeys, actionParts[0], actionParts[2]));
            else if (actionParts[1] == "-")
                monkeys.Add(name, new SubtractionMonkey(monkeys, actionParts[0], actionParts[2]));
            else if (actionParts[1] == "*")
                monkeys.Add(name, new MultiplicationMonkey(monkeys, actionParts[0], actionParts[2]));
            else if (actionParts[1] == "/") 
                monkeys.Add(name, new DivisionMonkey(monkeys, actionParts[0], actionParts[2]));
        }

        return monkeys;
    }

    private static string FindFormulaFor(string s, string key)
    {
        var (left, _, middle, op, right) = s.Split();
        var searchedIsMiddle = key == middle;

        return op switch
        {
            "+" => searchedIsMiddle ? $"{middle} = {left} - {right}" : $"{right} = {left} - {middle}",
            "-" => searchedIsMiddle ? $"{middle} = {left} + {right}" : $"{right} = {left} + {middle}",
            "*" => searchedIsMiddle ? $"{middle} = {left} / {right}" : $"{right} = {left} / {middle}",
            _ => searchedIsMiddle ? $"{middle} = {left} * {right}" : $"{right} = {left} * {middle}"
        };
    }

    private static long PerformCalc(long leftNumber, long rightNumber, string operation) => operation switch
    {
        "+" => leftNumber + rightNumber,
        "-" => leftNumber - rightNumber,
        "*" => leftNumber * rightNumber,
        _ => leftNumber / rightNumber
    };

    private static bool IsNumber(string s) => long.TryParse(s, out _);

    private class AdditionMonkey(Dictionary<string, YellMonkey> monkeys, string aName, string bName) : MathMonkey(monkeys, aName, bName)
    {
        public override long Yell() => A.Yell() + B.Yell();
    }

    private class DivisionMonkey(Dictionary<string, YellMonkey> monkeys, string aName, string bName) : MathMonkey(monkeys, aName, bName)
    {
        public override long Yell() => A.Yell() / B.Yell();
    }

    private class MultiplicationMonkey(Dictionary<string, YellMonkey> monkeys, string aName, string bName) : MathMonkey(monkeys, aName, bName)
    {
        public override long Yell() => A.Yell() * B.Yell();
    }

    private class SubtractionMonkey(Dictionary<string, YellMonkey> monkeys, string aName, string bName) : MathMonkey(monkeys, aName, bName)
    {
        public override long Yell() => A.Yell() - B.Yell();
    }
    
    private class NumberMonkey(Dictionary<string, YellMonkey> monkeys, long number) : YellMonkey(monkeys)
    {
        public override string AName => "";
        public override string BName => "";
        public override long Yell() => number;
    }
    
    private abstract class MathMonkey(Dictionary<string, YellMonkey> monkeys, string aName, string bName) : YellMonkey(monkeys)
    {
        public override string AName { get; } = aName;
        public override string BName { get; } = bName;
        protected YellMonkey A => field ??= Monkeys[AName];
        protected YellMonkey B => field ??= Monkeys[BName];
    }
    
    public abstract class YellMonkey(Dictionary<string, YellMonkey> monkeys)
    {
        protected readonly Dictionary<string, YellMonkey> Monkeys = monkeys;
        public abstract string AName { get; }
        public abstract string BName { get; }
        public abstract long Yell();
    }
}