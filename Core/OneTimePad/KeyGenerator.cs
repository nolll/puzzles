using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Tools;

namespace Core.OneTimePad
{
    public class KeyGenerator
    {
        private readonly Hashfactory _hashFactory;
        private readonly string _salt;
        private readonly bool _useStretching;
        private readonly IDictionary<int, string> _hashes;

        public int IndexOf64thKey { get; }

        public KeyGenerator(string salt, bool useStretching = false)
        {
            _hashFactory = new Hashfactory();
            _salt = salt;
            _useStretching = useStretching;
            _hashes = new Dictionary<int, string>();
            var keys = new List<string>();

            var index = 0;
            while (keys.Count < 64)
            {
                var hash = GetHash(index);
                var isKey = IsKey(index, hash);
                if (isKey)
                    keys.Add(hash);
                    
                index++;
            }

            IndexOf64thKey = index - 1;
        }

        private bool IsKey(in int index, string hash)
        {
            var repeatingChar = GetRepeatingChar(hash);
            if (repeatingChar != null)
            {
                if (Next1000HashesHasFiveInARowOf(index + 1, repeatingChar.Value))
                {
                    return true;
                }
            }

            return false;
        }

        private char? GetRepeatingChar(string hash)
        {
            var regex = new Regex("(.)\\1{2,}");
            var match = regex.Match(hash);
            if (match.Success)
            {
                return match.Value.First();
            }

            return null;
        }

        private bool Next1000HashesHasFiveInARowOf(in int fromIndex, char searchFor)
        {
            var count = 0;
            var stringToSearchFor = new string(searchFor, 5);
            while (count < 1000)
            {
                var index = fromIndex + count;
                var hash = GetHash(index);
                if (hash.Contains(stringToSearchFor))
                    return true;
                count++;
            }

            return false;
        }

        private string GetHash(int index)
        {
            if (_hashes.TryGetValue(index, out var hash))
                return hash;
            hash = CreateHash(index);
            _hashes.Add(index, hash);
            return hash;
        }

        private string CreateHash(int index)
        {
            var str = string.Concat(_salt, index.ToString());
            return _useStretching
                ? CreateStretchedHash(str)
                : CreateSimpleHash(str);
        }

        private string CreateSimpleHash(string str)
        {
            return _hashFactory.Create(str);
        }

        private string CreateStretchedHash(string str)
        {
            var count = 0;
            while (count <= 2016)
            {
                str = CreateSimpleHash(str);
                count++;
            }

            return str;
        }
    }
}