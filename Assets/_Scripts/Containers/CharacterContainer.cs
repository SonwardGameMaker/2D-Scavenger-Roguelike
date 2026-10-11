using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour, ICharacterContainer
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyContainer _enemyContainer;

    public Player Player { get => _player; }

    public List<Enemy> Enemies => _enemyContainer.Enemies;

    public Enemy SpawnEnemy()
    {
        return _enemyContainer.SpawnEnemy();
    }
}
