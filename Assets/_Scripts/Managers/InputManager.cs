using UnityEngine;


public class InputManager : MonoBehaviour
{
    private BaseMovement _inputActions;

    private ICharacterMoving _characterMoving;

    private Player _player;
    [SerializeField] private PlayerController _playerController;

    public void Init(ICharacterContainer characterContainer, ICharacterMoving characterMoving)
    {
        _player = characterContainer.Player;

        _characterMoving = characterMoving;

        _playerController.Init(_player, characterMoving);
    }


}
