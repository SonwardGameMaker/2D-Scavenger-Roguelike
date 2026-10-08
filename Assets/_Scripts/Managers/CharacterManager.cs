using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector2Int _playerStartPosition;
    [SerializeField] private CharacterContainer _characterContainer;

    public void Init(IGridNodeInteractions gridInteractor)
    {
        SetPlayerIntoGrid(gridInteractor);
    }

    public Player Player { get => _player;  }
    public ICharacterContainer CharacterContainer { get => _characterContainer;  }

    // Public methods
    public void SpawnEnemies(int enemyCount, IGridNodeInteractions gridInteractor)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(gridInteractor);
        }
    }

    // Private methods
    private void SetPlayerIntoGrid(IGridNodeInteractions gridInteractor)
    {
        gridInteractor.TrySetObjectInNode(_player.gameObject, _playerStartPosition);
    }

    private void SpawnEnemy(IGridNodeInteractions gridInteractor)
    {
        Vector2Int coordinates;
        if (!gridInteractor.TryGetRandomEmptyNodeCoordinates(out coordinates))
        {
            Debug.LogError("Not found empty nodes");
            return;
        }

        Enemy enemy = _characterContainer.SpawnEnemy();

        gridInteractor.TrySetObjectInNode(enemy.gameObject, coordinates);
    }
}
