using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private int _pixelPerUnit = 32;

    public void Init(IGridInfo gridInfo)
    {
        Vector3 gridPosition = gridInfo.GridPosition;

        float xPos = gridPosition.x + gridInfo.Width * gridInfo.TileSize / 2;
        float yPos = gridPosition.y + gridInfo.Height * gridInfo.TileSize / 2;

        _camera.transform.position = new Vector3(xPos, yPos, _camera.transform.position.z);

        _camera.orthographicSize = (gridInfo.Height + 2) * gridInfo.TileSize / 2;

        PixelPerfectCamera pixelPerfectCamera = _camera.GetComponent<PixelPerfectCamera>();

        pixelPerfectCamera.assetsPPU = _pixelPerUnit;

        pixelPerfectCamera.refResolutionX = Mathf.RoundToInt((gridInfo.Width + 2) * gridInfo.TileSize * _pixelPerUnit);
        pixelPerfectCamera.refResolutionY = Mathf.RoundToInt((gridInfo.Height + 2) * gridInfo.TileSize * _pixelPerUnit);
    }
}
