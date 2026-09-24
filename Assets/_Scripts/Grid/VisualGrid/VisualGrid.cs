using UnityEngine;

public class VisualGrid : MonoBehaviour
{
    private int _width;
    private int _height;
    private float _tileSize;

    private Vector3 _gridPosition;

    [SerializeField] private Sprite[] _groundSprites;
    [SerializeField] private Sprite[] _borderSprites;
    [SerializeField] private bool _debug = true;

    public void Init(IGridInfo gridInfo)
    {
        _width = gridInfo.Width;
        _height = gridInfo.Height;
        _tileSize = gridInfo.TileSize;

        _gridPosition = gridInfo.GridPosition;

        CreateTileSpriteNodes();
        InitTileSpriteNodes();
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        if (!_debug) return;

        Gizmos.color = Color.red;

        for (int x = 0; x <= _width; x++)
            Gizmos.DrawLine(_gridPosition + new Vector3(x, 0, 0) * _tileSize,
                            _gridPosition + new Vector3(x, _height, 0) * _tileSize);

        for (int y = 0; y <= _height; y++)
            Gizmos.DrawLine(_gridPosition + new Vector3(0, y, 0) * _tileSize,
                            _gridPosition + new Vector3(_width, y, 0) * _tileSize);

    }

    private void CreateTileSpriteNodes()
    {

    }

    private void InitTileSpriteNodes()
    {

    }
    
}
