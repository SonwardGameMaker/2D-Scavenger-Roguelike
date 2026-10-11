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
    public void StartGame()
    {
        StartCoroutine(TurnLoop());
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

            yield return null;
        }
    }
}
