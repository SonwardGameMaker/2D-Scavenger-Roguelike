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
    public void SpawnEnemies(int enemyCount, GridManager gridManager) // îòóò ìîæå ïîò³ì ÿê òðàíçàêö³þ çðîáëþ
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(gridManager);
        }
    }

    // Private methods
    private void SetPlayerIntoGrid(GridManager gridManager)
    {
        gridManager.TrySetObjectInNode(_player.gameObject, _playerStartPosition);
    }

    private void SpawnEnemy(IGridNodeInteractions gridNodeActions) // òóò ïîò³ì çðîáëþ ÷åðåç ³íòåðôåéñ, ò³ïà GridManager áóäå ðåàë³çîâóâàòè ³íòåðôåéñ ñóòî ï³ä öåé ôóíêö³îíàë
    {
        Vector2Int coordinates;
        if (!gridNodeActions.TryGetRandomEmptyNodeCoordinates(out coordinates))
        {
            Debug.LogError("Not found empty nodes");
            return;
        }

        Enemy enemy = _enemyContainer.SpawnEnemy();

        gridNodeActions.TrySetObjectInNode(enemy.gameObject, coordinates);
    }
}
