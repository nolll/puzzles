namespace Core.Firewall
{
    public class FirewallLayer
    {
        private const int DirectionPos = 1;
        private const int DirectionNeg = -1;

        private int _pos;
        private readonly int _maxPos;
        private int _direction = DirectionPos;
        private readonly int? _range;

        public int Depth { get; }
        public bool IsCaught => _range != null && _pos == 0;

        public FirewallLayer(int? range = null)
        {
            _pos = 0;
            _range = range;
            _maxPos = range - 1 ?? 0;
            Depth = range ?? 0;
        }

        public void Move()
        {
            if (_pos == _maxPos && _direction == DirectionPos || _pos == 0 && _direction == DirectionNeg)
                _direction = -_direction;
            _pos += _direction;
        }
    }
}