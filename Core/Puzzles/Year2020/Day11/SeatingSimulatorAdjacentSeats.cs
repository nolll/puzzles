using System.Collections.Generic;

namespace Core.Puzzles.Year2020.Day11
{
    public class SeatingSimulatorAdjacentSeats : SeatingSimulator
    {
        public SeatingSimulatorAdjacentSeats(string input) : base(input)
        {

        }

        protected override IList<char> GetAdjacentSeats()
        {
            return Matrix.AllAdjacentValues;
        }

        protected override char GetSeatStatus(char currentValue, int neighborCount)
        {
            if (currentValue == EmptyChair && neighborCount == 0)
                return OccupiedChair;

            if (currentValue == OccupiedChair && neighborCount >= 4)
                return EmptyChair;

            return currentValue;
        }
    }
}