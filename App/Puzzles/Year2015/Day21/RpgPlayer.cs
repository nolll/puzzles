using System.Collections.Generic;
using System.Linq;

namespace App.Puzzles.Year2015.Day21
{
    public class RpgPlayer : RpgCharacter
    {
        public RpgPlayer(in int points, in int damage, in int armor)
            : base("player", in points, in damage, in armor)
        {
        }

        public RpgPlayer(in int points, IList<RpgProperty> properties)
            : base("player", in points, properties.Sum(o => o.Damage), properties.Sum(o => o.Armor))
        {
        }
    }
}