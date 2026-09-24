using UnityEngine;

public interface IGridNodeInteractions
{
    public void SetObjectInNode(GameObject gameObject, Vector2Int nodeCoord);
    public void SetObjectInNode(GameObject gameObject, Node node);

    public bool TryGetRandomEmptyNode(out Node node);
}
