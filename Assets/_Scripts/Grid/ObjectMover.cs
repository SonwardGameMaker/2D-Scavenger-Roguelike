using UnityEngine;
using UnityEngine.TextCore.Text;

public class ObjectMover : IGridObjectMoving
{
    private IGridNodeInteractions _gridInteractions;

    public ObjectMover(IGridNodeInteractions gridInteractions)
    {
        _gridInteractions = gridInteractions;
    }

    public bool TryMoveGridObject(Vector2Int direction, GameObject go, out GameObject collision)
    {
        Vector2Int oldPosition = _gridInteractions.GetCoordinates(go);
        Vector2Int newPosition = oldPosition + direction;

        collision = _gridInteractions.GetObjectInNode(newPosition);

        if (_gridInteractions.TrySetObjectInNode(go, newPosition))
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
