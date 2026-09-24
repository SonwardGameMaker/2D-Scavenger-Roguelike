using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public void Init(LogicalGrid logicalGrid)
    {
        float xPos = (logicalGrid.transform.position.x + logicalGrid.Width * logicalGrid.TileSize) / 2;
        float yPos = (logicalGrid.transform.position.y + logicalGrid.Height * logicalGrid.TileSize) / 2;

        _camera.transform.position = new Vector3(xPos, yPos, _camera.transform.position.z);
    }
}
