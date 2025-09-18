/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    private void ValidateAndMove(int dx, int dy, int directionIndex)
    {
        var pos = (_currX, _currY);
        var moves = _mazeMap[pos];

        // Check if direction is blocked
        if (!moves[directionIndex])
            throw new InvalidOperationException("Can't go that way!");

        var newPos = (_currX + dx, _currY + dy);

        // Check if the new cell exists in the maze
        if (!_mazeMap.ContainsKey(newPos))
            throw new InvalidOperationException("Can't go that way!");

        // Update position
        _currX += dx;
        _currY += dy;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()  => ValidateAndMove(-1, 0, 0);

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight() => ValidateAndMove(1, 0, 1);

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()    => ValidateAndMove(0, -1, 2);

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()  => ValidateAndMove(0, 1, 3);

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}