using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aquaq.Puzzles.Aquaq03;

public class Walker
{
    private readonly Matrix<char> _matrix;
    
    public Coord Pos => _matrix.Address;

    public Walker()
    {
        _matrix = MatrixBuilder.BuildCharMatrixWithoutTrim(Room);
        _matrix.MoveTo(2, 0);
    }

    public int Walk(string input)
    {
        var sum = 0;

        foreach (var c in input)
        {
            Move(c);
            sum += Pos.X + Pos.Y;
        }

        return sum;
    }

    private void Move(char c)
    {
        Turn(c);

        _matrix.TryMoveForward();
        if (_matrix.ReadValue() == ' ')
            _matrix.MoveBackward();
    }

    private void Turn(char c)
    {
        var _ = c switch
        {
            'U' => _matrix.TurnTo(MatrixDirection.Up),
            'R' => _matrix.TurnTo(MatrixDirection.Right),
            'D' => _matrix.TurnTo(MatrixDirection.Down),
            _ => _matrix.TurnTo(MatrixDirection.Left)
        };
    }

    private const string Room = """"
  ##  
 #### 
######
######
 #### 
  ##  
"""";
}