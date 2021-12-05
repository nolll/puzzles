namespace ConsoleApp.Years.Year2015.Puzzles.Day25
{
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
}