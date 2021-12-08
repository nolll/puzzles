using System;

namespace App.Puzzles.Year2020.Day20
{
    public static class StringHelper
    {
        public static string Reverse(this string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}