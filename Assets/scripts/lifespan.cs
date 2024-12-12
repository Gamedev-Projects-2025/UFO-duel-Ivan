using UnityEngine;

public class lifespan : MonoBehaviour
{
    public float lifetime = 5f; // Time in seconds before the object destroys itself

    void Start()
    {
        // Schedule the object for destruction after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }
}
