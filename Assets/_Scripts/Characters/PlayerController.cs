using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player _player;
    private ICharacterMoving _characterMoving;
    private ITurnManager _turnManager;

    private Vector2Int _direction;

    public void Init(ITurnManager turnManager, Player player, ICharacterMoving characterMoving)
    {
        _player = player;
        _characterMoving = characterMoving;
        _turnManager = turnManager;

        _direction = new Vector2Int();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        Vector2 moveInput = context.ReadValue<Vector2>();
        _direction = new Vector2Int((int)moveInput.x, (int)moveInput.y);
        
        if(_characterMoving.TryMoveCharacter(_direction, _player))
        {
            _turnManager.CurrentCharacterEndedTurn(_player);
        }

    }
}
