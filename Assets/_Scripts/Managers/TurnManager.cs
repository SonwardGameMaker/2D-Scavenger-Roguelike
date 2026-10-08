using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour, ITurnManager, ICharacterMoving
{
    private IGridNodeInteractions _gridInteractions;
    private IPlayerController _playerController;
    private IAiController _aiController;

    private Player _player;
    private List<Enemy> _enemies;

    private List<Character> _turnOrder;
    private Character _currnet;
    private int _currentIndex;

    // Init
    public void Init(IGridNodeInteractions gridNodeInteractions, ICharacterContainer characterContainer)
    {
        _gridInteractions = gridNodeInteractions;


        _player = characterContainer.Player;
        _enemies = characterContainer.Enemies;

        _turnOrder = new List<Character>();
    }

    public void InitTurnOrder()
    {
        _turnOrder.Clear();

        _turnOrder.Add(_player);
        _turnOrder.AddRange(_enemies);

        _currentIndex = 0;
        _currnet = _turnOrder[_currentIndex];

        CurrentStartTurn();
    }

    public void RegisterPlayerController(IPlayerController playerController)
    {
        _playerController = playerController;
    }

    public void RegisterEnemyController(IAiController aiController)
    {
        _aiController = aiController;
    }

    // Public Methods
    public bool TryMoveCharacter(Vector2Int direction, Character character)
    {
        GameObject go = character.gameObject;
        Vector2Int oldPosition = _gridInteractions.GetCoordinates(go);
        Vector2Int newPosition = oldPosition + direction;

        if (_gridInteractions.TrySetObjectInNode(go, newPosition))
        {
            _gridInteractions.RemoveObjectFromNode(oldPosition);

            return true;
        }

        return false;
    }

    public void CurrentCharacterEndedTurn(Character currnet)
    {
        if (currnet != _currnet)
        {
            Debug.LogError($"Ended turn out of order: {_currnet.gameObject.name}");
            return;
        }

        _currentIndex = (_currentIndex + 1) % _turnOrder.Count;
        _currnet = _turnOrder[_currentIndex];

        CurrentStartTurn();
    }

    private void CurrentStartTurn()
    {
        if (_currnet is Player)
        {
            _playerController.PlayersTurn();
        }
        else
        {
            _aiController.CharactersTurn(_currnet);
        }
    }
}
