using System;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class fireMissile : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private string enemyTag;

    //time between shots
    [SerializeField] private float coolDown;

    //The cooldown meter for the weapon
    [SerializeField] private NumberField meter;

    private float lastSpawnTime = -Mathf.Infinity;

    private Collider2D target;

    //Check if entity is in the trigger
    private bool isPlayerInTrigger = false; 

    //Checking if there is an object entering, exiting, or inside the collidor
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == enemyTag)
        {
            isPlayerInTrigger = true;
            target = other;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == enemyTag)
        {

            isPlayerInTrigger = true;
            target = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == enemyTag)
        {
            isPlayerInTrigger = false;
            target = null;
        }
    }
    void Start()
    {
        meter.SetNumber(100);
    }
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Space) && Time.time >= lastSpawnTime + coolDown)
        {
            lastSpawnTime = Time.time;
            PerformAction();
        }

        //Setting the number on the meter for the weapon cooldown
        float elapsedTime = Time.time - lastSpawnTime;
        float cooldownPercentage = Mathf.Clamp((elapsedTime / coolDown) * 100, 0, 100);

        meter.SetNumber((int)cooldownPercentage);
    }

    void PerformAction()
    {
        //firing a missile back at the target
        GameObject missile = Instantiate(prefab, transform.position, Quaternion.identity);
        seek seekScript = missile.GetComponent<seek>();
        seekScript.target = target.transform;
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
