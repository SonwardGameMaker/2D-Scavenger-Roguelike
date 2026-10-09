using UnityEngine;

public class Food : MonoBehaviour, IInteractable
{
    [SerializeField] private int _value;
    
    public void Interact(Player player)
    {
        player.ConsumeFood(_value);

        // invoke event to remove this object from scene
    }
}
