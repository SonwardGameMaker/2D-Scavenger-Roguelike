using UnityEngine;

public class Weed : MonoBehaviour, IInteractable
{
    [SerializeField] private int _maxHitPoints;
    [SerializeField] private int _breakPoint; // Hit points amount when need to change sprite
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _currentHitPoints;

    public void Init() // треба буде подумати як отут викликати Ініт
    {
        _currentHitPoints = _maxHitPoints;
    }

    public int MaxHitPoints { get => _maxHitPoints; }
    public int CurrentHitPoints { get => _currentHitPoints; }

    public void Interact(Player player)
    {
        
    }

    private void TakeDamage()
    {
        _currentHitPoints -= 1;
    }
}
