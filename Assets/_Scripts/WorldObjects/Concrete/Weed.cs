using UnityEngine;

public class Weed : WorldObject, IInteractable
{
    [SerializeField] private Sprite _healthySprite;
    [SerializeField] private Sprite _damagedSprite;

    [SerializeField] private int _maxHitPoints;
    [SerializeField] private int _breakPoint; // Damage amount when need to change sprite
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _damageTaken;

    public int MaxHitPoints { get => _maxHitPoints; }

    public InteractionResult Interact(Player player)
    {
        _damageTaken += 1;

        if (_damageTaken >= _breakPoint)
        {
            _spriteRenderer.sprite = _damagedSprite;
        }

        if (_damageTaken >= _maxHitPoints)
        {
            Remove();

            return new InteractionResult(true);
        }

        return InteractionResult.Default;
    }

    public void ResetDamage()
    {
        _damageTaken = 0;

        _spriteRenderer.sprite = _healthySprite;
    }

}
