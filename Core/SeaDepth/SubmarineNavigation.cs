using Core.Tools;

namespace Core.SeaDepth
{
    public class SubmarineNavigation
    {
        private readonly bool _useAim;

        public SubmarineNavigation(bool useAim)
        {
            _useAim = useAim;
        }

        public long Move(string input)
        {
            var lines = PuzzleInputReader.ReadLines(input);

            long x = 0;
            long y = 0;
            long aim = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                var action = parts[0];
                var value = long.Parse(parts[1]);

                if (!_useAim)
                {
                    if (action == "forward")
                        x += value;

                    if (action == "down")
                        y += value;

                    if (action == "up")
                        y -= value;
                }
                else
                {
                    if (action == "forward")
                    {
                        x += value;
                        y += aim * value;
                    }

                    if (action == "down")
                        aim += value;

                    if (action == "up")
                        aim -= value;
                }
                
                
            }

            return x * y;
        }
    }
}