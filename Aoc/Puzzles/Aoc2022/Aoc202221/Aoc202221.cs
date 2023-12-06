using Puzzles.Common.Puzzles;
using Puzzles.Common.Strings;
using StringReader = Puzzles.Common.Strings.StringReader;

namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202221;

public class Aoc202221 : AocPuzzle
{
    public override string Name => "Monkey Math";

    protected override PuzzleResult RunPart1()
    {
        var result = Part1(InputFile);

        return new PuzzleResult(result, "b3adb16b1c9bf83decdb14842cf25854");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = Part2(InputFile);

        return new PuzzleResult(result, "cdbf9008c2bea6596aa238829913849e");
    }

    public long Part1(string input)
    {
        var lines = StringReader.ReadLines(input, false);
        var monkeys = GetMonkeys(lines);

        var root = monkeys["root"];
        var result = root.Yell(0);

        return result;
    }

    private Dictionary<string, YellMonkey> GetMonkeys(IEnumerable<string> lines)
    {
        var monkeys = new Dictionary<string, YellMonkey>();
        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var name = parts[0];
            var actionParts = parts[1].Split(' ');

            if (actionParts.Length == 1)
            {
                monkeys.Add(name, new NumberMonkey(monkeys, long.Parse(actionParts[0])));
            }
            else if (actionParts[1] == "+")
            {
                monkeys.Add(name, new AdditionMonkey(monkeys, actionParts[0], actionParts[2]));
            }
            else if (actionParts[1] == "-")
            {
                monkeys.Add(name, new SubtractionMonkey(monkeys, actionParts[0], actionParts[2]));
            }
            else if (actionParts[1] == "*")
            {
                monkeys.Add(name, new MultiplicationMonkey(monkeys, actionParts[0], actionParts[2]));
            }
            else if (actionParts[1] == "/")
            {
                monkeys.Add(name, new DivisionMonkey(monkeys, actionParts[0], actionParts[2]));
            }
        }

        return monkeys;
    }

    public long Part2(string input)
    {
        var lines = StringReader.ReadLines(input, false);

        var tempMonkeys = GetMonkeys(lines);
        var numbers = new Dictionary<string, long>();
        var list = lines.Where(line => !line.StartsWith("humn"))
            .Select(line => line.Replace(": ", " = "))
            .ToList();

        var rootLeft = tempMonkeys["root"].AName;
        var rootRight = tempMonkeys["root"].BName;
        var rootRightYell = tempMonkeys[rootRight!].Yell(0);
        numbers[rootRight!] = long.Parse(rootRightYell.ToString());
        numbers[rootLeft!] = long.Parse(rootRightYell.ToString());
        numbers.Remove("humn");

        var queue = new Queue<string>();
        foreach (var item in list)
        {
            queue.Enqueue(item);
        }
        
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
                    {
                        current = current.Replace(left, leftResult.ToString());
                    }

                    if (!middleIsNumber && numbers.TryGetValue(middle, out var middleResult))
                    {
                        current = current.Replace(middle, middleResult.ToString());
                    }

                    if (!rightIsNumber && numbers.TryGetValue(right, out var rightResult))
                    {
                        current = current.Replace(right, rightResult.ToString());
                    }

                    queue.Enqueue(current);
                }
            }
        }
        
        var human = numbers["humn"];
        return human;
    }

    private static string FindFormulaFor(string s, string key)
    {
        var parts = s.Split();
        var left = parts[0];
        var middle = parts[2];
        var op = parts[3];
        var right = parts[4];
        var searchedIsMiddle = key == middle;

        if (op == "+")
        {
            return searchedIsMiddle
                ? $"{middle} = {left} - {right}"
                : $"{right} = {left} - {middle}";
        }
        if (op == "-")
        {
            return searchedIsMiddle
                ? $"{middle} = {left} + {right}"
                : $"{right} = {left} + {middle}";
        }
        if (op == "*")
        {
            return searchedIsMiddle
                ? $"{middle} = {left} / {right}"
                : $"{right} = {left} / {middle}";
        }
        return searchedIsMiddle
            ? $"{middle} = {left} * {right}"
            : $"{right} = {left} * {middle}";
    }

    private static long PerformCalc(long leftNumber, long rightNumber, string operation)
    {
        if (operation == "+")
            return (leftNumber + rightNumber);
        if (operation == "-")
            return (leftNumber - rightNumber);
        if (operation == "*")
            return (leftNumber * rightNumber);
        return (leftNumber / rightNumber);
    }

    private bool IsNumber(string s)
    {
        return long.TryParse(s, out _);
    }
}