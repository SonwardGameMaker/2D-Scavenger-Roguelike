using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private float _tileSize = 1;

    [SerializeField] private LogicalGrid _logicalGrid;
    [SerializeField] private VisualGrid _visualGrid;

    public void Init()
    {
        _logicalGrid.Init(_width, _height, _tileSize);
        _visualGrid.Init(_logicalGrid);
    }

    public LogicalGrid LogicalGrid { get { return _logicalGrid; } }
    public VisualGrid VisualGrid { get { return _visualGrid; } }

    // Public methods
    public void SetObjectInNode(GameObject gameObject, Vector2Int nodeCoord)
    {
        SetObjectInNode(gameObject, _logicalGrid.GetGridNode(nodeCoord));
    }
    public void SetObjectInNode(GameObject gameObject, Node node)
    {
        node.Object = gameObject;

        Vector2 worldCoord = GridToWorldInteraction.GridToWorldPosition(_logicalGrid, new Vector2Int(node.X, node.Y));
        gameObject.transform.position = new Vector3(worldCoord.x, worldCoord.y, gameObject.transform.position.z);
    }

    public bool TryGetRandomEmptyNode(out Node node)
    {
        return _logicalGrid.TryGetRandomEmptyNode(out node);
    }
}
