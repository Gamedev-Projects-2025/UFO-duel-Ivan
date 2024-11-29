using System.Collections;
using UnityEngine;

public class rocketSpawn : MonoBehaviour
{
    //Used to spawn rocket trucks within the boarders of the polygonCollider
    [SerializeField] private PolygonCollider2D polygonCollider;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform target;
    [SerializeField] private float spawnInterval = 2f;

    //An area around the player where no trucks can spawn
    [SerializeField] private CapsuleCollider2D noSpawn;

    //Ghosts are copies of the player used for the navigation of the missiles on the 2D plane
    //There are 4 copies at euqal distances from the player in all 4 wind directions that move in sync with the main player.
    // The missiles will always follow the closest target, causing them to warp across the screen like the player
    [SerializeField] private Transform[] ghosts;

    //Bouding box of the world, used for warping
    [SerializeField] private BoxCollider2D boundingBox;
    
    private void Start()
    {
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        while (true)
        {
            //setting up the prefab
            Vector3 randomPosition = GetRandomPointInPolygon();
            GameObject newLaucnher = Instantiate(prefab, randomPosition, Quaternion.identity);
            seekerSpawn seekerSpawner = newLaucnher.GetComponent<seekerSpawn>();
            seekerSpawner.target = target;
            seekerSpawner.ghostPlayer = ghosts;
            seekerSpawner.boundingBox = boundingBox;


            yield return new WaitForSeconds(spawnInterval);
        }
    }

    //generating a random point until it falls within the Polygon but outside the noSpawn zone
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
        while (!polygonCollider.OverlapPoint(randomPoint)||noSpawn.OverlapPoint(randomPoint)); // Check if point is inside the polygon
        return randomPoint;
    }
}
