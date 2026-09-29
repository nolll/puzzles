using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Universal Orbit Map")]
public class Aoc201906 : AocPuzzle
{
    [Puzzle("47b7e7a9aac22c8d0dc3f8a1f510498a")]
    public int Part1(string input) => new OrbitCalculator(input).GetOrbitCount();

    [Puzzle("b69467aeda98c0291c1767a24409e868")]
    public int Part2(string input) => new OrbitCalculator(input).GetSantaDistance();
    
    public class OrbitCalculator
    {
        Dictionary<string, Body> d = new();

        public OrbitCalculator(string input)
        {
            var items = input.Trim().Split(LineBreaks.Single).Select(o => o.Trim());
            foreach (var item in items)
            {
                var parts = item.Split(')');
                var parentName = parts[0];
                var childName = parts[1];

                if (!d.TryGetValue(parentName, out var parent))
                {
                    parent = new Body(parentName);
                    d.Add(parentName, parent);
                }

                if (!d.TryGetValue(childName, out var child))
                {
                    child = new Body(childName);
                    d.Add(childName, child);
                }

                if (child.Parent == null)
                {
                    child.Parent = parent;
                }
            }
        }

        public int GetOrbitCount()
        {
            return d.Values.Sum(o => o.OrbitCount);
        }

        public int GetSantaDistance()
        {
            var youPath = d["YOU"].ParentPath;
            var santaPath = d["SAN"].ParentPath;

            var allNames = $"{youPath}|{santaPath}".Split('|').ToList();
            var uniqueSingles = new List<string>();
            foreach (var name in allNames)
            {
                if(name == "SAN" || name == "YOU")
                    continue;

                if (allNames.Count(o => o == name) == 1)
                {
                    uniqueSingles.Add(name);
                }
            }
            return uniqueSingles.Count;
        }
    }
    
    public class Body
    {
        private readonly string _name;
        public Body? Parent { get; set; }

        public Body(string name)
        {
            _name = name;
        }

        public int OrbitCount
        {
            get
            {
                if (Parent == null)
                    return 0;
                return Parent.OrbitCount + 1;
            }
        }

        public string ParentPath
        {
            get
            {
                if (Parent == null)
                    return _name;

                return $"{Parent.ParentPath}|{_name}";
            }
        }
    }
}