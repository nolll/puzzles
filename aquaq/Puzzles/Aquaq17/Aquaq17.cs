using Puzzles.common.Puzzles;

namespace Puzzles.aquaq.Puzzles.Aquaq17;

public class Aquaq17 : AquaqPuzzle
{
    public override string Name => "The Beautiful Shame";

    protected override PuzzleResult Run()
    {
        return new PuzzleResult(Run(InputFile), "033640f1946bb06d49b637ee7b1c3a80");
    }

    public static string Run(string input)
    {
        var lines = input.Split(Environment.NewLine).Skip(1);

        var scoreList = new List<TeamScore>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            var date = DateTime.Parse(parts[0]);
            var team1 = parts[1];
            var team2 = parts[2];
            var result1 = int.Parse(parts[3]);
            var result2 = int.Parse(parts[4]);

            scoreList.Add(new TeamScore(date, team1, result1));
            scoreList.Add(new TeamScore(date, team2, result2));
        }

        var teamScores = scoreList.GroupBy(o => o.Team).ToDictionary(k => k.Key, o => o.ToList());
        var longestShame = FindLongestShame(teamScores);
        
        const string dateFormat = "yyyyMMdd";
        var firstGoalDate = longestShame.From.ToString(dateFormat);
        var lastGoalDate = longestShame.To.ToString(dateFormat);

        return $"{longestShame.Team} {firstGoalDate} {lastGoalDate}";
    }

    private static TeamShame FindLongestShame(Dictionary<string, List<TeamScore>> teamScores)
    {
        var teamShames = teamScores.Select(o => FindLongestShame(o.Value));
        return teamShames.OrderByDescending(o => o.To - o.From).First();
    }

    private static TeamShame FindLongestShame(List<TeamScore> teamScores)
    {
        var isInStreak = false;
        var streakStartTime = DateTime.MinValue;
        var longestStreak = TimeSpan.Zero;
        var longestStreakDates = (DateTime.MinValue, DateTime.MinValue);

        foreach (var teamScore in teamScores)
        {
            if (isInStreak)
            {
                if (teamScore.Score == 0)
                    continue;

                isInStreak = false;
                var streak = teamScore.Date - streakStartTime;
                if (streak > longestStreak)
                {
                    longestStreak = streak;
                    longestStreakDates = (streakStartTime, teamScore.Date);
                }
            }

            if (!isInStreak && teamScore.Score == 0)
            {
                isInStreak = true;
                streakStartTime = teamScore.Date;
            }
        }

        return new TeamShame(teamScores.First().Team, longestStreakDates.Item1, longestStreakDates.Item2);
    }

    private record TeamScore(DateTime Date, string Team, int Score);
    private record TeamShame(string Team, DateTime From, DateTime To);
}