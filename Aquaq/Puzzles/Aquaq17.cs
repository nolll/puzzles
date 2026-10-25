using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("The Beautiful Shame")]
public class Aquaq17 : AquaqPuzzle
{
    [Puzzle("033640f1946bb06d49b637ee7b1c3a80")]
    public string Solve(string input)
    {
        var lines = input.Split(LineBreaks.Single).Skip(1);

        var scoreList = new List<TeamScore>();

        foreach (var line in lines)
        {
            var (dateString, team1, team2, result1, result2) = line.Split(',');
            var date = DateTime.Parse(dateString);
            scoreList.Add(new TeamScore(date, team1, int.Parse(result1)));
            scoreList.Add(new TeamScore(date, team2, int.Parse(result2)));
        }

        var teamScores = scoreList.GroupBy(o => o.Team).ToDictionary(k => k.Key, o => o.ToList());
        var longestShame = FindLongestShame(teamScores);
        
        const string dateFormat = "yyyyMMdd";
        var firstGoalDate = longestShame.From.ToString(dateFormat);
        var lastGoalDate = longestShame.To.ToString(dateFormat);

        return $"{longestShame.Team} {firstGoalDate} {lastGoalDate}";
    }

    private static TeamShame FindLongestShame(Dictionary<string, List<TeamScore>> teamScores) => 
        teamScores.Select(o => FindLongestShame(o.Value)).OrderByDescending(o => o.To - o.From).First();

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

            if (isInStreak || teamScore.Score != 0)
                continue;
            
            isInStreak = true;
            streakStartTime = teamScore.Date;
        }

        return new TeamShame(teamScores.First().Team, longestStreakDates.Item1, longestStreakDates.Item2);
    }

    private record TeamScore(DateTime Date, string Team, int Score);
    private record TeamShame(string Team, DateTime From, DateTime To);
}