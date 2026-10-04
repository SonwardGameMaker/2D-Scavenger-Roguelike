using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public void Init(IGridInfo gridInfo)
    {
        Vector3 gridPosition = gridInfo.GridPosition;

        float xPos = gridPosition.x + gridInfo.Width * gridInfo.TileSize / 2;
        float yPos = gridPosition.y + gridInfo.Height * gridInfo.TileSize / 2;

        _camera.transform.position = new Vector3(xPos, yPos, _camera.transform.position.z);
    }
}
