using UnityEngine;

public class seek : MonoBehaviour
{
    //the main target
    [SerializeField] public Transform target;

    //copies of the main target
    [SerializeField] public Transform[] Ghosttarget;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    //current target
    private Transform missileTarget;
    void Start()
    {
        //playing audio on spawn
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //seek the target if it exists
        if (target != null)
        {
            getClosest();
            move();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void move()
    {
        if (missileTarget != null)
        {
            //calculating the rotation and direction of the target
            Vector2 direction = (missileTarget.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, missileTarget.position, speed * Time.deltaTime);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle - 90f), rotationSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void getClosest()
    {
        //getting the closest target   
        missileTarget = target;
        float distance = Vector2.Distance(transform.position, missileTarget.position), ghostDistance = 0f;

        foreach (Transform t in Ghosttarget)
        {
            ghostDistance = Vector2.Distance(t.position, transform.position);
            if (distance > ghostDistance)
            {
                distance = ghostDistance;
                missileTarget = t;
            }
        }
    }
}
