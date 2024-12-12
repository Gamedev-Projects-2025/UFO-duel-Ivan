using Unity.Mathematics;
using UnityEngine;

public class cameraWarpFollow : MonoBehaviour
{
    [SerializeField] private Transform subject;
    [SerializeField] private BoxCollider2D boundary;

    private Vector2 boundsMin, boundsMax;

    void Start()
    {
        boundsMin = boundary.bounds.min;
        boundsMax = boundary.bounds.max;
        
    }

    void LateUpdate()
    {
        if (subject != null)
        {
            Vector3 cameraPosition = subject.transform.position;

            float cameraHeight = Camera.main.orthographicSize;
            float cameraWidth = cameraHeight * Camera.main.aspect;

            cameraPosition.y = math.clamp(cameraPosition.y, boundsMin.y + cameraHeight, boundsMax.y - cameraHeight);
            cameraPosition.x = math.clamp(cameraPosition.x, boundsMin.x + cameraWidth, boundsMax.x - cameraWidth);

            transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10);
        }

    }
}
