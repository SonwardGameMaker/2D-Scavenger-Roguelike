using UnityEngine;

public class BotAiManager : MonoBehaviour, IAiController
{
    private IGridInfo _gridInfo;
    private ICharacterMoving _characterMoving;
    private ITurnManager _turnManager;

    private Enemy _current;

    public void Init(ITurnManager turnManager, ICharacterMoving characterMoving, IGridInfo gridInfo)
    {
        _characterMoving = characterMoving;
        _gridInfo = gridInfo;
        _turnManager = turnManager;
    }

    public void CharactersTurn(Character character)
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
            if (_characterMoving.TryMoveCharacter(direction, _current))
            {
                return true;
            }
        }

        return false;
    }
}
