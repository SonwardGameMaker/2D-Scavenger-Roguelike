using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private List<Enemy> _enemies = new List<Enemy>();
    
    public List<Enemy> Enemies { get => _enemies; }

    public Enemy SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, gameObject.transform).GetComponent<Enemy>();

        _enemies.Add(enemy);

        return enemy;
    }
}
