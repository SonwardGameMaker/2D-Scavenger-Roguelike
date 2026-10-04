using UnityEngine;

public static class GridToWorldInteraction
{
    public static Vector2Int WorldToGridPosition(IGridInfo gridInfo, Vector3 worldPosition)
    {
        Vector3 relativePosition = worldPosition - gridInfo.GridPosition;

        int x = Mathf.FloorToInt(relativePosition.x / gridInfo.TileSize);
        int y = Mathf.FloorToInt(relativePosition.y / gridInfo.TileSize);

        return new Vector2Int(x, y);
    }

    public static Vector2 GridToWorldPosition(IGridInfo gridInfo, Vector2Int gridPosition)
    {
        float x = gridInfo.GridPosition.x + (gridPosition.x * gridInfo.TileSize) + gridInfo.TileSize / 2;
        float y = gridInfo.GridPosition.y + (gridPosition.y * gridInfo.TileSize) + gridInfo.TileSize / 2;

        return new Vector2(x, y);
    }
}
