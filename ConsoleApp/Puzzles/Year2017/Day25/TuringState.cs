namespace ConsoleApp.Puzzles.Year2017.Day25
{
    public class TuringState
    {
        public char State { get; }
        public int ValueIfZero { get; }
        public int DirectionIfZero { get; }
        public char NextStateIfZero { get; }
        public int ValueIfOne { get; }
        public int DirectionIfOne { get; }
        public char NextStateIfOne { get; }

        public TuringState(char state, int valueIfZero, int directionIfZero, char nextStateIfZero, int valueIfOne, int directionIfOne, char nextStateIfOne)
        {
            State = state;
            ValueIfZero = valueIfZero;
            DirectionIfZero = directionIfZero;
            NextStateIfZero = nextStateIfZero;
            ValueIfOne = valueIfOne;
            DirectionIfOne = directionIfOne;
            NextStateIfOne = nextStateIfOne;
        }
    }
}