using System.Collections;
using UnityEngine;

public class seekerSpawn : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float interval = 1.0f;
    [SerializeField] public Transform[] ghostPlayer;
    [SerializeField] public BoxCollider2D boundingBox;

    void Start()
    {
        StartCoroutine(spawn());
    }

    private IEnumerator spawn()
    {
        while (true)
        {
            GameObject seeker = Instantiate(prefab,transform.position,Quaternion.identity);
            seek seekerScript = seeker.GetComponent<seek>();
            seekerScript.target = target;
            seekerScript.Ghosttarget = ghostPlayer;
            playerWarp warp = seeker.GetComponent<playerWarp>();
            warp.boundsCollider = boundingBox;
            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
