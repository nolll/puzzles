namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201525;

public class WeatherMachineCodeFinder
{
    public long FindCodeAt(int targetX, int targetY)
    {
        long code = 20151125;
        var index = 2;

        while (true)
        {
            for (var x = 1; x <= index; x++)
            {
                var y = index - x + 1;
                code = code * 252533 % 33554393;
                if (x == targetX && y == targetY)
                    return code;
            }
            index++;
        }
    }
}