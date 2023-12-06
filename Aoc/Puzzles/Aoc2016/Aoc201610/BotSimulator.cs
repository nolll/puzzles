using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2016.Aoc201610;

public class BotSimulator
{
    private readonly Dictionary<int, Bot> _bots;
    private readonly Dictionary<int, int> _outputs;

    public BotSimulator(string input)
    {
        var instructions = StringReader.ReadLines(input);
        var valueInstructions = new List<string>();
        var passInstructions = new List<string>();
        _bots = new Dictionary<int, Bot>();
        _outputs = new Dictionary<int, int>();

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
            var bot = GetBot(id);
            bot.AddValue(v);
        }
        ;
        foreach (var instruction in passInstructions)
        {
            var parts = instruction.Split(' ');
            var id = int.Parse(parts[1]);
            var lowDestination = parts[5];
            var lowId = int.Parse(parts[6]);
            var highDestination = parts[10];
            var highId = int.Parse(parts[11]);
            var lowGiver = lowDestination == "bot"
                ? (IGiver)new BotGiver(_bots, lowId)
                : new OutputGiver(_outputs, lowId);
            var highGiver = highDestination == "bot"
                ? (IGiver)new BotGiver(_bots, highId)
                : new OutputGiver(_outputs, highId);
            var bot = GetBot(id);
            bot.LowGiver = lowGiver;
            bot.HighGiver = highGiver;
        }

        var values = _bots.Values.Where(o => o.IsReadyToGive).ToList();
        while (values.Any())
        {
            foreach (var bot in values)
            {
                bot.Give();
            }

            values = _bots.Values.Where(o => o.IsReadyToGive).ToList();
        }
    }

    private Bot GetBot(int id)
    {
        if (_bots.TryGetValue(id, out var bot))
            return bot;
        bot = new Bot(id);
        _bots.Add(id, bot);
        return bot;
    }
        
    public int FindIdByChips(int low, int high)
    {
        return _bots.Values.FirstOrDefault(o => o.Low == low && o.High == high)?.Id ?? 0;
    }

    public int GetMultipliedOutput()
    {
        return _outputs[0] * _outputs[1] * _outputs[2];
    }
}