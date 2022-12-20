using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Lists;
using Core.Common.Strings;
using Core.Platform;

namespace Core.Puzzles.Year2022.Day20;

public class Year2022Day20 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var result = Run(FileInput, 1, 1);

        return new PuzzleResult(result, 18257);
    }

    public override PuzzleResult RunPart2()
    {
        var result = Run(FileInput, 811_589_153, 10);

        return new PuzzleResult(result, 4_148_032_160_983);
    }

    public long Run(string input, long multiplier, int iterationCount)
    {
        var numbers = PuzzleInputReader.ReadLines(input, false).Select(s => long.Parse(s) * multiplier).ToList();

        var list = new LinkedList<long>();
        var set = new Dictionary<long, LinkedListNode<long>>();

        var index = 0;
        foreach (var number in numbers)
        {
            var node = list.AddLast(number);
            set.Add(index, node);
            index++;
        }

        for (var iteration = 0; iteration < iterationCount; iteration++)
        {
            for (var i = 0; i < numbers.Count; i++)
            {
                var currentNode = set[i];
                var steps = Math.Abs(currentNode.Value) >= numbers.Count
                    ? currentNode.Value % (numbers.Count - 1)
                    : currentNode.Value;
                
                if (steps == 0)
                    continue;

                if (steps > 0)
                {
                    for (var j = 0; j < steps; j++)
                    {
                        var value = currentNode.Value;
                        var nextNode = currentNode.NextOrFirst();
                        list.Remove(currentNode);
                        currentNode = list.AddAfter(nextNode, value);
                    }
                }
                else
                {
                    for (var j = 0; j < Math.Abs(steps); j++)
                    {
                        var value = currentNode.Value;
                        var nextNode = currentNode.PreviousOrLast();
                        list.Remove(currentNode);
                        currentNode = list.AddBefore(nextNode, value);
                    }
                }

                set[i] = currentNode;
            }
        }

        var z = list.Find(0);
        var listFromZero = new long[list.Count];
        var c = z;
        for (var i = 0; i < list.Count; i++)
        {
            listFromZero[i] = c?.Value ?? 0;
            c = c.NextOrFirst();
        }

        long sum = 0;
        for (var i = 1; i <= 3; i += 1)
        {
            sum += listFromZero[i * 1000 % listFromZero.Length];
        }
        
        return sum;
    }
}