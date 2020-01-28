using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.Firewall
{
    public class PacketScanner
    {
        private readonly string _input;

        public PacketScanner(string input)
        {
            _input = input;
        }

        public int GetSeverity()
        {
            var layers = ParseLayers(_input);
            return SendPacket1(layers);
        }

        private void MoveScanners(IList<FirewallLayer> layers)
        {
            foreach (var l in layers)
            {
                l.Move();
            }
        }

        public int DelayUntilPass()
        {
            var wasCaught = true;
            var delay = 0;
            while(wasCaught)
            {
                var layers = ParseLayers(_input);
                for (var i = 0; i < delay; i++)
                {
                    MoveScanners(layers);
                }
                wasCaught = SendPacket2(layers);
                if(wasCaught)
                    delay += 1;
                Console.WriteLine(delay);
            };

            return delay;
        }

        private int SendPacket1(IList<FirewallLayer> layers)
        {
            var totalSeverity = 0;
            for (var i = 0; i < layers.Count; i++)
            {
                var layer = layers[i];
                totalSeverity += layer.IsCaught
                    ? i * layer.Depth
                    : 0;
                MoveScanners(layers);
            }

            return totalSeverity;
        }

        private bool SendPacket2(IList<FirewallLayer> layers)
        {
            for (var i = 0; i < layers.Count; i++)
            {
                var layer = layers[i];
                if (layer.IsCaught)
                    return true;
                MoveScanners(layers);
            }

            return false;
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