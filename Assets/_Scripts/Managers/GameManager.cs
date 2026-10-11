using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private WorldObjectsManager _worldObjectsManager;
    [SerializeField] private CharacterManager _characterManager;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private BotAiManager _botAiManager;
    
    // Сервіси інітяться в Awake
    private void Awake()
    {
        // Init
        _gridManager.Init();
        _cameraManager.Init(_gridManager);

        _characterManager.Init(_gridManager);
        _worldObjectsManager.Init(_gridManager);

        _turnManager.Init(_characterManager.CharacterContainer);

        _inputManager.Init(_turnManager, _gridManager.gridObjectMoving, _characterManager.CharacterContainer);
        _botAiManager.Init(_turnManager, _gridManager.gridObjectMoving);

        // Register
        _turnManager.RegisterPlayerController(_inputManager);
        _turnManager.RegisterEnemyController(_botAiManager);

        // Spawn
        _characterManager.SpawnEnemies(2);
        _worldObjectsManager.SpawnWorldObjects(WorldObjectType.Weed, 3);
        _worldObjectsManager.SpawnWorldObjects(WorldObjectType.Food, 1);

        // Init Turn Order
        _turnManager.InitTurnOrder();

        // Start
        _turnManager.StartGame();
    }

}
