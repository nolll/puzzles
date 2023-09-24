namespace Aoc.Puzzles.Aoc2019.Aoc201903;

public static class CommandFactory
{
    public static Command Create(string command)
    {
        var direction = command[0];
        var distance = GetDistance(command);
        if (direction == 'U')
            return new UpCommand(distance);
        if (direction == 'R')
            return new RightCommand(distance);
        if (direction == 'D')
            return new DownCommand(distance);
        if (direction == 'L')
            return new LeftCommand(distance);
        throw new UnknownDirectionException(direction);
    }

    private static int GetDistance(string command)
    {
        var distance = command.Substring(1);
        return int.Parse(distance);
    }
}