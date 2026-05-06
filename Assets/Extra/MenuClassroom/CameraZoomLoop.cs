using UnityEngine;

public class CameraZoomLoop : MonoBehaviour
{
    public float zoomSpeed = 1f;     // speed of zoom
    public float zoomAmount = 0.5f;  // how much it zooms

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * zoomSpeed) * zoomAmount;

        transform.position = startPos + transform.forward * offset;
    }
}