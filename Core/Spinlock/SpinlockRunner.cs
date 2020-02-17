using System.Collections.Generic;
using Core.Tools;

namespace Core.Spinlock
{
    public class SpinlockRunner
    {
        private readonly int _steps;
        private readonly LinkedList<int> _list;
        private LinkedListNode<int> _current;

        public int NextValue => _current.Next?.Value ?? 0;

        public SpinlockRunner(int steps)
        {
            _steps = steps;
            _list = new LinkedList<int>();
            _current = _list.AddLast(0);
        }

        public void Run(int target)
        {
            var v = 1;
            while (v <= target)
            {
                for (var i = 0; i < _steps; i++)
                {
                    _current = _current.NextOrFirst();
                }
                _current = _list.AddAfter(_current, v);
                v++;
            }
        }
    }
}