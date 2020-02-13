using System.Collections.Generic;

namespace Core.AuntSue
{
    public class Sue
    {
        private readonly IDictionary<string, int> _properties;
        public int Number { get; }

        public Sue(int number)
        {
            Number = number;
            _properties = new Dictionary<string, int>();
        }

        public void Set(string name, int amount)
        {
            _properties.Add(name, amount);
        }

        public bool IsCorrectSue =>
            IsMatch("children", 3) &&
            IsMatch("cats", 7) &&
            IsMatch("samoyeds", 2) &&
            IsMatch("pomeranians", 3) &&
            IsMatch("akitas", 0) &&
            IsMatch("vizslas", 0) &&
            IsMatch("goldfish", 5) &&
            IsMatch("trees", 3) &&
            IsMatch("cars", 2) &&
            IsMatch("perfumes", 1);

        private bool IsMatch(string name, int amount)
        {
            var hasKey = _properties.ContainsKey(name);
            return !hasKey || _properties[name] == amount;
        }
    }
}