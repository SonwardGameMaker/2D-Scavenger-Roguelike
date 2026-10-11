using System.Collections.Generic;
using UnityEngine;

public class LogicalGrid : MonoBehaviour
{
    private int _width;
    private int _height;
    private float _tileSize;

    private Node[,] _grid;

    private Dictionary<IGridEntity, Vector2Int> _nodeObjectsCoordinates;
    
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

        _nodeObjectsCoordinates = new Dictionary<IGridEntity, Vector2Int>();
    }

    // Public Methods
    public Node GetGridNode(Vector2Int coordinates)
    {
        if (!ValidateGridPosition(coordinates))
        {
            // Debug.LogError("OutOfGrid");
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

    public bool TrySetObjectInNode(Node node, IGridEntity gridEntity)
    {
        if (!node.IsEmpty)
        {
            // Debug.Log("Node already occupied");
            return false;
        }

        node.Object = gridEntity;
        Vector2Int coordinates = new Vector2Int(node.X, node.Y);

        if (_nodeObjectsCoordinates.ContainsKey(gridEntity)) // це думаю може потім винесу в окремий метод AddObject який вже буде забороняти вставлення дублікатів а не просто ігнорувати
        { 
            _nodeObjectsCoordinates[gridEntity] = coordinates;
        }
        else 
        {
            _nodeObjectsCoordinates.Add(gridEntity, coordinates);
        }

        return true;
    }

    public Vector2Int GetObjectCoordinates(IGridEntity gridEntity)
    {
        Vector2Int coordinates;
        _nodeObjectsCoordinates.TryGetValue(gridEntity, out coordinates);

        return coordinates;
    }

    public void RemoveObjectFromGrid(IGridEntity gridEntity)
    {
        _nodeObjectsCoordinates.Remove(gridEntity);
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
