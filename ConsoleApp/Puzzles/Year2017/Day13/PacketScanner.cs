using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace ConsoleApp.Puzzles.Year2017.Day13
{
    public class PacketScanner
    {
        private IList<FirewallLayer> _layers;

        public PacketScanner(string input)
        {
            _layers = ParseLayers(input);
        }

        public int GetSeverity()
        {
            return SendPacket1();
        }

        public int DelayUntilPass()
        {
            var wasCaught = true;
            var delay = 0;
            while(wasCaught)
            {
                wasCaught = SendPacket2(delay);
                if(wasCaught)
                    delay += 1;
            };

            return delay;
        }

        private int SendPacket1()
        {
            var totalSeverity = 0;
            for (var i = 0; i < _layers.Count; i++)
            {
                var layer = _layers[i];
                totalSeverity += layer.IsCaught(i)
                    ? i * layer.Range
                    : 0;
            }

            return totalSeverity;
        }

        private bool SendPacket2(in int delay)
        {
            for (var i = 0; i < _layers.Count; i++)
            {
                var layer = _layers[i];
                if (layer.IsCaught(delay + i))
                    return true;
            }

            return false;
        }

        private IList<FirewallLayer> ParseLayers(string input)
        {
            var dictionary = new Dictionary<int, FirewallLayer>();
            var rows = PuzzleInputReader.ReadLines(input);
            foreach (var row in rows)
            {
                var parts = row.Split(": ");
                var index = int.Parse(parts[0]);
                var range = int.Parse(parts[1]);
                var layer = new FirewallLayer(range);
                dictionary.Add(index, layer);
            }

            var lastIndex = dictionary.Keys.Max();
            var layers = new List<FirewallLayer>();
            for (var i = 0; i <= lastIndex; i++)
            {
                if (dictionary.ContainsKey(i))
                {
                    layers.Add(dictionary[i]);
                }
                else
                {
                    layers.Add(new FirewallLayer());
                }
            }
            
            return layers;
        }
    }
}