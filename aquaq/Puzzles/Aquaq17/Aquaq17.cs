using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq17;

public class Aquaq17 : AquaqPuzzle
{
    public override string Name => "The Beautiful Shame";

    protected override PuzzleResult Run()
    {
        return new PuzzleResult(Run(InputFile));
    }

    public static string Run(string input)
    {
        var firstZero = new Dictionary<string, DateTime>();
        var lastGoal = new Dictionary<string, DateTime>();
        var lines = input.Split(Environment.NewLine).Skip(1);

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            var date = DateTime.Parse(parts[0]);
            var team1 = parts[1];
            var team2 = parts[2];
            var result1 = int.Parse(parts[3]);
            var result2 = int.Parse(parts[4]);

            if (!firstZero.ContainsKey(team1) && result1 == 0)
            {
                firstZero.Add(team1, date);
            }

            if (!firstZero.ContainsKey(team2) && result2 > 0)
            {
                firstZero.Add(team2, date);
            }

            if(result1 > 0)
                lastGoal[team1] = date;

            if (result2 > 0)
                lastGoal[team2] = date;
        }

        var teams = firstZero.Keys.Where(o => lastGoal.ContainsKey(o));
        var maxTimespan = TimeSpan.Zero;
        var maxTeam = "";

        foreach (var team in teams)
        {
            var dateDiff = lastGoal[team] - firstZero[team];
            if (dateDiff > maxTimespan)
            {
                maxTimespan = dateDiff;
                maxTeam = team;
            }
        }

        var dateFormat = "yyyyMMdd";
        var firstGoalDate = firstZero[maxTeam].ToString(dateFormat);
        var lastGoalDate = lastGoal[maxTeam].ToString(dateFormat);

        return $"{maxTeam} {firstGoalDate} {lastGoalDate}";
    }
}