using System;

namespace App.Puzzles.Year2018.Day02
{
    public class StringsAreDifferentLengthsException : Exception
    {
        public StringsAreDifferentLengthsException(string str1, string str2) : base($"Strings {str1} and {str2} are different length.")
        {
        }
    }
}