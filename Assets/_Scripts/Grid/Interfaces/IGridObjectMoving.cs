using UnityEngine;

public interface IGridObjectMoving
{
    public bool TryMoveGridObject(Vector2Int direction, IGridEntity gridEntity, out IGridEntity collision);
}
