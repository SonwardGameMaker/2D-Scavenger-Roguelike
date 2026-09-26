using UnityEngine;

public interface IGridNodeInteractions
{
    public bool TrySetObjectInNode(GameObject gameObject, Vector2Int nodeCoord);
    public bool TrySetObjectInNode(GameObject gameObject, Node node);

    public bool TryGetRandomEmptyNode(out Node node);
}
