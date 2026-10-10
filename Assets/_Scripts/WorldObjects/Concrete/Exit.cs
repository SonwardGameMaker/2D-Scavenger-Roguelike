using UnityEngine;

public class Exit : WorldObject, IInteractable
{
    public InteractionResult Interact(Player player)
    {
        Debug.Log("Level End");

        base.Remove();

        return new InteractionResult(true);
    }
}
