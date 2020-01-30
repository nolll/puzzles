namespace Core.Firewall
{
    public class FirewallLayer
    {
        private const int DirectionPos = 1;
        private const int DirectionNeg = -1;

        public int Pos { get; private set; }
        private readonly int _maxPos;
        private int _direction = DirectionPos;
        private readonly int _range;

        public int Depth { get; }
        public bool IsCaught => HasGuard && Pos == 0;
        public bool HasGuard { get; }

        public FirewallLayer(int range = 0)
        {
            Pos = 0;
            if (range < 2)
            {
                HasGuard = false;
                _range = 0;
                _maxPos = 0;
                Depth = 0;
            }
            else
            {
                HasGuard = true;
                _range = range;
                _maxPos = range - 1;
                Depth = range;
            }
        }

        public int GetPos(in int iteration)
        {
            if (iteration == 0)
                return 0;
            if (iteration <= _maxPos)
                return iteration;

            return iteration % ((_range - 1) * 2);
        }

        public void Move()
        {
            if (_maxPos <= 0)
                return;
            
            if (Pos == _maxPos && _direction == DirectionPos || Pos == 0 && _direction == DirectionNeg)
                _direction = -_direction;
            Pos += _direction;
        }
    }
}