namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201621;

public interface IScrambleInstruction
{
    string Run(string s);
    string RunBackwards(string s);
}