using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aquaq.Puzzles.Aquaq03;

public class Walker
{
    private readonly Grid<char> _grid;
    
    public Coord Pos => _grid.Coord;

    public Walker()
    {
        _grid = GridBuilder.BuildCharGridWithoutTrim(Room);
        _grid.MoveTo(2, 0);
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

        _grid.TryMoveForward();
        if (_grid.ReadValue() == ' ')
            _grid.MoveBackward();
    }

    private void Turn(char c)
    {
        var _ = c switch
        {
            'U' => _grid.TurnTo(GridDirection.Up),
            'R' => _grid.TurnTo(GridDirection.Right),
            'D' => _grid.TurnTo(GridDirection.Down),
            _ => _grid.TurnTo(GridDirection.Left)
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