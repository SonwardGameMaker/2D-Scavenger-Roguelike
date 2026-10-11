using System.Collections;
using UnityEngine;

public class BotAiManager : MonoBehaviour, IAiController
{
    [SerializeField] private float _turnDelay;

    private IGridObjectMoving _characterMoving;

    private Enemy _current;

    public void Init(IGridObjectMoving characterMoving)
    {
        _characterMoving = characterMoving;
    }

    public IEnumerator CharactersTurn(IGridEntity character)
    {
        _current = character as Enemy;

        TryMoveInRandomDirection();

        yield return new WaitForSeconds(_turnDelay);
    }

    private bool TryMoveInRandomDirection()
    {
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

        // Fisher-Yates shuffle
        for (int i = directions.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (directions[i], directions[j]) = (directions[j], directions[i]);
        }

        foreach (Vector2Int direction in directions)
        {
            if (_characterMoving.TryMoveGridObject(direction, _current, out IGridEntity collision))
            {
                return true;
            }

            if (collision != null && collision is Player)
            {
                // TODO: Attack the player
                return true;
            }
        }

        return false;
    }
}
