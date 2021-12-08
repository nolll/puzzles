using System;
using System.Collections.Generic;

namespace App.Puzzles.Year2018.Day02
{
    public class WrongNumberOfSimilarIdsException : Exception
    {
        public WrongNumberOfSimilarIdsException(IList<string> ids) 
            : base($"Wrong number of similar ids. Should be two, was {ids.Count}.")
        {
        }
    }
}