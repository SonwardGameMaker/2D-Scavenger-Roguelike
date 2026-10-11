using UnityEngine;

public class WorldObjectContainer : MonoBehaviour
{
    [SerializeField] private Weed _weedPrefab;
    [SerializeField] private Food _foodPrefab;

    // Public methods
    public IGridEntity SpawnObject(WorldObjectType objectType)
    {
        GameObject worldObject = null;

        switch (objectType) 
        {
            case WorldObjectType.None:
                break;
            case WorldObjectType.Weed:
                worldObject = _weedPrefab.gameObject;
                break;
            case WorldObjectType.Food:
                worldObject = _foodPrefab.gameObject;
                break;
            default:
                break;
        }


        return Instantiate(worldObject, transform).GetComponent<IGridEntity>();
    }
}
