using UnityEngine;

public class Food : MonoBehaviour, IInteractable, IGridEntity
{
    [SerializeField] private int _value;

    public GameObject GameObject { get => gameObject; }

    public void Interact(Player player)
    {
        player.ConsumeFood(_value);

        // invoke event to remove this object from scene
    }
}
