using System.Collections.Generic;

public interface ICharacterContainer
{
    public Player Player { get; }

    public List<Enemy> Enemies { get; }
}
