using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class humanSpawn : MonoBehaviour
{
    public PolygonCollider2D polygonCollider;
    public GameObject prefab;
    public float spawnInterval = 2f;
    [SerializeField] private AudioClip sound;

    private void Start()
    {
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        while (true)
        {
            Vector3 randomPosition = GetRandomPointInPolygon();
            Instantiate(prefab, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomPointInPolygon()
    {
        Bounds bounds = polygonCollider.bounds;

        Vector3 randomPoint = Vector3.zero;
        do
        {

            randomPoint = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                1f
            );
        }
        while (!polygonCollider.OverlapPoint(randomPoint)); // Check if point is inside the polygon

        return randomPoint;
    }
}
