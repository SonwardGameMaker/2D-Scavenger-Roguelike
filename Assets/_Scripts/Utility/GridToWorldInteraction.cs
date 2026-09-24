using UnityEngine;

// тут подивлюс€, €кщо мен≥ треба буде реально р≥зн≥ с≥тки, тод≥ зроблю базовий клас дл€ с≥тки ≥ буду його сюди запихати. якщо н≥, тод≥ видалю в≥зуальну с≥тку
public static class GridToWorldInteraction
{
    public static Vector2Int WorldToGridPosition(LogicalGrid grid, Vector3 worldPosition)
    {
        Vector3 relativePosition = worldPosition - grid.transform.position;

        int x = Mathf.FloorToInt(relativePosition.x / grid.TileSize);
        int y = Mathf.FloorToInt(relativePosition.y / grid.TileSize);

        return new Vector2Int(x, y);
    }

    public static Vector2 GridToWorldPosition(LogicalGrid grid, Vector2Int gridPosition)
    {
        float x = grid.transform.position.x + (gridPosition.x * grid.TileSize) + grid.TileSize / 2;
        float y = grid.transform.position.y + (gridPosition.y * grid.TileSize) + grid.TileSize / 2;

        return new Vector2(x, y);
    }
}
