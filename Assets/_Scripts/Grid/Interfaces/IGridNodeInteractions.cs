using UnityEngine;

public interface IGridNodeInteractions
{
    public bool TrySetObjectInNode(IGridEntity gridEntity, Vector2Int nodeCoord);

    public void RemoveObjectFromNode(Vector2Int nodeCoordinates);

    public bool TryGetRandomEmptyNodeCoordinates(out Vector2Int coordinaes);

    public IGridEntity GetObjectInNode(Vector2Int nodeCoordinaets);

    public Vector2Int GetCoordinates(IGridEntity gridEntity);
}
