using UnityEngine;

public class LogicalGrid : MonoBehaviour
{
    private int _width;
    private int _height;
    private float _tileSize;

    private Node[,] _grid;
    
    public void Init(IGridInfo gridInfo)
    {
        _width = gridInfo.Width;
        _height = gridInfo.Height;
        _tileSize = gridInfo.TileSize;

        _grid = new Node[_width, _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _grid[x, y] = new Node(x, y);
            }
        }
    }

    // Public Methods
    public Node GetGridNode(Vector2Int coordinates)
    {
        if (!ValidateGridPosition(coordinates))
        {
            Debug.LogError("OutOfGrid");
            return null;
        }

        return _grid[coordinates.x, coordinates.y];
    }

    public bool TryGetRandomEmptyNode(out Node node)
    {
        node = null;
        int EmptyCount = 0;

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                if (_grid[x, y].IsEmpty)
                {
                    Node currentNode = _grid[x, y];

                    EmptyCount++;

                    if (Random.Range(0, EmptyCount) == 0)
                    {
                        node = currentNode;
                    }
                }   
            }
        }

        return node != null;
    }

    // Private Methods
    private bool ValidateGridPosition(Vector2Int coordinates)
    {
        if (
            coordinates.x < 0 ||
            coordinates.x >= _width ||
            coordinates.y < 0 ||
            coordinates.y >= _height
            )
            return false;

        return true;
    }

}
