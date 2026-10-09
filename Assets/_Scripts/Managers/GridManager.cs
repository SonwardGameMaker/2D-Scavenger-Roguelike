using UnityEngine;

public class GridManager : MonoBehaviour, IGridInfo, IGridNodeInteractions
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private float _tileSize = 1;

    [SerializeField] private LogicalGrid _logicalGrid;
    [SerializeField] private VisualGrid _visualGrid;

    private IGridObjectMoving _gridObjectMoving;

    public void Init()
    {
        _logicalGrid.Init(this);
        _visualGrid.Init(this);

        _gridObjectMoving = new ObjectMover(this);
    }

    public int Width { get => _width; }
    public int Height { get => _height; }
    public float TileSize { get => _tileSize; }

    public Vector3 GridPosition { get => transform.position; }

    public IGridObjectMoving gridObjectMoving { get => _gridObjectMoving; }

    // Public methods
    public bool TrySetObjectInNode(GameObject gameObject, Vector2Int nodeCoordinates)
    {
        Node node = _logicalGrid.GetGridNode(nodeCoordinates);

        if (node == null)
        {
            Debug.LogError("Node is missing");
            return false;
        }
        if (!_logicalGrid.TrySetObjectInNode(node, gameObject))
        {
            return false;
        }        

        Vector2 worldCoord = GridToWorldInteraction.GridToWorldPosition(this, new Vector2Int(node.X, node.Y));
        gameObject.transform.position = new Vector3(worldCoord.x, worldCoord.y, gameObject.transform.position.z);
    
        return true;
    }

    public void RemoveObjectFromNode(Vector2Int nodeCoordinates)
    {
        Node node = _logicalGrid.GetGridNode(nodeCoordinates);

        if (node == null)
        {
            Debug.LogError("Node is missing");
            return;
        }

        node.Object = null;
    }

    public bool TryGetRandomEmptyNodeCoordinates(out Vector2Int coordinates)
    {
        Node node = null;
        bool result = TryGetRandomEmptyNode(out node);
        coordinates = new Vector2Int(node.X, node.Y);
        return result;
    }

    public GameObject GetObjectInNode(Vector2Int nodeCoordinates)
    {
        Node node = _logicalGrid.GetGridNode(nodeCoordinates);

        if (node == null) return null;
        return node.Object;
    }    

    public Vector2Int GetCoordinates(GameObject go)
    {
        return _logicalGrid.GetObjectCoordinates(go);
    }

    // Private Methods
    private bool TryGetRandomEmptyNode(out Node node)
    {
        return _logicalGrid.TryGetRandomEmptyNode(out node);
    }
}
