using UnityEngine;

public class WorldObjectsManager : MonoBehaviour
{
    [SerializeField] private Exit _exit;
    [SerializeField] private Vector2Int _exitPosition;

    [SerializeField] WorldObjectContainer _worldObjectContainer;

    public void Init(GridManager gridManager)
    {
        SetExitIntoGrid(gridManager);
    }

    public Exit Exit { get { return _exit; } }

    // Public methods
    public void SpawnWorldObjects(WorldObjectType objectType, int objectCount, GridManager gridManager) // отут може потім як транзакцію зроблю
    {
        for (int i = 0; i < objectCount; i++)
        {
            SpawnWorldObject(objectType, gridManager);
        }
    }

    // Private methods
    private void SetExitIntoGrid(GridManager gridManager)
    {
        gridManager.SetObjectInNode(_exit.gameObject, _exitPosition);
    }

    private void SpawnWorldObject(WorldObjectType objectType, GridManager gridManager) // тут потім зроблю через інтерфейс, тіпа GridManager буде реалізовувати інтерфейс суто під цей функціонал
    {
        Node node = null;
        if (!gridManager.TryGetRandomEmptyNode(out node))
        {
            Debug.LogError("Not found empty nodes");
            return;
        }

        GameObject worldObject = _worldObjectContainer.SpawnObject(objectType);

        gridManager.SetObjectInNode(worldObject, node);
    }
}
