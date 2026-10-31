using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Rankening")]
public class Ece202604 : EverybodyEventPuzzle
{
    [Puzzle("5cba4da390def1689ad3d5ff54693631")]
    public int Part1(string input) => GetResultsPart1And2(input)
        .OrderBy(o => o.Time)
        .Select((o, i) => (i + 1) * o.Time)
        .Sum();

    [Puzzle("efe20da86e661914acf4ae30036a77d4")]
    public int Part2(string input) => GetResultsPart1And2(input)
        .OrderByDescending(o => o.Parts)
        .ThenBy(o => o.Time)
        .Select((o, i) => (i + 1) * o.Time)
        .Sum();

    [Puzzle("2deacf77d7714de06066120720a42ff5")]
    public long Part3(string input) => GetCheckSumPart3(GetResultsPart3(input));

    private static long GetCheckSumPart3(IEnumerable<long> playerScores)
    {
        var sum = 0L;
        var lastScore = 0L;
        var count = 0L;
        var lastPos = 1L;
        foreach (var playerScore in playerScores)
        {
            var pos = count + 1;
            if (playerScore == lastScore)
                pos = lastPos;
            sum += pos * playerScore;
            lastScore = playerScore;
            lastPos = pos;
            count++;
        }
        
        return sum;
    }
    
    private List<Part1And2PlayerResult> GetResultsPart1And2(string input)
    {
        var lines = input.Split(LineBreaks.Single).Select(ResultLine.Parse);
        var dictionary = new Dictionary<int, Part1And2PlayerResult>();
        foreach (var result in lines)
        {
            if (!dictionary.ContainsKey(result.PlayerId)) 
                dictionary.Add(result.PlayerId, new Part1And2PlayerResult());
            
            dictionary[result.PlayerId].Parts += 1;
            dictionary[result.PlayerId].Time += result.Time;
        }

        return [.. dictionary.Values];
    }
    
    private IOrderedEnumerable<long> GetResultsPart3(string input)
    {
        var lines = input.Split(LineBreaks.Single).Select(ResultLine.Parse);
        var playerScores = new Dictionary<int, long>();
        var quests = lines.GroupBy(o => o.QuestId).OrderBy(o => o.Key);

        foreach (var quest in quests)
        {
            var startScore = 50;
            for (var i = 1; i <= 3; i++)
            {
                var partId = i;
                var playerTimes = GetPlayerTimesForPart(quest.Where(o => o.PartId <= partId), partId);
                var lastPlayerTime = 0;
                var lastPlayerScore = startScore;
                var playerCount = 0;
                foreach (var playerTime in playerTimes)
                {
                    var score = startScore - playerCount;
                    if (playerTime.Time == lastPlayerTime)
                        score = lastPlayerScore;
                    lastPlayerScore = score;
                    
                    playerScores.TryAdd(playerTime.PlayerId, 0);
                    if(score > 0)
                        playerScores[playerTime.PlayerId] += score;
                    playerCount++;
                    lastPlayerTime = playerTime.Time;
                }
                
                startScore += 50;
            }
        }

        return playerScores.Values.OrderDescending();
    }

    private List<Part3PlayerResult> GetPlayerTimesForPart(IEnumerable<ResultLine> lines, int partId)
    {
        var playerGroups = lines.GroupBy(o => o.PlayerId);
        var d = new Dictionary<int, Part3PlayerResult>();

        foreach (var playerGroup in playerGroups.Where(o => o.Count() == partId).ToList())
        {
            foreach (var result in playerGroup)
            {
                if(!d.ContainsKey(result.PlayerId))
                    d.Add(result.PlayerId, new Part3PlayerResult{ PlayerId = result.PlayerId });
                d[result.PlayerId].Time += result.Time;
            }
        }

        return [.. d.Values.OrderBy(o => o.Time)];
    }

    private class Part1And2PlayerResult
    {
        public int Parts { get; set; }
        public int Time { get; set; }
    }

    private record ResultLine(int PlayerId, int QuestId, int PartId, int Time)
    {
        public static ResultLine Parse(string line)
        {
            var (id, quest, part, time) = Numbers.IntsFromString(line);
            return new ResultLine(id, quest, part, time);
        }
    }

    private class Part3PlayerResult
    {
        public int PlayerId { get; init; }
        public int Time { get; set; }
    }
}