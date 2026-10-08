using UnityEngine;

public interface ICharacterMoving
{
    public bool TryMoveCharacter(Vector2Int direction, Character character);
}
