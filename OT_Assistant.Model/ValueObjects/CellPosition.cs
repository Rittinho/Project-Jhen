namespace OT_Assistant.Model.ValueObjects;
public class CellPosition
{
    private readonly int[] _position;
    private readonly int[] _row;
    public CellPosition(int[] position, int[] row) => (_position, _row) = (position, row);
    public int[] GetPosition() => _position;
    public int[] GetRow() => _row;
}