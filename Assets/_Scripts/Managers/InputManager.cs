using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour, IPlayerController
{
    private Player _player;
    private IGridObjectMoving _characterMoving;
    private ITurnManager _turnManager;

    private bool _playersTurn;

    public void Init(ITurnManager turnManager, IGridObjectMoving characterMoving, ICharacterContainer characterContainer)
    {
        _player = characterContainer.Player;

        _characterMoving = characterMoving;

        _turnManager = turnManager;
        _playersTurn = false;
    }

    public IEnumerator PlayersTurn()
    {
        _playersTurn = true;
        // Debug.Log("Player's turn!");

        yield return new WaitUntil(() => !_playersTurn);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!_playersTurn) { return; }
        if (!context.performed) { return; }

        Vector2 moveInput = context.ReadValue<Vector2>();
        Vector2Int direction = new Vector2Int((int)moveInput.x, (int)moveInput.y);

        if (direction == Vector2Int.zero)
        {
            return;
        }

        if (_characterMoving.TryMoveGridObject(direction, _player, out IGridEntity collision))
        {
            EndPlayerTurn();
        }
        else if (collision != null && collision is IInteractable interactable)
        {
            if (interactable.Interact(_player).GoIntoNode)
            {
                _characterMoving.TryMoveGridObject(direction, _player, out _);
            }


            EndPlayerTurn();
        }
    }

    private void EndPlayerTurn()
    {
        _playersTurn = false;
        // _turnManager.CurrentCharacterEndedTurn(_player);
    }
}
