using System;
using UnityEngine;

public abstract class WorldObject : MonoBehaviour, IGridEntity
{
    public event Action<WorldObject> OnRemove;

    public GameObject GameObject { get => gameObject; }

    protected void Remove()
    {
        OnRemove?.Invoke(this);
    }
}
