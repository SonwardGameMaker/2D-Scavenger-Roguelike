using UnityEngine;

public interface IGridInfo
{
    public int Width { get; }
    public int Height { get; }
    public float TileSize { get ; }

    public Vector3 GridPosition { get; }
}
