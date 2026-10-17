using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Rambunctious Recitation")]
public class Aoc202015 : AocPuzzle
{
    [Puzzle("9b1872aba49cfd16a3cc25436caa89e4")]
    public long Part1(string input) => Solve(input, 2020);

    [Puzzle("7bcf2e0ed295f1de70b3d5368e465107")]
    public long Part2(string input) => Solve(input, 30000000);
    
    private static long Solve(string input, int until)
    {
        var inputNumbers = input.Split(',').Select(long.Parse).ToList();
        var numbers = new Dictionary<long, GameNumber>();

        var turn = 0;
        GameNumber? lastSpokenNumber = null;
        foreach (var num in inputNumbers)
        {
            lastSpokenNumber = Speak(numbers, num, turn);
            turn++;
        }

        while (turn < until)
        {
            var numberToSpeak = lastSpokenNumber!.SpeakCount == 1
                ? 0
                : lastSpokenNumber.Age;
            lastSpokenNumber = Speak(numbers, numberToSpeak, turn);
            turn++;
        }

        return lastSpokenNumber!.Num;
    }

    private static GameNumber Speak(Dictionary<long, GameNumber> numbers, long num, int turn)
    {
        if (!numbers.TryGetValue(num, out var gameNum))
        {
            gameNum = new GameNumber(num);
            numbers.Add(num, gameNum);
        }

        gameNum.Speak(turn);
        return gameNum;
    }

    private class GameNumber(long num)
    {
        private long _prevSpoken;
        private long _lastSpoken;

        public long Num { get; } = num;
        public long SpeakCount { get; private set; }

        public long Age => _lastSpoken - _prevSpoken;

        public void Speak(int time)
        {
            _prevSpoken = _lastSpoken;
            _lastSpoken = time;
            SpeakCount++;
        }
    }
}