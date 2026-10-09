using UnityEngine;
using UnityEngine.TextCore.Text;

public class ObjectMover : IGridObjectMoving
{
    private IGridNodeInteractions _gridInteractions;

    public ObjectMover(IGridNodeInteractions gridInteractions)
    {
        _gridInteractions = gridInteractions;
    }

    public bool TryMoveGridObject(Vector2Int direction, IGridEntity gridEntity, out IGridEntity collision)
    {
        Vector2Int oldPosition = _gridInteractions.GetCoordinates(gridEntity);
        Vector2Int newPosition = oldPosition + direction;

        collision = _gridInteractions.GetObjectInNode(newPosition);

        if (_gridInteractions.TrySetObjectInNode(gridEntity, newPosition))
        {
            _gridInteractions.RemoveObjectFromNode(oldPosition);

            return true;
        }
        else
        {
            return false;
        }
            
    }
}
