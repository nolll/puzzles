using System.Linq;
using Core.Tools;

namespace Core.PresentDelivery
{
    public class DeliveryGrid
    {
        private readonly Matrix<int> _matrix;
        public int DeliveryCount => _matrix.Values.Count(o => o > 0);

        public DeliveryGrid()
        {
            _matrix = new Matrix<int>();
        }

        public void Deliver(string input)
        {
            var directions = input.ToCharArray();
            _matrix.WriteValue(1);
            foreach (var direction in directions)
            {
                Move(direction);
                var oldVal = _matrix.ReadValue();
                _matrix.WriteValue(oldVal + 1);
            }
        }

        private void Move(char direction)
        {
            if (direction == '^')
                _matrix.MoveUp();
            if (direction == '>')
                _matrix.MoveRight();
            if (direction == 'v')
                _matrix.MoveDown();
            if (direction == '<')
                _matrix.MoveLeft();
        }
    }
}