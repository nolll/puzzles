using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201621;

public class StringScrambler
{
    private readonly IList<IScrambleInstruction> _instructions;

    public StringScrambler(string input)
    {
        _instructions = ParseInstructions(input);
    }

    public string Scramble(string str)
    {
        foreach (var instruction in _instructions)
            str = instruction.Run(str);

        return str;
    }


    public string Unscramble(string str)
    {
        foreach (var instruction in _instructions.Reverse())
            str = instruction.RunBackwards(str);

        return str;
    }

    private IList<IScrambleInstruction> ParseInstructions(string input)
    {
        var instructions = new List<IScrambleInstruction>();
        var rows = StringReader.ReadLines(input);
        foreach (var row in rows)
        {
            instructions.Add(ParseInstruction(row));
        }

        return instructions;
    }

    private IScrambleInstruction ParseInstruction(string s)
    {
        var parts = s.Split(' ');
        var command = parts[0];
        if (command == "swap")
        {
            if (parts[1] == "position")
                return new SwapPositionInstruction(int.Parse(parts[2]), int.Parse(parts[5]));
            return new SwapLetterInstruction(parts[2].First(), parts[5].First());
        }

        if (command == "rotate")
        {
            var type = parts[1];
            if (type == "left")
                return new RotateLeftInstruction(int.Parse(parts[2]));

            if (type == "right")
                return new RotateRightInstruction(int.Parse(parts[2]));

            if (type == "based")
                return new RotateBasedOnPositionInstruction(parts[6].First());
        }

        if (command == "reverse")
            return new ReverseInstruction(int.Parse(parts[2]), int.Parse(parts[4]));

        if (command == "move")
            return new MoveInstruction(int.Parse(parts[2]), int.Parse(parts[5]));

        throw new Exception($"Error parsing instruction: {s}");
    }
}