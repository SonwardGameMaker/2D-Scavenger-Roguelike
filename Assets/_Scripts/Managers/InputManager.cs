using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour, IPlayerController
{
    private Player _player;
    private IGridObjectMoving _characterMoving;
    private ITurnManager _turnManager;

    private Vector2Int _direction;
    private bool _playersTurn;

    public void Init(ITurnManager turnManager, IGridObjectMoving characterMoving, ICharacterContainer characterContainer)
    {
        _player = characterContainer.Player;

        _characterMoving = characterMoving;

        _turnManager = turnManager;
        _direction = new Vector2Int();
        _playersTurn = false;
    }

    public void PlayersTurn()
    {
        _playersTurn = true;
        Debug.Log("Player's turn!");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!_playersTurn) { return; }
        if (!context.performed) { return; }

        Vector2 moveInput = context.ReadValue<Vector2>();
        _direction = new Vector2Int((int)moveInput.x, (int)moveInput.y);

        if (_characterMoving.TryMoveGridObject(_direction, _player, out IGridEntity collision))
        {
            EndPlayerTurn();
        }
        else if (collision != null && collision is IInteractable interactable)
        {
            interactable.Interact(_player);
            EndPlayerTurn();
        }
    }

    private void EndPlayerTurn()
    {
        _playersTurn = false;
        _turnManager.CurrentCharacterEndedTurn(_player);
    }
}
