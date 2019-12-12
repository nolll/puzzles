using System;
using System.Collections.Generic;

namespace Core.Boxes
{
    public class WrongNumberOfSimilarIdsException : Exception
    {
        public WrongNumberOfSimilarIdsException(List<string> ids) : base($"Wrong number of similar ids. Should be two, was {ids.Count}.")
        {
        }
    }
}