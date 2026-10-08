using UnityEngine;

public interface IGridNodeInteractions
{
    public bool TrySetObjectInNode(GameObject go, Vector2Int nodeCoord);

    public void RemoveObjectFromNode(Vector2Int nodeCoordinates);

    public bool TryGetRandomEmptyNodeCoordinates(out Vector2Int coordinaes);

    public GameObject GetObjectInNode(Vector2Int nodeCoordinaets);

    public Vector2Int GetCoordinates(GameObject go);
}
