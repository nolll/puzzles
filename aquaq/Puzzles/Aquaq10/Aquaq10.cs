using System.Collections;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq10;

public class Aquaq10 : AquaqPuzzle
{
    public override string Name => "Troll Toll";

    protected override PuzzleResult Run()
    {
        var result = Run(InputFile, "TUPAC", "DIDDY");

        return new PuzzleResult(result, 596);
    }

    public static int Run(string input, string source, string target)
    {
        var lines = input.Split(Environment.NewLine)
            .Skip(1);

        var people = new Dictionary<string, User>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            var from = parts[0];
            var to = parts[1];
            var cost = int.Parse(parts[2]);
            if (!people.TryGetValue(from, out var user))
            {
                user = new User(from);
                people.Add(from, user);
            }

            if(to != source)
                user.Connections.Add(new UserConnection(to, cost));
        }

        var start = people[source];
        var visited = people.Keys.ToDictionary(k => k, _ => int.MaxValue);
        visited[source] = 0;
        var queue = new Queue<User>(new List<User> { start });

        while (queue.Any())
        {
            var current = queue.Dequeue();
            var currentSteps = visited[current.Name];
            foreach (var connection in current.Connections)
            {
                var visitedConnection = visited[connection.Name];
                if (currentSteps + connection.Cost < visitedConnection)
                {
                    visited[connection.Name] = currentSteps + connection.Cost;
                    queue.Enqueue(people[connection.Name]);
                }
            }
        }

        return visited[target];
    }

    private class User
    {
        public string Name { get; }
        public List<UserConnection> Connections { get; } = new();

        public User(string name)
        {
            Name = name;
        }
    }

    private class UserConnection
    {
        public string Name { get; }
        public int Cost { get; }

        public UserConnection(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}