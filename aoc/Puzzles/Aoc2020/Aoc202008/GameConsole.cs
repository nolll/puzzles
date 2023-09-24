using System.Collections.Generic;

namespace Aoc.Puzzles.Aoc2020.Aoc202008;

public class GameConsole
{
    private readonly IList<GameConsoleInstruction> _instructions;
    private int _acc;
    private int _pos;

    public GameConsole(IList<GameConsoleInstruction> instructions)
    {
        _instructions = instructions;
    }

    public GameConsoleExit Run()
    {
        var wasRun = true;
        while (wasRun)
        {
            if(_pos >= _instructions.Count)
                return new GameConsoleExit(ExitStatus.End, _acc);
            wasRun = RunInstruction(_instructions[_pos]);
        }

        return new GameConsoleExit(ExitStatus.Loop, _acc);
    }

    private bool RunInstruction(GameConsoleInstruction instruction)
    {
        if (instruction.ExecutionCount == 1)
            return false;

        instruction.IncreaseExecutionCount();

        if (instruction.Name == "jmp")
        {
            _pos += instruction.Value;
            return true;
        }

        if (instruction.Name == "acc")
        {
            _acc += instruction.Value;
            _pos += 1;
            return true;
        }

        _pos += 1;
        return true;
    }
}