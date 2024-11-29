using UnityEngine;

public class playerWarp : MonoBehaviour
{
    [SerializeField] public BoxCollider2D boundsCollider;

    private Vector2 boundsMin;
    private Vector2 boundsMax;

    void Start()
    {
        if (boundsCollider == null)
        {
            Debug.LogError("Bounds Collider not set!");
            return;
        }

        boundsMin = boundsCollider.bounds.min;
        boundsMax = boundsCollider.bounds.max;
    }

    void Update()
    {
        Vector3 newPosition = transform.position;

        if (newPosition.x < boundsMin.x) newPosition.x = boundsMax.x;
        if (newPosition.x > boundsMax.x) newPosition.x = boundsMin.x;
        if (newPosition.y < boundsMin.y) newPosition.y = boundsMax.y;
        if (newPosition.y > boundsMax.y) newPosition.y = boundsMin.y;

        transform.position = newPosition;
    }
}
