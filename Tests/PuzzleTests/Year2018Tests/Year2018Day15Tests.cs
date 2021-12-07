using Core.Puzzles.Year2018.Day15;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2018Tests
{
    public class Year2018Day15Tests
    {
        [Test]
        public void BattleResultsInCorrectOutcome_Case1()
        {
            const string input = @"
#######
#.G...#
#...EG#
#.#.#G#
#..G#E#
#.....#
#######";

            var battle = new ChocolateBattle(input);
            battle.RunOnce(false);

            Assert.That(battle.Outcome, Is.EqualTo(27730));
        }

        [Test]
        public void BattleResultsInCorrectOutcome_Case2()
        {
            const string input = @"
#######
#G..#E#
#E#E.E#
#G.##.#
#...#E#
#...E.#
#######
";

            var battle = new ChocolateBattle(input);
            battle.RunOnce(false);

            Assert.That(battle.Outcome, Is.EqualTo(36334));
        }

        [Test]
        public void BattleResultsInCorrectOutcome_Case3()
        {
            const string input = @"
#######
#E..EG#
#.#G.E#
#E.##E#
#G..#.#
#..E#.#
#######
";

            var battle = new ChocolateBattle(input);
            battle.RunOnce(false);

            Assert.That(battle.Outcome, Is.EqualTo(39514));
        }

        [Test]
        public void BattleResultsInCorrectOutcome_Case4()
        {
            const string input = @"
#######
#E.G#.#
#.#G..#
#G.#.G#
#G..#.#
#...E.#
#######
";

            var battle = new ChocolateBattle(input);
            battle.RunOnce(false);

            Assert.That(battle.Outcome, Is.EqualTo(27755));
        }


        [Test]
        public void BattleResultsInCorrectOutcome_Case5()
        {
            const string input = @"
#######
#.E...#
#.#..G#
#.###.#
#E#G#G#
#...#G#
#######
";

            var battle = new ChocolateBattle(input);
            battle.RunOnce(false);

            Assert.That(battle.Outcome, Is.EqualTo(28944));
        }


        [Test]
        public void BattleResultsInCorrectOutcome_Case6()
        {
            const string input = @"
#########
#G......#
#.E.#...#
#..##..G#
#...##..#
#...#...#
#.G...G.#
#.....G.#
#########
";

            var battle = new ChocolateBattle(input);
            battle.RunOnce(false);

            Assert.That(battle.Outcome, Is.EqualTo(18740));
        }

        [Test]
        public void BattleResultsForElvesWinningWithoutLosses_Case1()
        {
            const string input = @"
#######
#.G...#
#...EG#
#.#.#G#
#..G#E#
#.....#
#######
";

            var battle = new ChocolateBattle(input);
            battle.RunUntilElvesWins(false);

            Assert.That(battle.Outcome, Is.EqualTo(4988));
        }

        [Test]
        public void BattleResultsForElvesWinningWithoutLosses_Case2()
        {
            const string input = @"
#######
#E..EG#
#.#G.E#
#E.##E#
#G..#.#
#..E#.#
#######
";

            var battle = new ChocolateBattle(input);
            battle.RunUntilElvesWins(false);

            Assert.That(battle.Outcome, Is.EqualTo(31284));
        }

        [Test]
        public void BattleResultsForElvesWinningWithoutLosses_Case3()
        {
            const string input = @"
#######
#E.G#.#
#.#G..#
#G.#.G#
#G..#.#
#...E.#
#######
";

            var battle = new ChocolateBattle(input);
            battle.RunUntilElvesWins(false);

            Assert.That(battle.Outcome, Is.EqualTo(3478));
        }

        [Test]
        public void BattleResultsForElvesWinningWithoutLosses_Case4()
        {
            const string input = @"
#######
#.E...#
#.#..G#
#.###.#
#E#G#G#
#...#G#
#######
";

            var battle = new ChocolateBattle(input);
            battle.RunUntilElvesWins(false);

            Assert.That(battle.Outcome, Is.EqualTo(6474));
        }

        [Test]
        public void BattleResultsForElvesWinningWithoutLosses_Case5()
        {
            const string input = @"
#########
#G......#
#.E.#...#
#..##..G#
#...##..#
#...#...#
#.G...G.#
#.....G.#
#########
";

            var battle = new ChocolateBattle(input);
            battle.RunUntilElvesWins(false);

            Assert.That(battle.Outcome, Is.EqualTo(1140));
        }
    }
}