using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private WorldObjectsManager _worldObjectsManager;
    [SerializeField] private CharacterManager _characterManager;
    [SerializeField] private InputManager _inputManager;
    
    // Сервіси інітяться в Awake
    private void Awake()
    {
        _gridManager.Init();
        _cameraManager.Init(_gridManager);

        _characterManager.Init(_gridManager);
        _worldObjectsManager.Init(_gridManager);

        _turnManager.Init(_gridManager, _characterManager);

        _inputManager.Init(_characterManager, _turnManager);


        // Spawn
        _characterManager.SpawnEnemies(2, _gridManager);
        _worldObjectsManager.SpawnWorldObjects(WorldObjectType.Weed, 3, _gridManager);
        _worldObjectsManager.SpawnWorldObjects(WorldObjectType.Food, 1, _gridManager);
    }

}
