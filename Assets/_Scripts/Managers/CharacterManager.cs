using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Vector2Int _playerStartPosition;

    [SerializeField] private EnemyContainer _enemyContainer;

    public void Init(GridManager gridManager)
    {
        SetPlayerIntoGrid(gridManager);
    }

    public Player Player { get { return _player; } }

    // Public methods
    public void SpawnEnemies(int enemyCount, GridManager gridManager) // отут може потім як транзакцію зроблю
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(gridManager);
        }
    }

    // Private methods
    private void SetPlayerIntoGrid(GridManager gridManager)
    {
        gridManager.SetObjectInNode(_player.gameObject, _playerStartPosition);
    }

    private void SpawnEnemy(IGridNodeInteractions gridNodeActions) // тут потім зроблю через інтерфейс, тіпа GridManager буде реалізовувати інтерфейс суто під цей функціонал
    {
        Node node = null;
        if (!gridNodeActions.TryGetRandomEmptyNode(out node))
        {
            Debug.LogError("Not found empty nodes");
            return;
        }

        Enemy enemy = _enemyContainer.SpawnEnemy();

        gridNodeActions.SetObjectInNode(enemy.gameObject, node);
    }
}
