using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.Firewall
{
    public class PackerScanner
    {
        private readonly IList<FirewallLayer> _layers;
        public int Severity { get; }

        public PackerScanner(string input)
        {
            _layers = ParseLayers(input);

            Severity = SendPacket();
        }

        private int SendPacket()
        {
            var totalSeverity = 0;
            for (var i = 0; i < _layers.Count; i++)
            {
                var layer = _layers[i];
                totalSeverity += layer.IsCaught
                    ? i * layer.Depth
                    : 0;
                foreach (var l in _layers)
                {
                    l.Move();
                }
            }

            return totalSeverity;
        }

        private IList<FirewallLayer> ParseLayers(string input)
        {
            var dictionary = new Dictionary<int, FirewallLayer>();
            var rows = PuzzleInputReader.Read(input);
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