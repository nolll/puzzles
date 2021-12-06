using System.Collections.Generic;

namespace Core.Puzzles.Year2016.Day10
{
    public class BotGiver : IGiver
    {
        private readonly Dictionary<int, Bot> _bots;
        private readonly int _id;

        public BotGiver(Dictionary<int, Bot> bots, int id)
        {
            _bots = bots;
            _id = id;
        }

        public void Give(int v)
        {
            _bots[_id].AddValue(v);
        }
    }
}