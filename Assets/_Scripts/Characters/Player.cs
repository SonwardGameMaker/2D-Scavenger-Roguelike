using UnityEngine;

public class Player : MonoBehaviour, IGridEntity, IDamagable
{
    [SerializeField] private int _startingFood;

    int _foodCount;

    public void Init()
    {
        _foodCount = _startingFood;
    }

    public int FoodCount 
    { 
        get => _foodCount; 
        set 
        {
            _foodCount = value;

            // invoke UI change event
        }
    }

    public GameObject GameObject { get => gameObject; }

    public void LooseFood(int amount)
    {
        int newCount = _foodCount - amount;

        if (newCount < 0)
        {
            newCount = 0;
        }

        if (newCount == 0)
        {
            FoodCount = 0;

            // invoke game over event
        }
    }

    public void ConsumeFood(int amount)
    {
        FoodCount += amount;
    }
}
