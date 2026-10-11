using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour, ITurnManager
{
    private IPlayerController _playerController;
    private IAiController _aiController;

    private Player _player;
    private List<Enemy> _enemies;

    private List<IGridEntity> _turnOrder;
    private IGridEntity _currnet;
    private int _currentIndex;

    // Init
    public void Init(ICharacterContainer characterContainer)
    {
        _player = characterContainer.Player;
        _enemies = characterContainer.Enemies;

        _turnOrder = new List<IGridEntity>();
    }

    public void InitTurnOrder()
    {
        _turnOrder.Clear();

        _turnOrder.Add(_player);
        _turnOrder.AddRange(_enemies);

        _currentIndex = 0;
        _currnet = _turnOrder[_currentIndex];

    }

    public void StartGame()
    {
        StartCoroutine(TurnLoop());
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
    private void CurrentCharacterEndedTurn(IGridEntity currnet)
    {
        if (currnet != _currnet)
        {
            Debug.LogError($"Ended turn out of order: {_currnet}");
            return;
        }

        _currentIndex = (_currentIndex + 1) % _turnOrder.Count;
        _currnet = _turnOrder[_currentIndex];

        CurrentStartTurn();
    }

    // Private Methods
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

    // Coroutines
    private IEnumerator TurnLoop()
    {
        while (true)
        {
            for (int i = 0; i < _turnOrder.Count; i++)
            {
                IGridEntity current = _turnOrder[i];

                if (current is Player)
                    yield return StartCoroutine(_playerController.PlayersTurn());
                else
                    yield return StartCoroutine(_aiController.CharactersTurn(current));
            }
        }
    }
}
