using UnityEngine;

public interface IGridNodeInteractions
{
    public void SetObjectInNode(GameObject gameObject, Vector2Int nodeCoord);

    public GameObject GetObjectInNode(Vector2Int nodeCoordinaets);

    public bool TryGetRandomEmptyNodeCoordinates(out Vector2Int coordinaes);
}
