using UnityEngine;

public class LogicalGrid : MonoBehaviour
{
    private int _width;
    private int _height;
    private float _tileSize = 1;

    private Node[,] _grid;
    
    public void Init(int width, int height, float tileSize)
    {
        _width = width;
        _height = height;
        _tileSize = tileSize;

        _grid = new Node[_width, _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _grid[x, y] = new Node(x, y);
            }
        }
    }

    public int Width { get { return _width; } }
    public int Height { get { return _height; } }
    public float TileSize { get { return _tileSize; } }

    // Public Methods
    public Node GetGridNode(Vector2Int coordinates)
    {
        if (!ValidateWorldPosition(coordinates)) throw new System.Exception("OutOfGrid");

        return _grid[coordinates.x, coordinates.y];
    }
    public Node GetGridNode(Vector3 worldPosition)
    {
        return GetGridNode(GridToWorldInteraction.WorldToGridPosition(this, worldPosition));
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
    private bool ValidateWorldPosition(Vector2Int coordinates)
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
