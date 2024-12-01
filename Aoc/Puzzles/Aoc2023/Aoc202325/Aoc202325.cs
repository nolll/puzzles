using System.Reflection.PortableExecutable;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202325;

[Name("Snowverload")]
public class Aoc202325() : AocPuzzle
{
    public static int DivideIntoGroups(string s)
    {
        var components = ParseComponents(s);

        return 0;
    }

    private static Dictionary<string, Component> ParseComponents(string s)
    {
        var lines = StringReader.ReadLines(s);
        var components = new Dictionary<string, Component>();

        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            var compName = parts[0];
            if (!components.TryGetValue(compName, out var mainComp))
            {
                mainComp = new Component(parts[0]);
                components.Add(compName, mainComp);
            }

            var connectedNames = parts[1].Split(' ');
            foreach (var connectedName in connectedNames)
            {
                if (!components.TryGetValue(connectedName, out var connectedComp))
                {
                    connectedComp = new Component(connectedName);
                    components.Add(connectedName, connectedComp);
                }

                connectedComp.Connections.Add(mainComp);
                mainComp.Connections.Add(connectedComp);
            }
        }

        return components;
    }

    private class Component
    {
        public string Name { get; }
        public List<Component> Connections { get; } = new();

        public Component(string name)
        {
            Name = name;
        }
    }
}