using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.RecursiveCircus
{
    public class RecursiveTowers
    {
        public string BottomName { get; }

        public RecursiveTowers(string input)
        {
            var strings = PuzzleInputReader.Read(input);
            var discs = new Dictionary<string, Disc>();
            foreach (var strDisc in strings)
            {
                var a = strDisc.Split("->").Select(o => o.Trim()).ToList();
                var idAndWeight = a[0];
                var children = a.Count > 1 
                    ? a[1].Split(",").Select(o => o.Trim()).ToList()
                    : new List<string>();

                idAndWeight = idAndWeight.Replace("(", "").Replace(")", "");
                var b = idAndWeight.Split(' ');
                var id = b[0];
                var weight = int.Parse(b[1]);
                var disc = new Disc(id, weight, children);
                discs.Add(id, disc);
            }

            foreach (var key in discs.Keys)
            {
                var disc = discs[key];
                foreach (var childName in disc.ChildrenIds)
                {
                    var child = discs[childName];
                    child.ParentId = disc.Id;
                    disc.Children.Add(child);
                }
            }

            foreach (var key in discs.Keys)
            {
                if (discs[key].ParentId == null)
                {
                    BottomName = key;
                }
            }
        }
    }
}