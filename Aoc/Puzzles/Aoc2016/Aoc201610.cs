using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Balance Bots")]
public class Aoc201610 : AocPuzzle
{
    [Puzzle("5141409a7397bcdc4bb364bbb1ea2965")]
    public int Part1(string input) => FindIdByChips(input, 17, 61);

    [Puzzle("1e81841d2042e89e46105118a32aee33")]
    public int Part2(string input) => GetMultipliedOutput(input);

    public int FindIdByChips(string input, int low, int high)
    {
        var (bots, _) = Run(input);
        return bots.Values.FirstOrDefault(o => o.Low == low && o.High == high)?.Id ?? 0;
    }

    public int GetMultipliedOutput(string input)
    {
        var (_, outputs) = Run(input);
        return outputs[0] * outputs[1] * outputs[2];
    }

    private (Dictionary<int, Bot> bots, Dictionary<int, int> outputs) Run(string input)
    {
        var instructions = input.Split(LineBreaks.Single);
        var valueInstructions = new List<string>();
        var passInstructions = new List<string>();
        var bots = new Dictionary<int, Bot>();
        var outputs = new Dictionary<int, int>();

        foreach (var instruction in instructions)
        {
            if (instruction.StartsWith("value"))
                valueInstructions.Add(instruction);
            else
                passInstructions.Add(instruction);
        }

        foreach (var instruction in valueInstructions)
        {
            var parts = instruction.Split(' ');
            var v = int.Parse(parts[1]);
            var id = int.Parse(parts[5]);
            var bot = GetBot(bots, id);
            bot.AddValue(v);
        }

        foreach (var instruction in passInstructions)
        {
            var parts = instruction.Split(' ');
            var id = int.Parse(parts[1]);
            var lowDestination = parts[5];
            var lowId = int.Parse(parts[6]);
            var highDestination = parts[10];
            var highId = int.Parse(parts[11]);
            IGiver lowGiver = lowDestination == "bot"
                ? new BotGiver(bots, lowId)
                : new OutputGiver(outputs, lowId);
            IGiver highGiver = highDestination == "bot"
                ? new BotGiver(bots, highId)
                : new OutputGiver(outputs, highId);
            var bot = GetBot(bots, id);
            bot.LowGiver = lowGiver;
            bot.HighGiver = highGiver;
        }

        var values = bots.Values.Where(o => o.IsReadyToGive).ToList();
        while (values.Count > 0)
        {
            foreach (var bot in values)
            {
                bot.Give();
            }

            values = [.. bots.Values.Where(o => o.IsReadyToGive)];
        }

        return (bots, outputs);
    }

    private Bot GetBot(Dictionary<int, Bot> bots, int id)
    {
        if (bots.TryGetValue(id, out var bot))
            return bot;
        bot = new Bot(id);
        bots.Add(id, bot);
        return bot;
    }

    private class Bot(int id)
    {
        public int Id { get; } = id;
        public IGiver? LowGiver { get; set; }
        public IGiver? HighGiver { get; set; }
        private readonly IList<int> _values = [];
        public int Low { get; private set; }
        public int High { get; private set; }

        public bool IsReadyToGive => _values.Count == 2;

        public void Give()
        {
            Low = _values.Min();
            LowGiver?.Give(Low);
            High = _values.Max();
            HighGiver?.Give(High);
            _values.Clear();
        }

        public void AddValue(int v) => _values.Add(v);
    }

    private interface IGiver
    {
        void Give(int v);
    }

    private class BotGiver(Dictionary<int, Bot> bots, int id) : IGiver
    {
        public void Give(int v) => bots[id].AddValue(v);
    }

    private class OutputGiver(Dictionary<int, int> outputs, int id) : IGiver
    {
        public void Give(int v) => outputs[id] = v;
    }
}