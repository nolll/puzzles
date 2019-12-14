using System.Collections.Generic;

namespace Core.MakeFuel
{
    public class NanoReactor
    {
        private IList<Reaction> _reactions;

        public NanoReactor(string input)
        {
            _reactions = new ReactionParser().Parse(input);
        }
    }
}