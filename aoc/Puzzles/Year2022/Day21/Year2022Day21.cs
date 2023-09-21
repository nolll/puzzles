using System.Collections.Generic;
using System.Linq;
using Aoc.Platform;
using common.Puzzles;
using common.Strings;

namespace Aoc.Puzzles.Year2022.Day21;

public class Year2022Day21 : AocPuzzle
{
    public override string Name => "Monkey Math";

    public override PuzzleResult RunPart1()
    {
        var result = Part1(FileInput);

        return new PuzzleResult(result, 223_971_851_179_174);
    }

    public override PuzzleResult RunPart2()
    {
        var result = Part2(FileInput);

        return new PuzzleResult(result, 3_379_022_190_351);
    }

    public long Part1(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input, false);
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
        var lines = PuzzleInputReader.ReadLines(input, false);

        var tempMonkeys = GetMonkeys(lines);
        var numbers = new Dictionary<string, long>();
        var list = lines.Where(line => !line.StartsWith("humn"))
            .Select(line => line.Replace(": ", " = "))
            .ToList();

        var rootLeft = tempMonkeys["root"].AName;
        var rootRight = tempMonkeys["root"].BName;
        var rootRightYell = tempMonkeys[rootRight].Yell(0);
        numbers[rootRight] = long.Parse(rootRightYell.ToString());
        numbers[rootLeft] = long.Parse(rootRightYell.ToString());
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