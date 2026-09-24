using System.Collections.Generic;
using UnityEngine;

public class VisualGrid : MonoBehaviour
{
    private int _width;
    private int _height;
    private float _tileSize;

    private Vector3 _gridPosition;

    private List<SpriteRenderer> _groundSpriteObjects;
    private List<SpriteRenderer> _borderSpriteObjects;

    [SerializeField] private Sprite[] _groundSprites;
    [SerializeField] private Sprite[] _borderSprites;
    [SerializeField] private bool _debug = true;


    public void Init(IGridInfo gridInfo)
    {
        _width = gridInfo.Width;
        _height = gridInfo.Height;
        _tileSize = gridInfo.TileSize;

        _gridPosition = gridInfo.GridPosition;

        _groundSpriteObjects = new List<SpriteRenderer>();
        _borderSpriteObjects = new List<SpriteRenderer>();

        SpawnGroundSpites();
        SpawnBorderSprites();

        InitGroundTileSpriteNodes();
        InitBorderTileSpriteNodes();
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

    private void SpawnGroundSpites()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _groundSpriteObjects.Add(CreateTileSpriteNode(x, y, "Ground"));
            }
        }
    }

    private void SpawnBorderSprites()
    {
        for (int x = -1; x <= _width; x++)
        {
            for (int y = -1; y <= _height; y++)
            {
                bool isInside = x >= 0 && x < _width && y >= 0 && y < _height;
                if (isInside)
                    continue;

                _borderSpriteObjects.Add(CreateTileSpriteNode(x, y, "Border"));
            }
        }
    }

    private SpriteRenderer CreateTileSpriteNode(int x, int y, string name)
    {
        GameObject go = new GameObject($"{name} Sprite {x};{y}", typeof(SpriteRenderer));

        go.transform.SetParent(transform, false);

        float xCoord = _gridPosition.x + x * _tileSize + 0.5f * _tileSize;
        float yCoord = _gridPosition.y + y * _tileSize + 0.5f * _tileSize;
        float zCoord = _gridPosition.z;
        go.transform.position = new Vector3(xCoord, yCoord, zCoord);

        SpriteRenderer sprite = go.GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = "Ground";

        return sprite;

    }

    private void InitGroundTileSpriteNodes()
    {
        foreach (var sprite in _groundSpriteObjects)
            sprite.sprite = _groundSprites[Random.Range(0, _groundSprites.Length)];
    }
    
    private void InitBorderTileSpriteNodes()
    {
        foreach (var sprite in _borderSpriteObjects)
            sprite.sprite = _borderSprites[Random.Range(0, _borderSprites.Length)];
    }
}
