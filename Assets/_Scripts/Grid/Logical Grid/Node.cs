using UnityEngine;

public class Node
{
    private GameObject _gameObject;
    private bool _isEmpty = true;

    public Node(int x, int y)
    {
        X = x; Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public bool IsEmpty { get { return _isEmpty; } }
    public GameObject Object 
    {
        get { return _gameObject; }
        set
        {
            if (value == null)
            {
                _isEmpty = true;
            }
            else
            {
                _isEmpty = false;
            }

            _gameObject = value;
        }
    }
}
