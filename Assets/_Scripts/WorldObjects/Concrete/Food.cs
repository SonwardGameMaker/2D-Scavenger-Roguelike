using UnityEngine;

public class Food : WorldObject, IInteractable
{
    [SerializeField] private int _value;

    public InteractionResult Interact(Player player)
    {
        player.ConsumeFood(_value);

        base.Remove();

        return new InteractionResult(true);
    }
}
