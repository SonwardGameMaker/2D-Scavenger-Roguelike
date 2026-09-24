using UnityEngine;

public class VisualGrid : MonoBehaviour
{
    private LogicalGrid _logicalGrid;
    [SerializeField] private Sprite[] _groundSprites;

    public void Init(LogicalGrid logicalGrid)
    {
        _logicalGrid = logicalGrid;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.red;

        for (int x = 0; x <= _logicalGrid.Width; x++)
            Gizmos.DrawLine(transform.position + new Vector3(x, 0, 0) * _logicalGrid.TileSize,
                            transform.position + new Vector3(x, _logicalGrid.Height, 0) * _logicalGrid.TileSize);

        for (int y = 0; y <= _logicalGrid.Height; y++)
            Gizmos.DrawLine(transform.position + new Vector3(0, y, 0) * _logicalGrid.TileSize,
                            transform.position + new Vector3(_logicalGrid.Width, y, 0) * _logicalGrid.TileSize);

    }
}
