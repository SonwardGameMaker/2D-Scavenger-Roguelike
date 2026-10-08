using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour, ICharacterMoving
{
    private IGridNodeInteractions _gridInteractions;
    private Player _player;
    private List<Enemy> _enemies;

    public void Init(IGridNodeInteractions gridNodeInteractions, ICharacterContainer characterContainer)
    {
        _gridInteractions = gridNodeInteractions;


        _player = characterContainer.Player;
        _enemies = characterContainer.Enemies; // for now it returns null, TODO


    }

    public bool TryMoveCharacter(Vector2Int direction, GameObject character)
    {
        Vector2Int oldPosition = _gridInteractions.GetCoordinates(character);
        Vector2Int newPosition = oldPosition + direction;

        if (_gridInteractions.TrySetObjectInNode(character, newPosition))
        {
            _gridInteractions.RemoveObjectFromNode(oldPosition);

            return true;
        }

        return false;
    }
}
