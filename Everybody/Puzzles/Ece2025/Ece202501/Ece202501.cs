using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202501;

[Name("Whispers in the Shell")]
public class Ece202501 : EverybodyEventPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var (names, instructions) = Parse(input);
        var index = 0;
        const int min = 0;
        var max = names.Length - 1;

        foreach (var instruction in instructions)
        {
            var (direction, distance) = ParseInstruction(instruction);
            index = Math.Clamp(index + direction * distance, min, max);
        }
        
        return new PuzzleResult(names[index], "471e7e193cef7ed98fca951fa22d1b63");
    }

    public PuzzleResult RunPart2(string input)
    {
        var (names, instructions) = Parse(input);
        var index = 0;

        foreach (var instruction in instructions)
        {
            var (direction, distance) = ParseInstruction(instruction);
            index = EnsureBetween(index + direction * distance, 0, names.Length);
        }
        
        return new PuzzleResult(names[index], "4c1a9174f14f00b9309ceb208fb603b6");
    }

    public PuzzleResult RunPart3(string input)
    {
        var (names, instructions) = Parse(input);

        foreach (var instruction in instructions)
        {
            var (direction, distance) = ParseInstruction(instruction);
            var index = EnsureBetween(direction * distance, 0, names.Length);
            (names[index], names[0]) = (names[0], names[index]);
        }
        
        return new PuzzleResult(names[0], "e09ddbd33e9031bea67180ca55d1c14e");
    }

    private static (string[] names, string[] instructions) Parse(string input)
    {
        var (nameString, instructionString) = input.Split(LineBreaks.Double);
        var names = nameString.Split(',');
        var instructions = instructionString.Split(',');
        return (names, instructions);
    }
    
    private static (int direction, int distance) ParseInstruction(string instruction)
    {
        var direction = instruction[0] == 'L' ? -1 : 1;
        var distance = int.Parse(instruction[1..]);
        return (direction, distance);
    }

    private static int EnsureBetween(int v, int min, int max)
    {
        var nv = v;
        while (nv < min)
            nv += max;

        return nv % max;
    }
}