using System.Collections.Generic;
using System.Linq;

namespace Core.MoonTracking
{
    public class MoonTracker
    {
        private int _iterations = 0;
        private int? _maxIterations;

        public IList<Moon> Moons { get; }

        public MoonTracker(string map)
        {
            Moons = ReadMap(map);
        }

        private IList<Moon> ReadMap(string map)
        {
            var rows = map.Trim().Split('\n');
            var moons = new List<Moon>();
            foreach (var row in rows)
            {
                var items = row.Trim().TrimStart('<').TrimEnd('>').Replace(" ", "").Split(',');
                var coords = items.Select(o => int.Parse((string) o.Split('=')[1])).ToArray();
                var moon = new Moon(coords[0], coords[1], coords[2]);
                moons.Add(moon);
            }
            return moons;
        }

        public void Run(int i)
        {
            _maxIterations = i;
            Run();
        }

        private void Run()
        {
            while (_maxIterations == null || _iterations < _maxIterations)
            {
                _iterations++;
            }
        }
    }
}