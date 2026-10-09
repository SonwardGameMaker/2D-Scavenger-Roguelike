using UnityEngine;

public class BotAiManager : MonoBehaviour, IAiController
{
    private IGridObjectMoving _characterMoving;
    private ITurnManager _turnManager;

    private Enemy _current;

    public void Init(ITurnManager turnManager, IGridObjectMoving characterMoving)
    {
        _characterMoving = characterMoving;
        _turnManager = turnManager;
    }

    public void CharactersTurn(IGridEntity character)
    {
        _current = character as Enemy;

        Debug.Log($"{_current.gameObject.name}'s turn!");

        TryMoveInRandomDirection();
        _turnManager.CurrentCharacterEndedTurn(_current);

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
