using System.Collections.Generic;
using UnityEngine;

public class LogicalGrid : MonoBehaviour
{
    private int _width;
    private int _height;
    private float _tileSize;

    private Node[,] _grid;

    private Dictionary<GameObject, Vector2Int> _nodeObjectsCoordinates;
    
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

        _nodeObjectsCoordinates = new Dictionary<GameObject, Vector2Int>();
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

    public bool TrySetObjectInNode(Node node, GameObject go)
    {
        if (!node.IsEmpty)
        {
            Debug.LogError("Node already occupied");
            return false;
        }

        node.Object = go;
        Vector2Int coordinates = new Vector2Int(node.X, node.Y);

        if (_nodeObjectsCoordinates.ContainsKey(go)) // це думаю може потім винесу в окремий метод AddObject який вже буде забороняти вставлення дублікатів а не просто ігнорувати
        { 
            _nodeObjectsCoordinates[go] = coordinates;
        }
        else 
        {
            _nodeObjectsCoordinates.Add(go, coordinates);
        }

        return true;
    }

    public Vector2Int GetObjectCoordinates(GameObject go)
    {
        Vector2Int coordinates;
        _nodeObjectsCoordinates.TryGetValue(go, out coordinates);

        return coordinates;
    }

    public void RemoveObjectFromGrid(GameObject go)
    {
        _nodeObjectsCoordinates.Remove(go);
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
