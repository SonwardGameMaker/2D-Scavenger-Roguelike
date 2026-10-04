using UnityEngine;

public class WorldObjectsManager : MonoBehaviour
{
    [SerializeField] private Exit _exit;
    [SerializeField] private Vector2Int _exitPosition;

    [SerializeField] WorldObjectContainer _worldObjectContainer;

    public void Init(IGridNodeInteractions gridInteractor)
    {
        SetExitIntoGrid(gridInteractor);
    }

    public Exit Exit { get { return _exit; } }

    // Public methods
    public void SpawnWorldObjects(WorldObjectType objectType, int objectCount, IGridNodeInteractions gridInteractor) // отут може потім як транзакцію зроблю
    {
        for (int i = 0; i < objectCount; i++)
        {
            SpawnWorldObject(objectType, gridInteractor);
        }
    }

    // Private methods
    private void SetExitIntoGrid(IGridNodeInteractions gridInteractor)
    {
        gridInteractor.TrySetObjectInNode(_exit.gameObject, _exitPosition);
    }

    private void SpawnWorldObject(WorldObjectType objectType, IGridNodeInteractions gridInteractor)
    {
        Vector2Int coordinates;
        if (!gridInteractor.TryGetRandomEmptyNodeCoordinates(out coordinates))
        {
            Debug.LogError("Not found empty nodes");
            return;
        }

        GameObject worldObject = _worldObjectContainer.SpawnObject(objectType);

        gridInteractor.TrySetObjectInNode(worldObject, coordinates);
    }
}
