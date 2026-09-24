using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private WorldObjectsManager _worldObjectsManager;
    [SerializeField] private CharacterManager _characterManager;
    
    // Сервіси інітяться в Awake
    private void Awake()
    {
        _gridManager.Init();
        _cameraManager.Init(_gridManager.LogicalGrid);

        _characterManager.Init(_gridManager);
        _worldObjectsManager.Init(_gridManager);

        _characterManager.SpawnEnemies(2, _gridManager);
        _worldObjectsManager.SpawnWorldObjects(WorldObjectType.Weed, 3, _gridManager);
        _worldObjectsManager.SpawnWorldObjects(WorldObjectType.Food, 1, _gridManager);
    }

}
