using UnityEngine;


public class InputManager : MonoBehaviour, IPlayerController
{
    private BaseMovement _inputActions;

    private IGridObjectMoving _characterMoving;

    private Player _player;
    [SerializeField] private PlayerController _playerController;

    public void Init(ITurnManager turnManager, IGridObjectMoving characterMoving, ICharacterContainer characterContainer)
    {
        _player = characterContainer.Player;

        _characterMoving = characterMoving;

        _playerController.Init(turnManager, _player, characterMoving);
    }

    public void PlayersTurn()
    {
        Debug.Log("Player's turn!");
    }
}
