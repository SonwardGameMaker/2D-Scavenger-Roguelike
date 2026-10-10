using UnityEngine;

public class WorldObjectsManager : MonoBehaviour
{
    [SerializeField] private Exit _exit;
    [SerializeField] private Vector2Int _exitPosition;

    [SerializeField] WorldObjectContainer _worldObjectContainer;

    IGridNodeInteractions _gridNodeInteractions;

    public void Init(IGridNodeInteractions gridInteractor)
    {
        _gridNodeInteractions = gridInteractor;

        SetExitIntoGrid(_gridNodeInteractions);

        _exit.OnRemove += RemoveWorldObject;
    }

    public Exit Exit { get { return _exit; } }

    // Public methods
    public void SpawnWorldObjects(WorldObjectType objectType, int objectCount) // отут може потім як транзакцію зроблю
    {
        for (int i = 0; i < objectCount; i++)
        {
            SpawnWorldObject(objectType, _gridNodeInteractions);
        }
    }

    // Private methods
    private void SetExitIntoGrid(IGridNodeInteractions gridInteractor)
    {
        gridInteractor.TrySetObjectInNode(_exit, _exitPosition);
    }

    private void SpawnWorldObject(WorldObjectType objectType, IGridNodeInteractions gridInteractor)
    {
        Vector2Int coordinates;
        if (!gridInteractor.TryGetRandomEmptyNodeCoordinates(out coordinates))
        {
            Debug.LogError("Not found empty nodes");
            return;
        }

        WorldObject worldObject = _worldObjectContainer.SpawnObject(objectType) as WorldObject;

        worldObject.OnRemove += RemoveWorldObject;

        gridInteractor.TrySetObjectInNode(worldObject, coordinates);
    }

    private void RemoveWorldObject(WorldObject worldObject)
    {
        _gridNodeInteractions.RemoveObjectFromNode(_gridNodeInteractions.GetCoordinates(worldObject));

        worldObject.OnRemove -= RemoveWorldObject;

        if (worldObject is Exit)
        {
            return;
        }

        _gridNodeInteractions.RemoveObjectFromGrid(worldObject);

        worldObject.gameObject.SetActive(false);
    }
}
