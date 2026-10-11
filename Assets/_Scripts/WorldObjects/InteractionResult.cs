using UnityEngine;

public readonly struct InteractionResult
{
    private readonly bool _goIntoNode; // оця штука означає чи після дії виконавцю потріно перейти у клітинку в якій був об'єкт з яким він взаємодіяв

    public InteractionResult(bool goIntoNode)
    {
        _goIntoNode = goIntoNode;
    }

    public bool GoIntoNode { get => _goIntoNode; }

    public static readonly InteractionResult Default = new InteractionResult(false);
}
