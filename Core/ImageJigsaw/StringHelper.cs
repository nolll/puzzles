using System;

namespace Core.ImageJigsaw
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