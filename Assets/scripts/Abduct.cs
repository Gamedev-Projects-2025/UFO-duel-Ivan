using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Abduct : MonoBehaviour
{
    [SerializeField] private string enemyTag;
    [SerializeField] private NumberField score;
    [SerializeField] private int points;

    private Collider2D target;

    private bool isPlayerInTrigger = false;
    private void Start()
    {
        //restting the score to zero
        score.SetNumber(0);
    }

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

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            PerformAction();
        }
    }

    //abduting the target and adding to the score
    void PerformAction()
    {
        Destroy(target.gameObject);
        isPlayerInTrigger = false;
        target = null;
        score.AddNumber(points);
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
