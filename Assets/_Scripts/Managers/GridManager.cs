using UnityEngine;

public class GridManager : MonoBehaviour, IGridInfo, IGridNodeInteractions
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private float _tileSize = 1;

    [SerializeField] private LogicalGrid _logicalGrid;
    [SerializeField] private VisualGrid _visualGrid;

    public void Init()
    {
        _logicalGrid.Init(this);
        _visualGrid.Init(this);
    }

    public int Width { get { return _width; } }
    public int Height { get { return _height; } }
    public float TileSize { get { return _tileSize; } }

    public Vector3 GridPosition { get { return transform.position; } }

    // Public methods
    public bool TrySetObjectInNode(GameObject gameObject, Vector2Int nodeCoord)
    {
        Node node = _logicalGrid.GetGridNode(nodeCoord);

        if (!node.IsEmpty)
        {
            Debug.LogError("Node already occupied"); // îöå ìîæíà ïîò³ì âçàãàë³ äåñü ³íäå âèíåñòè
            return false;
        }

        node.Object = gameObject;

        Vector2 worldCoord = GridToWorldInteraction.GridToWorldPosition(_logicalGrid, new Vector2Int(node.X, node.Y));
        gameObject.transform.position = new Vector3(worldCoord.x, worldCoord.y, gameObject.transform.position.z);
    
        return true;
    }

    public bool TryGetRandomEmptyNodeCoordinates(out Vector2Int coordinates)
    {
        Node node = null;
        bool result = TryGetRandomEmptyNode(out node);
        coordinates = new Vector2Int(node.X, node.Y);
        return result;
    }

    /// <summary>
    /// Öåé ìåòîä ìàº ïîâåðòàòè Object ç Node ïî âêàçàíèì êîîðäèíàòàì
    /// </summary>
    /// <param name="nodeCoordinates"></param>
    /// <returns></returns>
    public GameObject GetObjectInNode(Vector2Int nodeCoordinates)
    {
        return null; // TODO
    }

    // Private Methods
    private bool TryGetRandomEmptyNode(out Node node)
    {
        return _logicalGrid.TryGetRandomEmptyNode(out node);
    }
}
