using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public Enemy SpawnEnemy()
    {
        return Instantiate(_enemyPrefab, gameObject.transform);
    }
}
